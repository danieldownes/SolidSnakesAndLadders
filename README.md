# README #

# TASK #

Creating a small version of https://en.wikipedia.org/wiki/Snakes_and_Ladders; a 6x6 board

- Player Vs Bot 
- where you show ui decoupling from game core logic
- use events (as delegates or Action)
- implement start menu, pause and game over (by lose or win)

The main point for the evaluation is applying SOLID principles

# PLAN OF ATTACK #

Obtain some basic template graphics
Prep them and import into project
 - Decided just to use basic primitives

Scene Prep.:

Setup UI:
Menu
Start Game Button

Pause Menu
Unpause Button

Game
Roll button
Dice label
Player indication
Label "Your turn" / "Bot"
with box highlight BG to indicate turn

Setup Game View:
Create board places, eg a "grid"
Was thinking about using Cubes for this, rather an a 2D approach. Mainly
just to change things up.
I'll do this manually rather than through code so that we can place squares
with an arbitrary layout layout than an actual grid.

Players. Green and Red spheres.

The Snakes & Ladders assets will be in fixed places. But will create a view class that allows defining which grid position should be moved to if landing on that place. Eg, Id of a higher 
or lower place, depending onif there is a ladder or snake placed here.

I'll allow defining this level data directly from the inspector as it means a level designer
could just define the level from the editor directly without jumping into code.

Class Planning:

Installer - to allow for DI setup and instance binding

Game - Collection of the logical game elements and events
TurnControl - to manage the flow of turn logic

Place - A position on the board, can also define ladder or snake as it will just be a jump ID index

Dice - Allow random roll between 1-6 inclusive


Player - Interface or abstract player logic
PlayerHuman - Wait for call to roll
PlayerBot - Automatically role

BoardView - Reference to board and places
Ui - Purely for windows/panels



# DEV NOTES #

Ui related:
Normally I would include button events on a per screen
view class basis, and then delegate to UI controller where required.


# FURTURE PLANNING #

Add further unit tests
Seperate game class further, ie. move logic class
Add Tweener library, LiteTween
Add DI framework, Ninject
