# Mission Scalability Matrix — Salvage Crew

Mission 1 ships with **all systems**. Missions 2-5 require **no new core code** — only:
- New ContractData ScriptableObject
- New WreckData (scene Addressable + display)
- New HazardProfile tuning
- (Optional) one new ScriptableObject hazard subtype per mission

| # | Wreck | Contract Type | New Tuning | New Hazards |
|---|---|---|---|---|
| 1 | Cargo Hauler *Meridian* | **Salvage** | Base profile | Breach + Low-Grav |
| 2 | Medical Frigate *Pharos* | **Rescue** | NPC escort speed | Breach + Fire |
| 3 | Research Vessel *Argus* | **Quarantine** | Contagion rate | Contagion zones |
| 4 | Military Destroyer *Vengeance* | **Black-Box** | Drone aggro | Hostile drones |
| 5 | Unknown Hulk *Origin* | **Hybrid** | Stacked | All hazards layered |

## Authoring a New Mission (no code)

1. Right-click → Create → SalvageCrew → WreckData_MissionXX.
2. Right-click → Create → SalvageCrew → ContractData_MissionXX.
3. Right-click → Create → SalvageCrew → HazardProfile_MissionXX.
4. Reference them from ContractDatabase SO.
5. Build a new Addressable wreck scene (greybox + Synty dress).
6. Mission appears in the lobby Contract Terminal.

## Per-Mission Estimate

| Task | Hours |
|---|---|
| Greybox new wreck | 10 |
| Asset dress | 12 |
| Configure SOs | 1 |
| Wire any new hazard subtype | 3 (if any) |
| Audio logs | 3 |
| Polish | 6 |
| Net smoke pass | 2 |
| **Total** | **~37 hrs/mission after #1** |

Mission 1 is ~56 hrs because every system is built; later missions amortise.
