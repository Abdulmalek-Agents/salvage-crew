# Architecture — Salvage Crew

> Designed by the Senior Unity Developer for a 1-4 player co-op that ships solo *and* networked from the same codebase.

## 1. Pillars

1. **Data-driven** — every tunable in a ScriptableObject.
2. **Host-authoritative networking via Mirror** — host simulates, clients render.
3. **Event-driven within a process** — ScriptableObject event channels for local UI/audio; explicit [SyncVar]/[Command]/[ClientRpc] for net sync.
4. **Drop-in / drop-out** — same code runs solo (lobby of 1) and 4-player.
5. **Service Locator** for non-networked services.
6. **URP, performance-conscious.**

## 2. Layer Diagram

```
[ BOOT / MENU ]   Bootstrap, ServiceLocator, MainMenu, Lobby
        v
[ NETWORK ]       NetworkManager_Salvage, Steam transport, CrewMember,
                  NetworkedInteractable, NetworkedHazard
        v
[ MISSION ]       ContractManager, WreckLoader, HazardSystem, ExtractionPad
        v
[ GAMEPLAY ]      CrewMember, OxygenSystem, InventorySystem,
                  InteractionSystem, LootCrate, ValvePanel
        v
[ INFRA ]         EventChannels, ObjectPool, AudioManager,
                  InputReader, SaveSystem, AddressablesLoader, UIController
```

## 3. ScriptableObject Data Layer

| SO | Fields |
|---|---|
| ContractData | id, type (Salvage/Rescue/Quarantine/BlackBox/Hybrid), wreck, payout, hazardProfile |
| WreckData | id, displayName, sceneAddressable |
| HazardProfile | breachIntensity, tickRate, lowGravStrength, fireSpread, contagionRate, drones |
| LootItemData | id, displayName, weight, scripValue, slotSize |
| ShipUpgradeData | id, displayName, cost, effect (enum), value |
| DifficultyProfile | global multipliers (o2 drain, hazard tick, loot scrip) |
| *EventChannel | SO event channels |

## 4. Networking — Mirror

- NetworkManager_Salvage extends Mirror.NetworkManager. Configures Steam P2P transport.
- CrewMember : NetworkBehaviour holds [SyncVar] health, oxygen, inventory, isIncapacitated.
- NetworkedInteractable base class. Pickup calls [Command] to request ownership.
- Hazards live on host only and broadcast state changes through [ClientRpc].
- Voice chat deferred (PushToTalk event hook exposed).

### Sync surface (Mission 1)

| Entity | What syncs |
|---|---|
| CrewMember position | NetworkTransform, interpolation on |
| Crate pickup/drop | Command/Rpc via NetworkedInteractable |
| Valve state | [SyncVar(hook)] |
| Breach hazard | Host-driven, [ClientRpc] for VFX, sound, force pulse |
| Lander state | [SyncVar] countdown, doors |

## 5. Service Locator (non-networked only)

- AudioManager
- SaveSystem
- UIController
- AddressablesLoader

## 6. Save System

- PersistentProfile: scrip, owned upgrades, mission counter, settings.
- Volatile: mission state, host-only.
- Triggers: lobby return after mission ends.

## 7. Addressables

- Wrecks (Mission01_Meridian.unity etc.) as Addressable groups.
- Audio logs as Addressable AudioClips.
- Hazard prefabs Addressable.

## 8. Performance Budgets

| Target | Value |
|---|---|
| Min spec | GTX 1050 / 8 GB RAM |
| Frame target | 60 fps @ 1080p high |
| Draw calls | < 1200 |
| Tris on screen | < 800k |
| Texture memory | < 1 GB |
| Lights | 1 baked directional + light probes + <= 8 realtime point per room |
| Network tick | 30 Hz |
| Network bandwidth | <= 32 kbps per client |

## 9. Folder Layout

```
Assets/_Project/
+-- Scripts/
|   +-- Core/         (Bootstrap, ServiceLocator, EventChannels, ObjectPool)
|   +-- Networking/   (NetworkManager_Salvage, NetworkedInteractable, CrewNet)
|   +-- Player/       (CrewMember, InputReader, OxygenSystem, InventorySystem)
|   +-- Interaction/  (InteractionSystem, LootCrate, ValvePanel, ExtractionPad)
|   +-- Hazards/      (HazardSystem, BreachHazard, LowGravityZone, ValveBreachLink)
|   +-- Contracts/    (ContractManager)
|   +-- Mission/      (WreckLoader)
|   +-- Data/         (ScriptableObject definitions)
|   +-- UI/           (HUDController, LobbyUI)
|   +-- Audio/        (AudioManager)
|   +-- Save/         (SaveSystem, ShipUpgradeManager)
+-- Scenes/
+-- Prefabs/
+-- Data/
+-- Materials/
+-- Audio/
```

## 10. Test Strategy

- Unit: pure C# tests for HazardSystem tick, OxygenSystem drain.
- Play-mode smoke: host alone -> boards Meridian -> picks 1 crate -> extracts.
- Net smoke: host + 1 client local; both pick crates; trigger breach; extract.

## 11. Critic Board Review

Approved. Mirror selection mitigates the netcode risk flagged in Round 2.
