# Game Design Document — Salvage Crew

**Version:** 1.0 (approved by Critic Board)
**Author:** Game & Level Designer
**Status:** Locked for Mission 1 implementation

## 1. Game Summary

- **Genre:** Co-op space-wreck salvage survival
- **Players:** 1-4 (drop-in/drop-out, Steam P2P)
- **Mission length:** 25-35 min
- **Platform:** PC primary (Steam)
- **Engine:** Unity 2022.3.40f1 LTS, URP, Mirror networking
- **Save model:** Persistent crew currency + ship upgrades; per-mission state is volatile

## 2. Core Loop

```
Lander Hub  -- pick contract --> Land on Wreck
     ^                                  |
     |                                  v
  Upgrade  <-- Currency <-- Extract <-- Complete Contract
                                ^               |
                                |               v
                              Crew <-- Survive Hazards
```

## 3. Contract Types

| Type | Objective | Twist | Fail State |
|---|---|---|---|
| **Salvage** | Retrieve N crates / parts | Cargo weight slows player | Crates lost in breach |
| **Rescue** | Find + escort N NPCs to lander | NPCs panic, slow movement | NPCs die in hazard |
| **Quarantine** | Reach core + flush contamination | Contagion timer on crew | Timer expires |
| **Black-Box** | Hack + retrieve flight recorder | Hostile drones active | Drone alarm summons more |
| **Hybrid** (mission 5) | Combination | Stacks all systems | Multi-fail |

Mission 1 implements **Salvage**. System scaffolds for all five.

## 4. Crew Mechanics

| Verb | Input |
|---|---|
| Move | WASD / Left stick |
| Look | Mouse / Right stick |
| Sprint | Shift / L3 |
| Crouch | Ctrl / B |
| Interact | E / A |
| Pick up / drop | F / X |
| Push-to-talk | V / RB |
| Helmet light | T / Y |
| Scanner | RMB / LT |
| Map ping | G / R3 |

### Crew Stats
- Health 100 (hazards damage over time)
- Oxygen 100% (drains in wreck)
- Inventory slots 2 (3-4 via upgrades)
- Helmet light battery (drains, recharges on lander)

## 5. Hazards (Mission 1 active, others scaffolded)

| Hazard | Behaviour | Counter |
|---|---|---|
| **Decompression breach** | Hull section punctures, sucks crew + crates toward breach, drains O2 | Patch kit or seal valve |
| **Electrical fire** | Damage zone, spreads slowly | Extinguisher pickup or shut valve |
| **Low-gravity zone** | Movement floaty | Magnetic boots upgrade |
| **Contagion (M3)** | Crew infection meter, debuffs | Antibiotic injector |
| **Hostile drone (M4)** | Patrols, alarms summon more | EMP grenade / hide |

## 6. Lander & Extraction

- Lander = persistent crew hub. Upgrade panels, refill stations, contract terminal.
- Departure window radioed via contract. Player can extend (cost fuel).
- Extraction = step onto lander + close airlock. Crew not aboard at takeoff are left behind.

## 7. Difficulty Tuning (DifficultyProfile SO)

Scales by crew size: O2 drain rate, hazard tick speed, loot value, drone count.

Mission 1 ships with Difficulty_Normal for both solo and 4-player.

## 8. Persistence

| Data | Scope |
|---|---|
| Crew Currency (Scrip) | Persistent profile |
| Ship Upgrades | Persistent profile |
| Mission counter | Persistent profile |
| Active contract state | Volatile (host only) |

No mid-mission saving — failed runs lose mission rewards but not profile progress.

## 9. UI

- HUD: O2 %, Health bar, Inventory slots, Compass to lander, Crewmate indicators.
- Tablet (E hold): Contract objective, wreck map.
- End screen: Survivors, items extracted, scrip earned.

## 10. Networking

- Mirror, host-authoritative. Host runs ContractManager, HazardSystem, NPC/drone state.
- CrewMember = NetworkBehaviour with NetworkTransform.
- NetworkedInteractable = syncs ownership via [Command].
- Voice deferred for v0.1.
- Solo mode: same code path, no transport overhead.

## 11. Accessibility

- Subtitles, colourblind palette, hold-to-sprint toggle, headbob toggle, gamepad aim-assist for scanner.

## 12. Risks & Mitigations

| Risk | Mitigation |
|---|---|
| Netcode complexity | Mirror is mature, host-authoritative |
| Solo run feels dead | Lander AI co-pilot lines |
| 25 min too short | Replayable: random hazard seeds, contract variations |
| Players desync on hazard | Authoritative host, snapshot interpolation |

## 13. Critic Board Sign-Off

Approved.
