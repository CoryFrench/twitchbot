# Twitch Adventure Bot
## Critical Features (Phase 1 - MVP)
* ~~Bot "round-tripping" via twitchlib~~
* ~~Player registration~~
* A single, basic "Encounter" (adventure leg)
* ~~Announce results~~
## Basic Features (Phase 2 - v1)
* Multiple encounters, encounter pacing
* Encounter refinement / depth
* Basic scoreboard
## Future Features (Backlog)
* Player depth (class/level/equipment)
  * Class specific AI
* Combat refinement
* Player progression / encounter rewards
* Advanced bot reporting
* Scoreboard refinement
## Design Thoughts / Data Modeling considerations
* Bot / Game begs for [State pattern](https://en.wikipedia.org/wiki/State_pattern)
* Encounters could leverage [Strategy pattern](https://en.wikipedia.org/wiki/Strategy_pattern) and [Decorators](https://en.wikipedia.org/wiki/Decorator_pattern)
* Bot permits registration only during certain states
* Encounters aggregate players through registration
* Bot iterates through state transformations
