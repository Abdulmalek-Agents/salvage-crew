# Changelog

All notable changes to **Salvage Crew** are documented here. Follows Keep a Changelog.

## [Unreleased]

### Added
- Repository bootstrap.
- All design docs.
- Unity 2022.3.40f1 LTS project skeleton (URP).
- Core systems C#: ContractManager, HazardSystem, CrewMember, OxygenSystem, InteractionSystem, LootCrate, ValvePanel, ExtractionPad, ShipUpgradeManager, SaveSystem, AudioManager, EventChannels.
- ScriptableObject definitions: ContractData, WreckData, HazardProfile, LootItemData, ShipUpgradeData, DifficultyProfile.
- Networking scaffold (Mirror): NetworkManager_Salvage, CrewNetworkBehaviour, NetworkedInteractable (all #if MIRROR-guarded).
- Standard Unity .gitignore.

## [v0.1-mission1-skeleton] — TBD

First taggable checkpoint once assets are imported and Mission 1 is wired, hostable, and beatable solo.
