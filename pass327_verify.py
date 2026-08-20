import ast
import subprocess
from pathlib import Path

script = Path("pass327_apply.py").read_text(encoding="utf-8")
tree = ast.parse(script)
keep = []
for node in tree.body:
    if isinstance(node, (ast.Import, ast.ImportFrom, ast.FunctionDef)):
        keep.append(node)
    elif isinstance(node, ast.Assign):
        names = {t.id for t in node.targets if isinstance(t, ast.Name)}
        if names & {"METHODS", "DECL_PREFIX"}:
            keep.append(node)
ns = {}
exec(compile(ast.Module(body=keep, type_ignores=[]), "pass327_apply_subset", "exec"), ns)

METHODS = ns["METHODS"]
find_method_span = ns["find_method_span"]
scan_identifiers = ns["scan_identifiers"]
transform = ns["transform"]

baseline_bytes = subprocess.check_output(["git", "show", "HEAD:auto/ns44/InventoryItemHelper.cs"])
current_bytes = Path("auto/ns44/InventoryItemHelper.cs").read_bytes()
baseline = baseline_bytes.decode("utf-8")
current = current_bytes.decode("utf-8")

changes = []
total = 0
for method_name, mapping in METHODS.items():
    start, end = find_method_span(baseline, method_name)
    segment = baseline[start:end]
    transformed, counts = transform(segment, mapping)
    if any(count == 0 for count in counts.values()):
        raise RuntimeError(f"baseline target missing in {method_name}: {counts}")
    if segment[:segment.find("{")] != transformed[:transformed.find("{")]:
        raise RuntimeError(f"baseline signature would change in {method_name}")
    changes.append((start, end, transformed))
    total += sum(counts.values())

expected = baseline
for start, end, transformed in sorted(changes, key=lambda x: x[0], reverse=True):
    expected = expected[:start] + transformed + expected[end:]

if expected.encode("utf-8") != current_bytes:
    raise RuntimeError("exact forward reconstruction from HEAD does not match working file")

for method_name, mapping in METHODS.items():
    start, end = find_method_span(current, method_name)
    ids = scan_identifiers(current[start:end])
    stale = {old: sum(1 for token, qualified in ids if token == old and not qualified) for old in mapping}
    stale = {k: v for k, v in stale.items() if v}
    if stale:
        raise RuntimeError(f"stale targeted identifiers in {method_name}: {stale}")

marker = "\tpublic static int TransferMatchingItemEntriesBetweenContainers"
base_pos = baseline.find(marker)
cur_pos = current.find(marker)
if base_pos < 0 or cur_pos < 0 or baseline[base_pos:] != current[cur_pos:]:
    raise RuntimeError("suffix changed")

print(f"EXACT_RECONSTRUCTION=PASS replacements={total}")
print("STALE_TARGETED=0")
print("SIGNATURES_UNCHANGED=PASS")
print("SUFFIX_UNCHANGED=PASS")
print(f"CURRENT_BYTES={len(current_bytes)}")
