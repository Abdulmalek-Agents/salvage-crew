# Mission 1 — Cargo Hauler *Meridian*

> Scene-by-scene breakdown of the vertical slice.

## Wreck

Meridian-class cargo hauler, 180m long, 4 decks. Spine corridor runs the length. Cargo holds A-C are off the spine.

## Layout

```
                     Cockpit (locked)
                          |
            [ Crew Quarters ] -- Deck 4
                          |
            [ Mess + Med ] -- Deck 3
                          |
   [ Hold C ]------[ Spine ]------[ Hold B ]   Deck 2
                          |
            [ Cargo Bay A ]-[ EXTRACTION PAD ] -- Deck 1
                          |
                     Lander Airlock
```

**Crates required:** 5
- 2 in Cargo Bay A (easy)
- 2 in Hold B (mid)
- 1 in Hold C (hard — past breach hazard)

## Beat-by-Beat

### Beat 0 — Lander Hub
- Pick contract: Meridian Salvage — 5 crates. Countdown: 30 min.
- 1 cinematic Timeline.

### Beat 1 — Airlock & Spine
- Boarding tutorial. Helmet light auto-on.
- Audio log 1 auto-plays.

### Beat 2 — Cargo Bay A
- 2 easy crates. Pickup tutorial.
- One crate on magnetic clamp — interact to release.

### Beat 3 — Hold B (Deck 2)
- 2 crates. Hold B has a dormant breach (closed valve).
- Crewmate bumping the valve handle activates the breach.

### Beat 4 — Breach
- Hull punctures. Wind SFX + camera shake.
- Crew pulled toward breach. O2 drains 3x faster.
- Counter: Patch kit (Deck 3 Med) OR seal valve.

### Beat 5 — Hold C
- Last crate. Path runs through a low-grav zone (Deck 2 spine).
- Low-grav makes carrying crates floaty — risk of fling.

### Beat 6 — Return & Departure Countdown
- Lander prelaunch at T-5 min.
- All crew must reach extraction pad with 5 crates.

### Beat 7 — Extraction
- Step on pad → close airlock → launch.
- Loot tally screen.

## Triggers

| Trigger | Type | Effect |
|---|---|---|
| T_Board | Volume | Start O2 drain, play audio log 1 |
| T_HoldB_ValveBumped | Trigger | Activate breach hazard |
| T_HoldC_LowGravEnter | Volume | Enable LowGravityZone |
| T_LanderCountdownStart | Timer | Begin 5-min countdown |
| T_AirlockClosed | Interact | Trigger extraction & win |

## Audio Logs

| # | Where | Content |
|---|---|---|
| 1 | Spine Deck 1 | Captain: "We struck a derelict. Hull is venting." |
| 2 | Crew Quarters Deck 4 (optional) | Engineer: "The pulls aren't from our gravity. Something's below us." |
| 3 | Mess (optional) | Cook: comic relief |
| 4 | Hold C wall, before low-grav | Captain: scared — sets up M2 |

## Estimated Build Hours (post asset import)

| Task | Hours |
|---|---|
| Greybox + asset dress | 16 |
| Networking sync pass | 8 |
| Hazard tuning | 6 |
| Audio logs + radio chatter | 4 |
| Lander + extraction | 4 |
| UI polish | 6 |
| Solo-balance pass | 4 |
| Bug pass | 8 |
| **Total** | **~56 hrs** |
