# Setup Instructions — Salvage Crew

> *From `git clone` to hosting a Steam lobby.*

## §1 — Prerequisites

| Tool | Version |
|---|---|
| Unity Hub | latest |
| Unity Editor | **2022.3.40f1 LTS** |
| Steam client | running, logged in |
| (Optional) Two PCs or two Steam accounts | to test networking |

## §2 — Clone & Open

```bash
git clone https://github.com/Abdulmalek-Agents/salvage-crew.git
cd salvage-crew
```

In Unity Hub → Open → Add project from disk → select `salvage-crew/unity-project/`.

First open compiles in 3-8 min. You will see errors about missing Mirror namespaces — that's expected until §4 (everything else compiles thanks to the `#if MIRROR` guards).

## §3 — Buy & Import Asset Store Content

See `04_Asset_List.md`. Import:

1. Synty POLYGON Sci-Fi Space
2. Mixamo animations (FBX)
3. Sci-Fi Industrial SFX

## §4 — Install Networking (Mirror + Facepunch.Steamworks)

### 4.1 Mirror
1. **Window → Asset Store → search "Mirror"** by Mirror Networking → Add to My Assets → **Import**.
2. Verify `Assets/Mirror/` exists.
3. Open **Edit → Project Settings → Player → Scripting Define Symbols** → add `MIRROR`.

### 4.2 Facepunch.Steamworks
1. Download the latest release `.unitypackage` from https://github.com/Facepunch/Facepunch.Steamworks/releases
2. **Assets → Import Package → Custom Package** → select it.
3. Place a `steam_appid.txt` with `480` (Spacewar test app id) in the project root for development.

### 4.3 Steam Transport for Mirror
1. Clone https://github.com/Chykary/FizzySteamworks into `Assets/ThirdParty/FizzySteamworks/`.
2. On the `NetworkManager_Salvage` GameObject, assign Transport = FizzySteamworks.

> If you only want to test locally (no Steam), use the default `KcpTransport`. The provided `NetworkManager_Salvage.cs` works with either.

## §5 — Wire Prefabs

### 5.1 Master Prefabs

| Prefab | Build from |
|---|---|
| `CrewMember` | Synty astronaut + `NetworkIdentity`, `NetworkTransform`, `CrewMember.cs`, `OxygenSystem.cs`, `InventorySystem.cs`, `InteractionSystem.cs` |
| `LootCrate` | Crate mesh + `NetworkIdentity`, `LootCrate.cs`, `NetworkedInteractable.cs` |
| `ValvePanel` | Valve mesh + `NetworkIdentity`, `ValvePanel.cs` |
| `BreachHazard` | Empty + `NetworkIdentity`, `BreachHazard.cs` + child VFX |
| `LowGravityZone` | Trigger volume + `LowGravityZone.cs` |
| `ExtractionPad` | Trigger + `ExtractionPad.cs` |
| `Lander` | Lander mesh + child upgrade terminals |
| `BootstrapManagers` | Empty + `Bootstrap.cs` + children `AudioManager`, `SaveSystem`, `UIController` |
| `NetworkManager` | Empty + `NetworkManager_Salvage.cs` + Transport |

### 5.2 ScriptableObject Instances

- `WreckData_Meridian`
- `ContractData_M01_Salvage`
- `HazardProfile_M01`
- `Difficulty_Normal`
- LootItem instances x5
- ShipUpgradeData instances (O2 Tank, Mag Boots, +1 Slot)
- Event channels: `OnCrateDelivered`, `OnHazardActivated`, `OnCrewDown`, `OnExtractionStarted`, `OnExtractionComplete`, `OnContractFailed`, `OnAudioLogRequested`, `OnOxygenChanged`, `OnContractProgress`, `OnDepartureCountdown`, `OnValveToggled`, `OnCrewOnPadChanged`.

### 5.3 Build the Mission Scene

Open `Mission01_Meridian.unity`.
- Replace blockouts with Synty modular pieces.
- Place Lander at airlock.
- Place LootCrate x5 (2 in Bay A, 2 in Hold B, 1 in Hold C).
- Place ValvePanel x2 (Hold B + Med Bay).
- Place BreachHazard (disabled by default, activated by ValveBreachLink hook).
- Place LowGravityZone in Deck 2 spine.
- Place ExtractionPad on lander.

### 5.4 NavMesh & Lighting

- Window → AI → Navigation → Bake
- Window → Rendering → Lighting → Generate Lighting (Mixed)

## §6 — Press Play (Solo)

1. Open scene `01_MainMenu`.
2. Press Play → **Host Lobby (Solo)** → spawns you alone on Meridian.
3. Walk, pick a crate, return to lander, extract.

## §7 — Press Play (Co-op)

### Local two-instance (no Steam):
1. Build standalone via **File → Build Settings → Build**.
2. Run the exe → Host Lobby (KCP transport, local IP).
3. From the Editor → Join Lobby → enter `127.0.0.1`.

### Steam P2P:
1. Both PCs must have Steam running.
2. Host: Main Menu → Host Lobby → Steam.
3. Friend: invite via Steam friends overlay.
4. Host launches mission → friend auto-loads into Meridian.

## §8 — Build a PC EXE

1. **File → Build Settings → PC, Mac & Linux Standalone** (Windows x64).
2. Scenes in order: `00_Bootstrap`, `01_MainMenu`, `02_Lobby`, `Mission01_Meridian`.
3. **Player Settings → Other Settings → Scripting Backend = IL2CPP** for release.
4. Build → output to `/Builds/SalvageCrew_PC/`.

## §9 — Troubleshooting

| Symptom | Fix |
|---|---|
| Mirror namespace not found | Step §4.1 not completed, or MIRROR define not added |
| Steamworks not initialised | `steam_appid.txt` missing, or Steam not running |
| Client desynced after pickup | Verify NetworkIdentity + NetworkTransform on the crate |
| Magenta materials on Synty | Window → Rendering → Render Pipeline Converter |
| Breach VFX missing on client | Add BreachHazard prefab to NetworkManager spawn list |

If a script logs an error on Awake, read its log line.
