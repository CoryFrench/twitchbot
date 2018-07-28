# Twitch Adventure Bot
## Critical Features (Phase 1 - MVP)
* ~~Bot "round-tripping" via twitchlib~~
* ~~Player registration~~
* ~~Announce results~~
* A single, basic "Encounter" (adventure leg)
  * ICreature interface
    * Name get/set
    * Class get/set (just a string for now, lets say Warrior / Skeleton)
    * Current & Max HP get/set
    * AC get/set
    * Attack(ICreature) function
  * IEncounter interface
    * Add ICreature
    * Resolve() or Complete() function to "calculate the result"
  * Encounter class
    * Has a List of ICreatures for both Players and Monsters
	   * `while (PlayersNotDead && MonstersNotDead) { // everyone attacks once, pick random target from other list }`
  * IGame interface
    * Game.End() should now simply call `{ Encounter.Resolve(); Announce(Encounter.PlayersNotDead); }`
    * Needs CreateEncounter() function
      * Call in GameOverState::OnStateEntered
      * Adds one Warrior (HP = 16, AC = 17, Attack +5 vs AC, Damage = 1d8+3) for each player
      * Adds RNG(1 to 1.5 * #ofPlayers) Skeletons (HP = 4, AC = 16, Attack +2 vs. AC, Damage = 1d6+2)
  * **NOTE:** If this seems overwhelming, trust me, it's not that much.  Just start from ICreature and work down the list.  If you get an Interface/Class pair building, but not intergrated, that's a perfectly valid time to commit and push :)
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
