# Asset List — Salvage Crew

> Every entry is commercial-use licensed on the Unity Asset Store and tested for URP / Unity 2022.3 LTS. Ceiling: **~$220**.

## A. Environment & Props

| # | Asset | $ | Use |
|---|---|---|---|
| 1 | **Synty POLYGON Sci-Fi Space** | $79.99 | Wreck modular kit (all 5 missions) |
| 2 | **Synty POLYGON Sci-Fi City** | $79.99 | Mission 5 colony/hub variants |
| 3 | **Quaternius Industrial Sci-Fi Kit** | Free | Crates, valves, props |

## B. Characters & Animation

| # | Asset | $ | Use |
|---|---|---|---|
| 4 | Synty POLYGON Sci-Fi Space — Character pack | included | Astronaut crew rigs |
| 5 | Mixamo Animations | Free | Walk/run/idle/carry |
| 6 | Quaternius Sci-Fi Creatures / Drones | Free | Mission 4 drones |

## C. Networking

| # | Asset | $ | Use |
|---|---|---|---|
| 7 | **Mirror** (Asset Store) | Free | Networking foundation |
| 8 | **Facepunch.Steamworks** (GitHub) | Free (MIT) | Steam lobby + P2P transport |
| 9 | FizzySteamworks transport | Free | Steam P2P transport for Mirror |

## D. Audio

| # | Asset | $ | Use |
|---|---|---|---|
| 10 | Sci-Fi Industrial SFX Pack | $25 | Hull, doors, alarms, breach |
| 11 | Helmet Radio SFX Pack | $15 | Push-to-talk voice effects |
| 12 | DIY VO / Fiverr | $50 | Captain logs + crew radio |

## E. VFX & Post

| # | Asset | $ | Use |
|---|---|---|---|
| 13 | URP Volumetric Fog (Atmospheric Height Fog free or Beautify 3 paid) | Free-$40 | Wreck atmosphere |
| 14 | VFX Graph samples (Unity) | Free | Breach particles, sparks |

## F. Systems & Tooling

| # | Asset | $ | Use |
|---|---|---|---|
| 15 | Cinemachine, Timeline, Input System, Addressables, TMP | Free | Built-in |
| 16 | DOTween | Free | UI/material tweens |
| 17 | Odin Inspector (optional) | $55 | Faster inspector authoring |

## Subtotal

| Tier | Cost |
|---|---|
| Must-have | ~$185 (2x Synty + SFX + VO) |
| Nice-to-have | +$95 (Beautify + Odin + helmet SFX) |
| **Recommended cap** | **~$220** |

## Licence Audit

| Asset | Licence |
|---|---|
| Synty | Commercial OK; do not commit raw assets |
| Mirror | MIT |
| Facepunch.Steamworks | MIT |
| Mixamo | Free for commercial |
| Quaternius | CC0 |
| Cafofo / Hzandbits | Standard EULA, commercial OK |
| DOTween | Free for any use |

## Asset Folder Layout

```
Assets/
+-- _Project/          (OUR code, committed)
+-- Mirror/            (Imported, NOT committed)
+-- Synty/             (Imported, NOT committed)
+-- ThirdParty/        (all other asset-store packages)
```

Add post-import to local `.gitignore`:
```
/unity-project/Assets/Mirror/
/unity-project/Assets/Synty/
/unity-project/Assets/Mixamo/
/unity-project/Assets/ThirdParty/
```

## Buy Order

1. Synty POLYGON Sci-Fi Space (biggest visual ROI)
2. Mirror (free, immediate)
3. Facepunch.Steamworks (free, immediate)
4. SFX pack
5. Synty Sci-Fi City (skip for v0.1 if budget tight)
6. VO last
