# 🎨 Asset List — Salvage Crew

> **Updated for USP differentiation.** The pure-Synty plan would have made the game read IDENTICALLY to Lethal Company / Content Warning / R.E.P.O. — all of which use POLYGON Sci-Fi Space. The Critic Board flagged this as a fatal USP risk. The new plan **drops Synty as the environment vendor entirely** and uses non-Synty modular sci-fi packs.
>
> See [`08_Visual_Identity.md`](08_Visual_Identity.md) for the full visual brief.
>
> Total ceiling: **~$200** (cheaper than the original $220 plan).

---

## Strategy

**Different vendor (non-Synty environment + Synty FX-only).** Visual reference is *Alien: Isolation × Hardspace: Shipbreaker × Subnautica*, **NOT** *Lethal Company*. Networking layer is unchanged.

---

## A. Environment & Props (NOT Synty — the USP differentiator)

| # | Asset | $ | Why |
|---|---|---|---|
| 1 | **Manufactura K4 — Sci-Fi Industrial / Modular Sci-Fi Series** | $30–60 | High-quality URP-ready PBR-low-poly. **Non-Synty visual language.** Industrial honesty. The primary environment vendor. |
| 2 | **NEXUS — Modular Sci-Fi Interior** OR **3DForge — Modular Sci-Fi** (pick one) | $30 | Wreck interior variety. Alien-Isolation-ish lighting. |
| 3 | **Quaternius — Industrial / Sci-Fi Kit** (CC0, free) | Free | Crates, valves, generic props as filler |

> ⚠️ We do **NOT** buy Synty POLYGON Sci-Fi Space. Using it would invite immediate "Lethal Company asset-flip" dismissal on r/Games and Steam. This is the #1 visual decision in the project.

## B. VFX (Synty here IS good differentiation)

| # | Asset | $ | Why |
|---|---|---|---|
| 4 | **Synty POLYGON ARSENAL** (FX pack only) | $40 | Distinctive sci-fi VFX (sparks, debris, explosions). The one Synty pack that **adds** identity rather than diluting it, because it sits on top of non-Synty meshes. |

## C. Characters

| # | Asset | $ | Why |
|---|---|---|---|
| 5 | **Custom EVA crew** (Fiverr commission ~$40 / character, or Mixamo + custom EVA helmet retopo) | $30–80 | Crew silhouette **MUST NOT** read as Lethal Company's space-tourist astronaut. Industrial salvager silhouette: bulky shoulders, work-belt, riot-helmet visor with single light strip. |
| 6 | **Mixamo animations** | Free | Walk/run/idle/carry/interact |
| 7 | **Quaternius Sci-Fi Creatures / Drones** (free, CC0) | Free | Mission 4 hostile drones |

## D. Networking

| # | Asset | $ | Why |
|---|---|---|---|
| 8 | **Mirror** (Asset Store) | Free | Networking |
| 9 | **Facepunch.Steamworks** (GitHub, MIT) | Free | Steam lobby + P2P |
| 10 | **FizzySteamworks** transport | Free | Mirror's Steam transport |

## E. Audio

| # | Asset | $ | Why |
|---|---|---|---|
| 11 | **Sci-Fi Industrial SFX Pack** (Cafofo / Hzandbits) | $25 | Hull, doors, alarms, breach |
| 12 | **Helmet Radio SFX Pack** | $15 | Push-to-talk voice effects |
| 13 | DIY VO / Fiverr | $50 | Captain logs + crew radio |

## F. VFX & Post (URP)

| # | Asset | $ | Why |
|---|---|---|---|
| 14 | URP Volumetric Fog (free Atmospheric Height Fog) | Free | Wreck atmosphere — critical for the Alien-Isolation lane |
| 15 | VFX Graph samples (Unity, free) | Free | Breach particles, sparks |

## G. Systems & Tooling

| # | Asset | $ | Why |
|---|---|---|---|
| 16 | Cinemachine, Timeline, Input System, Addressables, TMP | Free | Built-in |
| 17 | DOTween | Free | UI/material tweens |
| 18 | Odin Inspector (optional) | $55 | Faster inspector authoring |

---

## Subtotal

| Tier | Cost |
|---|---|
| **Must-have** | **~$200** (Manufactura K4 + NEXUS + POLYGON ARSENAL FX + custom EVA + audio) |
| Nice-to-have | +$55 (Odin Inspector) |
| **Recommended cap** | **~$200–255** |

---

## Licence Audit

| Asset | Licence |
|---|---|
| Manufactura K4 packs | Standard Asset Store EULA, commercial OK |
| NEXUS / 3DForge | Standard Asset Store EULA, commercial OK |
| Synty POLYGON ARSENAL | Commercial OK; do NOT commit raw assets |
| Quaternius | CC0 |
| Mirror | MIT |
| Facepunch.Steamworks | MIT |
| Mixamo | Free for commercial |
| Cafofo / Hzandbits SFX | Standard EULA, commercial OK |
| DOTween free | Free for any use |

## Asset Folder Layout

```
Assets/
├── _Project/             ← OUR code (committed)
├── Mirror/               ← Imported, NOT committed
├── ManufacturaK4/        ← Imported, NOT committed
├── NEXUS/                ← Imported, NOT committed
├── Synty/                ← ONLY POLYGON ARSENAL FX here, NOT committed
├── Quaternius/           ← Free CC0, may commit if desired (but skip to keep repo lean)
├── ThirdParty/           ← all other packs
└── Mixamo/               ← Imported, NOT committed
```

Add post-import to local `.gitignore`:
```
/unity-project/Assets/Mirror/
/unity-project/Assets/ManufacturaK4/
/unity-project/Assets/NEXUS/
/unity-project/Assets/Synty/
/unity-project/Assets/Mixamo/
/unity-project/Assets/ThirdParty/
```

## Buy Order

1. **Manufactura K4** ($30–60) — primary environment ROI
2. **Mirror + Facepunch.Steamworks** (free, immediate)
3. **Synty POLYGON ARSENAL** ($40) — VFX identity
4. **NEXUS or 3DForge** ($30) — wreck variety
5. **SFX + Helmet radio** ($40)
6. **Custom EVA character commission** ($30–80) — last, once design is locked

## Why This Beats Pure-Synty

| | Pure-Synty plan (rejected) | New plan (current) |
|---|---|---|
| Cost | ~$220 | **~$200** |
| Looks like Lethal Company? | ⚠️ **Yes — same pack** | ❌ No (different vendor entirely) |
| Looks like Alien Isolation / Shipbreaker? | ❌ No | ✅ Yes |
| Crew silhouette distinct? | ⚠️ Synty astronaut ≈ Lethal Company astronaut | ✅ Industrial-salvager EVA (commissioned) |
| First-impression USP win? | ❌ Steam shoppers dismiss as clone | ✅ Reads as different genre |
