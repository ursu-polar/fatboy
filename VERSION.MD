
### fatboy_1.0
- first build
- drag the player on screen
- lock portrait orientation
- added enemies 
	- ones that will increase your size
	- ones that will decrease your size
	- ones that will reset your size
	
### fatboy_1.1
- added scoring points
- improve movement and fix bugs when growing/shrinking and clamp it to the screen size
- destroy uncached food

### fatboy_1.2
- added end game area
- added GlobalObject
- added Begin game  & End game Scene screens
- added Begin game button
- added End game Retry and Menu buttons

### fatboy_1.3
- added timer (so far it does nothing but count time)
- added Highscore to Menu and Endgame
- implemented the Highscore, not it keeps the highscore
- tweaked the scoring points. needs more tweaking
- added gameLevel (actualy the gravity speed)
- thinking of adding times to highscore

### fatboy_1.3.1
- added sub versioning for clearer version improvements increments
- new graphic assets from freepik (maybe a retro space synth pop feel?)
- created GITHUB project
- created THIS file

### fatboy_1.3.2
- added quit dialog box (quit/cancel) in all scenes
- increase spawn rate in correlation with gameLevel (gravity speed)
- decrease change of spawning decreaser correlated with gameLevel(spawn interval)
- decrease change of spawning bonus 
- decrease bonus size reduction from reset to initial size to half the size (needs improvement)
- some code refactoring and cleaning

### fatboy_1.3.3
- new background and new theme? space monster eater?
- background star spawner
- new random player face from 4 templates
- random grow for eating food (1-5 vs statis 2)
- GIT rep going public

### fatboy_1.3.4
- ~~added particle trail on player movement (needs improvment)~~ [lost because f*cked up commit/pull]
- ~~added background visual breathing effect~~ [lost because f*cked up commit/pull]
- added Foods random faces
- change falling implementation from Gravity to AddForce (so i could pause, slow down, rever, etc. individual Food items)
- ~~Grow will be inversely proportional with the size so you will die slower when getting very big~~ [not implemented yet]


#### fatboy_1.3.4.1 & fatboy_1.3.4.2
- fixed the lost particle trail and background breath effect
- installed local history file management for Visual Studio

#### fatboy_1.3.4.3
- added gameState Pause when eating Bonus - will pause the game so the shrking could be finished and then resume the game
- added gameState Slow when eating Life - not working yet - it should slow down all the falloing Food items and then resume

#### fatboy_1.3.4.4
- Grow will be inversely proportional with the size so you will die slower when getting very big
- NEW BUILD
- moved versioning to VERSION file
