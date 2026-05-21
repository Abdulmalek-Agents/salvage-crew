# 🛰 Salvage Crew

> *"The contract said: pull the black box and get out. The contract didn't say it was still warm."*

A 1–4 player co-op space-wreck salvage game built in **Unity 2022 LTS / URP** with **Mirror** networking and **Steam Lobbies**. PC-first. **Visual lane: Alien: Isolation × Hardspace: Shipbreaker × Subnautica — NOT Lethal Company.**

**Status:** Pre-production — Mission 1 vertical-slice skeleton.

---

## Concept (one-line)

A salvage crew lands on a derelict ship to complete a **contract** (Salvage / Rescue / Quarantine / Black-Box) under tightening time + O₂ pressure, fighting wreck-specific **hazards** (decompression, fires, contagion, hostile drones), then extracts. Loot → ship upgrades → harder contracts.

## Core Verb Loop

**Land → Split → Salvage → Survive → Extract → Upgrade → Next Contract**

## Vertical Slice — Mission 1

| | |
|---|---|
| Wreck | Cargo Hauler *Meridian* |
| Contract | **Salvage** (retrieve 5 cargo crates + deliver to lander) |
| Length | 25 min solo / 35 min 4-player |
| Crew | 1–4 (drop-in/drop-out, P2P via Mirror + Steam Lobby) |
| Hazard | Decompression breaches + low-grav zones |
| Win | Crates delivered + crew extracted |
| Lose | All crew incapacitated **or** O₂ depleted on the lander |

Mission 1 ships with **all systems** required for Missions 2–5. Pure data-driven.

---

## 📁 Documents

| File | Purpose |
|---|---|
| [`docs/01_Creative_Vision.md`](docs/01_Creative_Vision.md) | Creative Director's pitch |
| [`docs/02_GDD.md`](docs/02_GDD.md) | Full Game Design Document |
| [`docs/03_Mission1_Design.md`](docs/03_Mission1_Design.md) | Mission 1 wreck breakdown |
| [`docs/04_Asset_List.md`](docs/04_Asset_List.md) | Unity Asset Store shopping list (~$200) |
| [`docs/05_Architecture.md`](docs/05_Architecture.md) | Code architecture (including Mirror netcode) |
| [`docs/06_Mission_Scalability_Matrix.md`](docs/06_Mission_Scalability_Matrix.md) | 5-mission roadmap |
| [`docs/07_Setup_Instructions.md`](docs/07_Setup_Instructions.md) | Clone → buy assets → press Play |
| [`docs/08_Visual_Identity.md`](docs/08_Visual_Identity.md) | **Visual brief & USP differentiation (non-Synty environment)** |

---

## 🛠 Setup (TL;DR)

1. **Clone:** `git clone https://github.com/Abdulmalek-Agents/salvage-crew.git`
2. **Open `unity-project/`** in Unity Hub. Unity will install version **2022.3.40f1 LTS**.
3. **Buy & import assets** (see [`docs/04_Asset_List.md`](docs/04_Asset_List.md)).
4. **Install Mirror + Facepunch.Steamworks** (steps in `07_Setup_Instructions.md` §4).
5. Follow [`docs/07_Setup_Instructions.md`](docs/07_Setup_Instructions.md) §5 to wire prefabs.
6. Press Play on `Assets/_Project/Scenes/Mission01_Meridian.unity` — host a lobby and connect a second instance.

All C# is written and committed. Your only manual work is buying assets, dragging prefabs into wiring slots, and pressing Play.

---

## 🧱 Tech Stack

- Unity 2022.3.40f1 LTS
- URP 14.x
- **Mirror** networking (free)
- **Facepunch.Steamworks** (free) for lobby + transport
- TextMesh Pro, Cinemachine, Timeline, Input System
- Addressables for wreck loading
- ScriptableObject-driven contract & hazard system
- **Manufactura K4 / NEXUS PBR-low-poly environment** (non-Synty) for visual USP

## 📜 Licence

Code: MIT. Asset Store assets remain under their original licences.
