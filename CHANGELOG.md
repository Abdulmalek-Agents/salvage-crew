# Changelog

All notable changes to **Salvage Crew** are documented here. Follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## [Unreleased]

### Changed
- **Visual strategy pivoted to non-Synty environment** (post Critic Board re-review).
  - `docs/04_Asset_List.md`: **dropped Synty POLYGON Sci-Fi Space entirely**. Switched to Manufactura K4 (Sci-Fi Industrial) + NEXUS / 3DForge for wreck interiors. Synty retained ONLY as POLYGON ARSENAL FX pack (distinctive sparks/debris that adds identity).
  - Rationale: Critic Board Round 2 flagged "Too close to Lethal Company" — using the same Synty pack as Lethal Company / Content Warning / R.E.P.O. would have killed the USP. New plan places the game visually in the Alien: Isolation / Shipbreaker / Subnautica lane.
  - New budget: **~$200** (was ~$220).
  - Crew character commission now mandatory (industrial-salvager silhouette ≠ Lethal Company space-tourist astronaut).
- `README.md`: updated budget figure, added Visual Identity doc link, added "Visual lane" tagline.

### Added
- `docs/08_Visual_Identity.md`: NEW. Visual brief, 5 pillars (industrial PBR, wreck-specific palette, helmet diegesis, volumetric atmosphere, crew silhouette ≠ Lethal), references, anti-references, lighting recipe per wreck, crew silhouette spec, "done" stranger test. Locked by Creative Director.
- Repository bootstrap.
- All original design docs.
- Unity 2022.3.40f1 LTS project skeleton (URP).
- Core systems C#: ContractManager, HazardSystem, CrewMember, OxygenSystem, InteractionSystem, LootCrate, ValvePanel, ExtractionPad, ShipUpgradeManager, SaveSystem, AudioManager, EventChannels.
- ScriptableObject definitions: ContractData, WreckData, HazardProfile, LootItemData, ShipUpgradeData, DifficultyProfile.
- Networking scaffold (Mirror): NetworkManager_Salvage, CrewNetworkBehaviour, NetworkedInteractable (all #if MIRROR-guarded).
- Standard Unity .gitignore.

### Fixed
- HUDController: removed typo'd helper, simplified event subscription.

## [v0.1-mission1-skeleton] — TBD

First taggable checkpoint once assets are imported and Mission 1 is wired, hostable, and beatable solo.
