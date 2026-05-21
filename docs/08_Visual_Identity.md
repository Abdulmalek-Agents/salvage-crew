# 🎨 Visual Identity — Salvage Crew

> **The visual brief.** Critic Board Round 2 was explicit: Salvage Crew lives or dies on whether it reads as **"not Lethal Company"** within 3 seconds of someone seeing a screenshot. This document is how we win that 3 seconds. Locked by Creative Director after USP review.

---

## The One-Sentence Brief

> *"Hardspace: Shipbreaker's industrial honesty, Alien: Isolation's wreck-as-tomb dread, Subnautica's oxygen tension — at a budget that doesn't pretend to be AAA."*

---

## Visual Pillars

### Pillar 1 — Industrial PBR (not cartoon low-poly)
- Materials are **PBR-low-poly hybrid**: simplified meshes but realistic shading and roughness.
- **Manufactura K4 / NEXUS / 3DForge** over Synty for environment.
- **No flat-shaded saturated cartoon look.** That lane is owned by Lethal Company — do not enter it.

### Pillar 2 — Wreck-specific 3-colour palette (per mission)
Each wreck reads instantly distinct from the others even though they share kit-bashed assets. This is how five missions feel like five places without buying five environment packs.

| Mission | Wreck | Palette |
|---|---|---|
| 1 | Meridian (Cargo Hauler) | **Orange emergency strips + cool blue helmet lights + deep black** |
| 2 | Pharos (Medical Frigate) | Sterile white + medical green + blood red |
| 3 | Argus (Research Vessel) | Bio-amber + sickly purple + black |
| 4 | Vengeance (Military Destroyer) | Steel grey + red alarm + harsh white |
| 5 | Origin (Unknown) | Unstable; every other palette flickers in |

### Pillar 3 — Helmet diegesis
- HUD lives on the **helmet visor**: subtle vignette, occasional fog from breathing, scratched glass overlay.
- O₂ meter, compass, contract objectives — all as visor reflections, not floating Canvas UI.
- Crew comms come through with **radio static** when distant, clean when close.

### Pillar 4 — Volumetric atmosphere
- **Heavy volumetric fog** in every wreck. Light shafts through breached hulls.
- Crew **helmet lights are the primary readable light source** — same dread principle as Signal Lost, applied to co-op.
- Emergency strip lights are the only ambient illumination.

### Pillar 5 — Crew silhouette ≠ Lethal Company silhouette
- Crew is an **EVA-suited industrial salvager**: bulky shoulders, work-belt, riot-helmet visor with a single horizontal light strip.
- **NOT** the round-helmet space-tourist look from Lethal Company.
- **This is the most important single visual decision in the project.** The character silhouette is what shows up in store-page cover art, Steam thumbnails, and reaction screenshots. If the silhouette reads as Lethal Company, the USP has failed.

---

## Reference Films / Games

- *Hardspace: Shipbreaker* — industrial wreck atmosphere, salvage tools, EVA suit aesthetic
- *Alien: Isolation* — wreck-as-character, orange emergency lighting, Working Joe silhouettes
- *Subnautica* — oxygen tension, environmental storytelling, beauty in dread
- *Dead Space* — industrial sci-fi, RIG suit aesthetic, in-world HUD
- *Prey (2017)* — Talos I interiors, the mundane horror of corporate space

## Anti-References (DO NOT LOOK LIKE THESE)

- ❌ **Lethal Company** — saturated cartoon Synty look. We are **NOT** this.
- ❌ **Content Warning / R.E.P.O. / Voices of the Void** — same Synty lane. We are **NOT** this.
- ❌ **No Man's Sky** cartoony exteriors — wrong tone, wrong palette.
- ❌ **Generic Mixamo astronaut + Synty room asset-flip Steam game.**

---

## Specific Technical Targets

| Surface | Treatment |
|---|---|
| Wreck interiors | Manufactura K4 / NEXUS PBR materials. NO flat-shaded cartoon look. |
| Crew character | Custom-commissioned or Mixamo + retopo. **Bulky industrial silhouette. Single light strip on helmet visor.** |
| Crates / valves / props | Quaternius CC0 base + custom material adjustment for wreck palette |
| VFX | Synty POLYGON ARSENAL — distinctive sparks, debris, breach decompression effect |
| Lighting | 1 baked directional (low) + warm orange emergency strips (real-time, baked-shadow) + cold blue helmet point lights. **Volumetric fog ON.** |
| Post-FX | Vignette (subtle), Film Grain (subtle), Colour Grading (warm shadows / cool highlights), Bloom (controlled — only on emergency strips and helmet lights), Volumetric Fog (heavy) |
| UI | **Helmet visor overlay** — vignette + occasional fog breath. NOT floating Canvas elements. |

---

## Lighting Recipe (per wreck)

```
1   × Baked Directional (low intensity — emergency power only, top-down)
3-6 × Orange Emergency Strip lights
        (Real-time, baked-shadow, range 6m, intensity 2,
         colour matches wreck palette)
0   × Realtime point lights except for each player's helmet light
Volumetric Fog: density 0.08, height falloff, warm tint matching wreck palette
Light Probes: dense in interaction zones
```

## Crew Silhouette Spec

```
Helmet:    riot-style flat visor with ONE horizontal light strip
Shoulders: BULKY pauldrons (industrial salvager, not space tourist)
Torso:     work-belt with visible tools (wrench, patch kit, scanner)
Legs:      mag-boots clearly modelled (large soles)
Palette:   primary colour customisable per player (4-crew variety),
           secondary always industrial grey, visor light always white
```

## What "Done" Looks Like

**Side-by-side stranger test:**
1. Take a Mission 1 wreck corridor screenshot.
2. Show it next to a Lethal Company screenshot.
3. A non-gamer must be able to tell within **3 seconds** that they are different games in different genres.
4. If they can't → Visual Identity has failed. Iterate the lighting, palette, or crew silhouette.

**Single-screenshot test:**
Place a single Salvage Crew screenshot on r/IndieDev with no caption. If the first three comments are "is this a Lethal Company clone?" — we have failed. The look must read as Alien-Isolation-lite at first glance.

This is the bar. The Creative Director will hold the bar.

---

## Status

✅ Locked by Creative Director. Any deviation requires a Critic Board review.
