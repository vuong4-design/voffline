import re
import sys
from pathlib import Path

PATH = Path("auto/ns44/InventoryItemHelper.cs")
APPLY = "--apply" in sys.argv

METHODS = {
    "GetContainerGridDimensions": {"array": "containerGridDimensionTable", "array2": "containerGridDimensionRows", "i": "rowIndex"},
    "SupportsDirectContainerTransfer": {"array": "supportedContainerCodes", "i": "codeIndex"},
    "SubmitDetectedDialogResponse": {"text": "dialogPromptText", "array": "affirmativeResponseTokens", "array2": "promptTokens", "num": "promptTokenIndex", "num2": "affirmativeTokenIndex", "array3": "inputPromptMarkers", "i": "markerIndex", "flag": "markerFound", "result": "hasResponseText"},
    "GetDialogPromptText": {"num": "dialogRootPointer", "num2": "promptTextAddress", "uint_": "promptLengthAddress", "int_": "bytesTransferred", "array": "promptBuffer", "num3": "promptLength"},
    "SetDialogInputText": {"int_": "bytesTransferred", "array": "pointerBuffer", "num": "dialogRootPointer", "num2": "inputTextBufferAddress", "array2": "inputTextBytes", "array3": "inputStateBuffer", "byte_": "inputLengthByte", "num3": "inputReadyPollCount", "flag": "lengthWriteSucceeded", "flag2": "textWriteSucceeded"},
    "GetDialogInputText": {"int_": "bytesTransferred", "array": "pointerBuffer", "num": "dialogRootPointer", "num2": "inputTextBufferAddress", "num3": "inputReadyPollCount", "array2": "inputStateBuffer", "byte_": "inputTextBytes"},
    "GetShortcutItemRecordIndexBySlot": {"num": "shortcutTableBaseAddress", "num2": "shortcutItemIndexTableAddress", "result": "shortcutItemRecordIndex"},
    "IsInventoryBoxOpen": {"uint_": "inventoryBoxStateAddress", "num": "inventoryBoxStateValue"},
    "GetCollectionBoxProgressValue": {"uint_": "collectionBoxRootAddress", "num": "collectionBoxRootPointer", "uint_2": "collectionBoxProgressAddress"},
    "ShowCollectionBox": {"uint_": "collectionBoxRootAddress", "num": "collectionBoxRootPointer", "uint_2": "collectionBoxProgressAddress", "int_": "bytesTransferred", "byte_": "visibleStateBytes"},
    "CloseInventoryBoxAndPrimaryMenu": {"result": "wasInventoryBoxOpen", "uint_": "primaryMenuStateAddress"},
    "GetInventoryBoxItemCount": {"num": "inventoryBoxRootPointer", "num2": "inventoryBoxDataPointer"},
    "GetHeldItemRecordIndex": {"int_": "bytesTransferred", "array": "fourByteBuffer", "num": "inventoryEntryTableBaseAddress", "num2": "itemRecordTableBaseAddress", "num3": "inventoryEntryCount", "num4": "processedEntryCount", "num5": "entryIndex", "num6": "inventoryEntryAddress", "num7": "itemRecordIndex", "num8": "itemRecordAddress"},
    "PlaceHeldItemInAvailableGridSlot": {"int_": "bytesTransferred", "array": "singleByteBuffer", "array2": "fourByteBuffer", "num": "inventoryEntryTableBaseAddress", "num2": "itemRecordTableBaseAddress", "num3": "inventoryEntryCount", "num4": "processedEntryCount", "num5": "entryIndex", "num6": "itemRecordIndex", "num7": "itemRecordAddress", "num8": "inventoryEntryAddress", "uint_1": "itemWidth", "uint_2": "itemHeight", "num9": "targetContainerId", "array3": "targetGridPosition", "num10": "moveRetryCount"},
}

DECL_PREFIX = r"(?m)^\s*(?:public|private|internal)\s+static\s+[^\r\n(]+?\b"


def find_method_span(src, name):
    m = re.search(DECL_PREFIX + re.escape(name) + r"\s*\(", src)
    if not m:
        raise RuntimeError(f"method declaration not found: {name}")
    brace = src.find("{", m.end())
    if brace < 0:
        raise RuntimeError(f"opening brace not found: {name}")
    i, depth, state = brace, 0, "code"
    while i < len(src):
        c = src[i]
        n = src[i + 1] if i + 1 < len(src) else ""
        if state == "code":
            if c == "/" and n == "/": state, i = "line_comment", i + 2; continue
            if c == "/" and n == "*": state, i = "block_comment", i + 2; continue
            if c == "@" and n == '"': state, i = "verbatim_string", i + 2; continue
            if c == '"': state, i = "string", i + 1; continue
            if c == "'": state, i = "char", i + 1; continue
            if c == "{": depth += 1
            elif c == "}":
                depth -= 1
                if depth == 0: return m.start(), i + 1
            i += 1; continue
        if state == "line_comment":
            if c in "\r\n": state = "code"
            i += 1; continue
        if state == "block_comment":
            if c == "*" and n == "/": state, i = "code", i + 2
            else: i += 1
            continue
        if state == "string":
            if c == "\\": i += 2
            elif c == '"': state, i = "code", i + 1
            else: i += 1
            continue
        if state == "verbatim_string":
            if c == '"' and n == '"': i += 2
            elif c == '"': state, i = "code", i + 1
            else: i += 1
            continue
        if state == "char":
            if c == "\\": i += 2
            elif c == "'": state, i = "code", i + 1
            else: i += 1
            continue
    raise RuntimeError(f"unterminated method body: {name}")


