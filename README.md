# Salvage Crew

> *The contract said: pull the black box and get out. The contract didn't say it was still warm.*

A 1-4 player co-op space-wreck salvage game built in **Unity 2022 LTS / URP** with **Mirror** networking and **Steam Lobbies**. PC-first.

**Status:** Pre-production — Mission 1 vertical-slice skeleton.

## Concept (one-line)

A salvage crew lands on a derelict ship to complete a **contract** (Salvage / Rescue / Quarantine / Black-Box) under tightening time + O2 pressure, fighting wreck-specific **hazards** (decompression, fires, contagion, hostile drones), then extracts. Loot → ship upgrades → harder contracts.

## Core Verb Loop

**Land → Split → Salvage → Survive → Extract → Upgrade → Next Contract**

## Vertical Slice — Mission 1

| | |
|---|---|
| Wreck | Cargo Hauler *Meridian* |
| Contract | **Salvage** (retrieve 5 cargo crates + deliver to lander) |
| Length | 25 min solo / 35 min 4-player |
| Crew | 1-4 (drop-in/drop-out, P2P via Mirror + Steam Lobby) |
| Hazard | Decompression breaches + low-grav zones |
| Win | Crates delivered + crew extracted |
| Lose | All crew incapacitated **or** O2 depleted on the lander |

Mission 1 ships with **all systems** required for Missions 2-5. Pure data-driven.

## Documents

- [`docs/01_Creative_Vision.md`](docs/01_Creative_Vision.md)
- [`docs/02_GDD.md`](docs/02_GDD.md)
- [`docs/03_Mission1_Design.md`](docs/03_Mission1_Design.md)
- [`docs/04_Asset_List.md`](docs/04_Asset_List.md) (~$220 budget)
- [`docs/05_Architecture.md`](docs/05_Architecture.md)
- [`docs/06_Mission_Scalability_Matrix.md`](docs/06_Mission_Scalability_Matrix.md)
- [`docs/07_Setup_Instructions.md`](docs/07_Setup_Instructions.md)

## Setup (TL;DR)

1. `git clone https://github.com/Abdulmalek-Agents/salvage-crew.git`
2. Open `unity-project/` in Unity Hub (2022.3.40f1 LTS).
3. Buy & import assets per `docs/04_Asset_List.md`.
4. Install **Mirror + Facepunch.Steamworks** per `docs/07_Setup_Instructions.md` §4.
5. Wire prefabs per §5.
6. Press Play on `Mission01_Meridian.unity`.

All C# is written. Solo lobby works without Mirror. Coop needs Mirror.

## Tech Stack

- Unity 2022.3.40f1 LTS
- URP 14.x
- Mirror (free) + Facepunch.Steamworks (free)
- TextMesh Pro, Cinemachine, Timeline, Input System
- Addressables

## Licence

Code: MIT. Asset Store assets remain under their original licences.
