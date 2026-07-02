# Security Policy

## Supported Versions

Playhead follows [Semantic Versioning](https://semver.org/). Security fixes are applied to the latest `1.x` release; we recommend always using the newest published version.

| Version | Supported          |
| ------- | ------------------ |
| 1.x     | :white_check_mark: |
| < 1.0   | :x:                 |

## Reporting a Vulnerability

If you discover a security vulnerability in Playhead, **please do not open a public GitHub issue**.

Instead, report it privately using one of the following channels:

1. **GitHub Private Security Advisories (preferred):** Open a report at [github.com/Taiizor/Playhead/security/advisories/new](https://github.com/Taiizor/Playhead/security/advisories/new). This creates a private discussion visible only to maintainers until a fix is ready.
2. **Direct contact:** Reach out to the maintainer via the contact details on the [@Taiizor GitHub profile](https://github.com/Taiizor).

Please include as much detail as possible:
- A description of the vulnerability and its potential impact.
- Steps to reproduce, including target framework(s) and Windows build affected.
- Any proof-of-concept code, if available.

### What to expect

- We aim to acknowledge new reports within **5 business days**.
- We will keep you updated as we investigate and work on a fix.
- Once a fix is released, we will publish a security advisory and credit the reporter (unless anonymity is requested).

## Scope

Playhead is a thin managed wrapper around Windows' internal `NowPlayingSessionManager` / System Media Transport Controls (SMTC) COM APIs. Vulnerabilities in the underlying Windows components themselves should be reported to Microsoft via the [Microsoft Security Response Center](https://msrc.microsoft.com/).