def scan_identifiers(seg):
    out, i, state = [], 0, "code"
    while i < len(seg):
        c = seg[i]
        n = seg[i + 1] if i + 1 < len(seg) else ""
        if state == "code":
            if c == "/" and n == "/": state, i = "line_comment", i + 2; continue
            if c == "/" and n == "*": state, i = "block_comment", i + 2; continue
            if c == "@" and n == '"': state, i = "verbatim_string", i + 2; continue
            if c == '"': state, i = "string", i + 1; continue
            if c == "'": state, i = "char", i + 1; continue
            if c.isalpha() or c == "_":
                j = i + 1
                while j < len(seg) and (seg[j].isalnum() or seg[j] == "_"): j += 1
                prev = i - 1
                while prev >= 0 and seg[prev].isspace(): prev -= 1
                out.append((seg[i:j], prev >= 0 and seg[prev] == "."))
                i = j; continue
            i += 1; continue
        if state == "line_comment":
            if c in "\r\n": state = "code"
            i += 1; continue
        if state == "block_comment":
            if c == "*" and n == "/": state, i = "code", i + 2
            else: i += 1
            continue
        if state == "string":
            if c == "\\": i += 2
            elif c == '"': state, i = "code", i + 1
            else: i += 1
            continue
        if state == "verbatim_string":
            if c == '"' and n == '"': i += 2
            elif c == '"': state, i = "code", i + 1
            else: i += 1
            continue
        if state == "char":
            if c == "\\": i += 2
            elif c == "'": state, i = "code", i + 1
            else: i += 1
            continue
    return out


def transform(seg, mapping):
    out, counts, i, state = [], {old: 0 for old in mapping}, 0, "code"
    while i < len(seg):
        c = seg[i]
        n = seg[i + 1] if i + 1 < len(seg) else ""
        if state == "code":
            if c == "/" and n == "/": out.append("//"); state, i = "line_comment", i + 2; continue
            if c == "/" and n == "*": out.append("/*"); state, i = "block_comment", i + 2; continue
            if c == "@" and n == '"': out.append('@"'); state, i = "verbatim_string", i + 2; continue
            if c == '"': out.append(c); state, i = "string", i + 1; continue
            if c == "'": out.append(c); state, i = "char", i + 1; continue
            if c.isalpha() or c == "_":
                j = i + 1
                while j < len(seg) and (seg[j].isalnum() or seg[j] == "_"): j += 1
                token = seg[i:j]
                prev = i - 1
                while prev >= 0 and seg[prev].isspace(): prev -= 1
                qualified = prev >= 0 and seg[prev] == "."
                if token in mapping and not qualified:
                    out.append(mapping[token]); counts[token] += 1
                else: out.append(token)
                i = j; continue
            out.append(c); i += 1; continue
        out.append(c)
        if state == "line_comment":
            if c in "\r\n": state = "code"
            i += 1; continue
        if state == "block_comment":
            if c == "*" and n == "/": out.append(n); state, i = "code", i + 2
            else: i += 1
            continue
        if state == "string":
            if c == "\\" and i + 1 < len(seg): out.append(n); i += 2
            elif c == '"': state, i = "code", i + 1
            else: i += 1
            continue
        if state == "verbatim_string":
            if c == '"' and n == '"': out.append(n); i += 2
            elif c == '"': state, i = "code", i + 1
            else: i += 1
            continue
        if state == "char":
            if c == "\\" and i + 1 < len(seg): out.append(n); i += 2
            elif c == "'": state, i = "code", i + 1
            else: i += 1
            continue
    return "".join(out), counts


raw = PATH.read_bytes()
text = raw.decode("utf-8")
if text.encode("utf-8") != raw:
    raise RuntimeError("UTF-8 round-trip changed file bytes")

suffix_marker = "\tpublic static int TransferMatchingItemEntriesBetweenContainers"
suffix_pos = text.find(suffix_marker)
if suffix_pos < 0: raise RuntimeError("suffix marker not found")
baseline_suffix = text[suffix_pos:]

changes, total = [], 0
for method_name, mapping in METHODS.items():
    start, end = find_method_span(text, method_name)
    segment = text[start:end]
    ids = scan_identifiers(segment)
    collisions = {new: sum(1 for token, qualified in ids if token == new and not qualified) for new in mapping.values()}
    collisions = {k: v for k, v in collisions.items() if v}
    if collisions: raise RuntimeError(f"pre-existing semantic-name collision in {method_name}: {collisions}")
    transformed, counts = transform(segment, mapping)
    missing = [old for old, count in counts.items() if count == 0]
    if missing: raise RuntimeError(f"target tokens not found in {method_name}: {missing}")
    if segment[:segment.find("{")] != transformed[:transformed.find("{")]:
        raise RuntimeError(f"signature changed in {method_name}")
    subtotal = sum(counts.values())
    total += subtotal
    changes.append((start, end, transformed, method_name, counts, subtotal))

new_text = text
for start, end, transformed, _, _, _ in sorted(changes, key=lambda x: x[0], reverse=True):
    new_text = new_text[:start] + transformed + new_text[end:]

new_suffix_pos = new_text.find(suffix_marker)
if new_suffix_pos < 0 or new_text[new_suffix_pos:] != baseline_suffix:
    raise RuntimeError("suffix changed at or after TransferMatchingItemEntriesBetweenContainers")

for _, _, _, method_name, counts, subtotal in changes:
    print(f"{method_name}: {subtotal} replacements {counts}")
print(f"TOTAL_REPLACEMENTS={total}")
print(f"MODE={'APPLY' if APPLY else 'DRY_RUN'}")
print(f"CRLF={raw.count(b'\r\n')} LF={raw.count(b'\n')} BOM={raw.startswith(bytes([0xEF, 0xBB, 0xBF]))}")

if APPLY:
    PATH.write_bytes(new_text.encode("utf-8"))
    print("WRITE_OK")
