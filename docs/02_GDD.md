# 🗺️ Game Design Document — Salvage Crew

**Version:** 1.0 (approved by Critic Board)
**Author:** Game & Level Designer
**Status:** Locked for Mission 1 implementation

---

## 1. Game Summary

- **Genre:** Co-op space-wreck salvage survival
- **Players:** 1–4 (drop-in/drop-out, Steam P2P)
- **Mission length:** 25–35 min
- **Platform:** PC primary (Steam)
- **Engine:** Unity 2022.3.40f1 LTS, URP, Mirror networking
- **Save model:** Persistent crew currency + ship upgrades; per-mission state is volatile

## 2. Core Loop

```
Lander Hub  ── pick contract ──▶  Land on Wreck
     ▲                                  │
     │                                  ▼
  Upgrade  ◀── Currency  ◀── Extract  ◀── Complete Contract Objective
                                     ▲           │
                                     │           ▼
                                  Crew  ◀── Survive Hazards
```

## 3. Contract Types

| Type | Objective | Unique Twist | Fail State |
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
| Push-to-talk | V / RB (radio range) |
| Helmet light | T / Y |
| Scanner | RMB / LT |
| Map ping | G / R3 |

### Crew Stats (per session)
- **Health:** 100. Hazards damage over time.
- **Oxygen:** 100% on board lander, drains in wreck (rate depends on suit upgrade).
- **Inventory slots:** 2 by default, 3-4 via upgrades.
- **Helmet light battery:** drains; recharges only on lander.

## 5. Hazards (Mission 1 active, others scaffolded)

| Hazard | Behaviour | Counter |
|---|---|---|
| **Decompression breach** | Hull section punctures, sucks crew + crates toward breach, drains O₂ | Patch kit (consumable) or seal valve |
| **Electrical fire** | Damage zone, spreads slowly | Extinguisher pickup or shut valve |
| **Low-gravity zone** | Movement floaty, easier to fling off | Magnetic boots upgrade |
| **Contagion (M3)** | Crew infection meter, debuffs | Antibiotic injector |
| **Hostile drone (M4)** | Patrols, alarms summon more | EMP grenade / hide |

## 6. Lander & Extraction

- Lander = persistent crew hub. Stores upgrade panels, refill stations, contract terminal.
- During mission, lander has a **departure window** (radioed via contract). Player can extend (cost fuel).
- Extraction = step onto lander + close airlock. All crew not aboard at takeoff are **left behind** (lose inventory + die at next disaster tick).

## 7. Difficulty Tuning (`DifficultyProfile` SO)

Scales by **crew size**:
- O₂ drain rate
- Hazard tick speed
- Loot value multiplier (rewards solo runs slightly)
- Number of drones / contagion spread rate

Mission 1 ships with `Difficulty_Normal` for both solo and 4-player runs.

## 8. Persistence

| Data | Scope |
|---|---|
| Crew Currency (Scrip) | Persistent profile |
| Ship Upgrades | Persistent profile |
| Mission counter | Persistent profile |
| Active contract state | Volatile (host only) |

No mid-mission saving — failed runs lose mission rewards but not profile progress.

## 9. UI

- **HUD:** O₂ %, Health bar, Inventory slots, Compass to lander, Crewmate indicators (off-screen arrows).
- **Tablet (E hold):** Contract objective, wreck map (revealed by walking).
- **End screen:** Survivors, items extracted, scrip earned, upgrades unlocked.

## 10. Networking

- **Mirror, host-authoritative.** Host runs `ContractManager`, `HazardSystem`, all NPC + drone state.
- **CrewMember** = `NetworkBehaviour` with `NetworkTransform`.
- **NetworkedInteractable** = anything (crate, valve, panel) syncs ownership via `[Command]` calls.
- **Voice:** out of scope for v0.1 (use Steam voice or Discord); we expose a `PushToTalk` event hook for future integration.
- **Solo mode:** Local lobby of size 1; same code path, no transport overhead.

## 11. Accessibility

- Subtitles for all radio chatter and audio logs.
- Colourblind palette for O₂ / health bars.
- Toggle for hold-to-sprint.
- Camera shake/headbob toggle.
- Aim assist for scanner on gamepad.

## 12. Risks & Mitigations

| Risk | Mitigation |
|---|---|
| Netcode complexity | Mirror is mature, host-authoritative, no relays needed (Steam transport handles NAT) |
| Solo run feels dead without crew banter | Lander AI co-pilot lines + sound design |
| 25 min too short | Replayable: random hazard seeds, contract variations |
| Players desync on hazard | Authoritative host, snapshot interpolation, no client-side hazard sim |

## 13. Critic Board Sign-Off

✅ Approved with Notes addressed in Round 3.
