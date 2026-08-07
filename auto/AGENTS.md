# Auto Application

## Purpose

- Contains the decompiled/recovered C# source for the `JXOfflineAuto` Windows Forms application.
- Preserve runtime behavior while improving symbol names and source readability.

## Ownership

- `kykeoxe.csproj` defines the .NET Framework 4.0, x86 WinForms application.
- `ns151/Program.cs` contains the application entry point.
- `ns100` through `ns144` contain WinForms UI classes with paired `.resx` resources where present.
- `ns0` through `ns97`, `ns145` through `ns153`, and root-level structs/enums/config types contain decompiled application/support logic.
- Root-level embedded DLLs, signature files, `.resx`, and `Properties/AssemblyInfo.cs` are build/runtime assets and metadata.

## Local Contracts

- Treat all source changes as behavior-preserving refactors, not rewrites.
- Do not change algorithms, branch/loop conditions, processing order, exception behavior, network/database/protocol behavior, threading, timing, serialization formats, or public/external APIs unless required solely to keep a proven-safe rename compiling.
- Before renaming any symbol, search the entire project for references and inspect possible reflection, string-based lookup, serialization, attributes, resources, configuration, P/Invoke, and external/native dependencies.
- Prefer conservative descriptive names when semantics are uncertain; leave a decompiler-generated name unchanged rather than over-infer.
- Treat public top-level types and public members as external API/ABI unless project-wide evidence proves otherwise; do not rename them solely for readability.
- Rename `.cs` files only when the primary type rename is proven safe and update project/resource relationships where relevant.
- Keep paired WinForms `.resx` resource behavior intact; do not rename namespaces/forms/resources without validating resource lookup semantics.
- Preserve `try/catch/finally`, null checks, side effects, disposal, and unsafe/native interop semantics.
- Do not fix unrelated bugs or add/remove features during cleanup.
- Existing user changes outside this task must not be overwritten.

## Work Guidance

- Work in small rename/cleanup groups ordered by semantic confidence.
- Build after each major group; if a refactor breaks the build, repair all references before proceeding.
- Favor local/member renames and straightforward decompiler-artifact cleanup before risky namespace/form/resource renames.
- Keep a report of renamed files/types/members and symbols intentionally left unchanged due to insufficient context.

## Verification

- Baseline and post-change verification: build `auto/kykeoxe.csproj` with Visual Studio/full-framework `MSBuild.exe` plus a modern .NET SDK resolver for the SDK-style project. Do not use `dotnet build` for canonical verification while the project keeps legacy binary/non-string `.resx` resources, because modern .NET-hosted MSBuild cannot use the old .NET Framework resource embedding path.
- `.github/workflows/build.yml` is the canonical CI build: `windows-2022`, Visual Studio `MSBuild.exe`, Release, x86, `net40`, with the resulting binaries uploaded as `JXOfflineAuto-net40-x86`.
- Required target characteristics: `net40`, `x86`, Windows Forms, unsafe enabled.
- A refactor group is not complete while build errors attributable to that group remain.

## Child DOX Index

- No child DOX files are currently needed: each `ns*` folder is primarily a decompiler namespace container rather than a durable independent module boundary.
