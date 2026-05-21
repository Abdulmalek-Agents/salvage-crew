# 🛰 Mission 1 — Cargo Hauler *Meridian*

> Scene-by-scene breakdown of the vertical slice.

---

## Wreck

**Meridian-class cargo hauler**, 180m long, 4 decks. Spine corridor runs the length. Cargo holds A–C are off the spine.

## Layout (top-down)

```
                     Cockpit (locked)
                          │
            [ Crew Quarters ] ─ Deck 4
                          │
            [ Mess + Med ] ── Deck 3
                          │
   [ Hold C ]─────[ Spine ]─────[ Hold B ]   Deck 2
                          │
            [ Cargo Bay A ]─[ EXTRACTION PAD ] ── Deck 1
                          │
                     Lander Airlock
```

**Crates required:** 5. Locations:
- 2 in Cargo Bay A (easy)
- 2 in Hold B (mid)
- 1 in Hold C (hard — past breach hazard)

## Pacing Curve (intended intensity 0-10)

```
10 │                                              ╱╲
 9 │                                             ╱  ╲
 8 │                          ╱╲                ╱    ╲
 7 │                         ╱  ╲       ╱╲    ╱
 6 │             ╱╲          ╱    ╲     ╱  ╲ ╱
 5 │            ╱  ╲   ╱╲   ╱      ╲   ╱
 4 │       ╱╲  ╱    ╲ ╱  ╲ ╱
 3 │  ───╱   ╲╱      V    V
 2 │ ╱
 1 │╱
   └────────────────────────────────────────────────
    0  5  10 15 20 25 30 35 (min, 4-player)
```

## Beat-by-Beat

### Beat 0 — Lander Hub
- Pick contract: "Meridian Salvage — 5 crates."
- Mark countdown: 30 min departure window.
- 1 cinematic Timeline of lander approach.

### Beat 1 — Airlock & Spine
- Boarding tutorial. Helmet light auto-on.
- First **audio log** auto-plays (captain's last log, "we hit something").

### Beat 2 — Cargo Bay A
- 2 easy crates. Pickup tutorial.
- One crate is on a magnetic clamp — interact to release.

### Beat 3 — Hold B (Deck 2)
- 2 crates. Hold B has a **dormant breach** (closed valve).
- If a crewmate accidentally bumps the valve handle (intentional hazard delivery), the breach activates.

### Beat 4 — Breach
- Hull punctures. Wind SFX + camera shake.
- Crew is pulled toward breach. O₂ drains 3× faster in the room.
- **Counter:** Patch kit (on Deck 3 Med) OR seal valve (back the way they came).

### Beat 5 — Hold C
- Last crate. Path runs through a low-grav zone (Deck 2 spine).
- Low-grav makes carrying crates floaty — risk of fling.

### Beat 6 — Return & Departure Countdown
- Lander begins prelaunch sequence at T-5 min announce.
- All crew must reach extraction pad with 5 crates.

### Beat 7 — Extraction
- Step on pad → close airlock → launch.
- Loot tally screen.

## Triggers

| Trigger | Type | Effect |
|---|---|---|
| `T_Board` | Volume | Start O₂ drain, play audio log 1 |
| `T_HoldB_ValveBumped` | Trigger (any crew touch) | Activate breach hazard |
| `T_HoldC_LowGravEnter` | Volume | Enable LowGravityZone physics |
| `T_LanderCountdownStart` | Timer | Begin 5-min departure countdown |
| `T_AirlockClosed` | Interact | Trigger extraction & win screen |

## Audio Logs

| # | Where | Content |
|---|---|---|
| 1 | Spine Deck 1 | Captain: "We struck a derelict. Hull is venting. Cargo is intact." |
| 2 | Crew Quarters (Deck 4, optional) | Engineer: "The pulls aren't from our gravity. Something's below us." |
| 3 | Mess (optional) | Cook: light comedic relief, sets crew tone |
| 4 | Hold C wall, before low-grav | Captain: brief, scared — sets up M2 |

## Estimated Build Hours (post asset import)

| Task | Hours |
|---|---|
| Greybox + asset dress | 16 |
| Networking sync pass (crates, valves, airlock) | 8 |
| Hazard tuning (breach, low-grav) | 6 |
| Audio logs + radio chatter | 4 |
| Lander + extraction | 4 |
| UI polish (HUD, tablet, end screen) | 6 |
| Solo-balance pass | 4 |
| Bug pass | 8 |
| **Total** | **~56 hrs** |
