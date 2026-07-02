## Description

<!-- Describe what this PR changes and why. -->

## Related Issue

<!-- Fixes #123 -->

## Type of Change

- [ ] Bug fix (non-breaking change which fixes an issue)
- [ ] New feature (non-breaking change which adds functionality)
- [ ] Breaking change (fix or feature that would cause existing functionality to not work as expected)
- [ ] Documentation update
- [ ] CI / tooling change

## Checklist

- [ ] I have read the [CONTRIBUTING](../CONTRIBUTING.md) guide.
- [ ] `dotnet build src/Playhead/Playhead.csproj -c Release` succeeds across the full target framework matrix.
- [ ] I have added/updated XML documentation comments for new or changed public APIs.
- [ ] If I touched a native-interop struct (`[StructLayout(LayoutKind.Sequential)]`), I verified the field layout still matches the native COM struct (see [CONTRIBUTING.md](../CONTRIBUTING.md#working-with-the-native-interop-layer)).
- [ ] I have updated the [CHANGELOG](../CHANGELOG.md) under `[Unreleased]`, if applicable.

## Additional Notes

<!-- Anything reviewers should pay special attention to. -->