# Fatboy
***About the game:***
Second Unity 2D project, Fatboy is a pointy-move-it-grab-it-miss-it kind of game for Android devices. The plot is unknown so far but could be added later.

***Main game loop mechanic:***
Things drop from the top of the screen. You can move your character left to right and right to left by touch (drag or point). When you hit the falling items, you either:
- grow
- shrink
- reset to initial size
For each item "eaten" you get points. There is a timer but so far it does nothing (maybe give points for longest survival time?). If you reach the top of the screen or an area at the top of the screen, you die and the game ends.

------------

## Wishlist
- [x] make Wishlist [done in 1.3.3]
- [ ] sounds (for menu and for game)(make increase tempo of music with level?)
- [ ] save highscores online, maybe highscore table, compare yourself with others
- [ ] better UI elements
- [x] back button will open quit/cancel dialog box [done in 1.3.2]
- [ ] generate random look for each Food type
- [ ] add more Food types
- [ ] add sound effects when eating food
- [ ] add effects when eating food
- [ ] UI animations
- [ ] add someking of powerups in slots(n per game?)(ex: show when/where a Bonus food will appear like a lightnigh bolt or something)
- [ ] add Points to unlock powerups 
------------


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
