# M3M3-Studios
Kevin Zhu
903112781
kzhu48@gatech.edu

Akshay Karthik
903212846
akarthik3@gatech.edu

Alex Booth
903115111
alexbooth@gatech.edu

Heena Patel
903128265
hpatel328@gatech.edu

Kevin Nguyen
903128265
knguyen90@gatech.edu

This is the Final Project Submission for Meme Quest 2019.
WASD to move around and space to jump for keyboard controls. Arrow keys to move the camera and ESC to pause. F to pick up special objects.
D-PAD to move around and A to jump for controller controls. Right Stick to move the camera. We only have input configuration for the Nintendo Switch controller. + or Start button to Pause. X to pick up special objects.
The goal is to make it to the end of each of 3 levels and defeat the boss. Enemies can be defeated by jumping on them, but they will try to knock you off the platforms. If you fall off, it's game over and you have to restart from the level.


Technical Requirements:
Game Feel:
We have a full game loop with start menu, pause menu, retry menu for game overs, and an end screen. The player is met with different challenges and obstacles to overcome during the level.


Precursors to Fun Gameplay:
The player is able to interact with buttons and enemies to solve puzzles and advance through the levels. The player has to watch out to not let the enemies knock him off the level and to his death.

3D Character/Vehicle with Real-Time Control:
While a model and animations were gathered from a third party source, the animation controller, input controls, and blending were implemented and customized by us to provide better handling of the provided model and animations. We have implemented both keyboard and controller support for the animations.
We also have a camera that follows the player and does its best to not clip through obstacles or end up on the other side of walls.
You can find the animation controller in the Assets/Animations/Player folder and the input control scripts in Assets/Scripts/Input. The CustomCharacterControl is our most updated script for player control.


3D World with Physics/Spacial Simulation:
Our environment contains RigidBody obstacles and interactible buttons that the player must use to solve different puzzles. There are also different platforming challenges that the player must overcome.
You can find the animations in Assets/Animations/Environment and the scripts in Assets/Scripts/Environment.


Real-time NPC Steering Behaviors/Artificial Intelligence:
Our game includes AI that will attempt to attack the player and try to knock them off the level and to their death. The AI will also switch between different states in response to the player's actions, such as fleeing when hurt and regrouping to attack. The Pepe and Shoe AI steers towards the player in the chase state. The DoodleBob AI interacts with the walls around the stage when it flees and attacks the player. The Pepe Boss AI also uses the pillars to strafe around the player and to hide from the player.
You can find the Animations in Assets/Animations/Enemies and the scripts in Assets/Scripts/AI

Polish:
Our game contains a start menu and pause menu. The levels contain unique skyboxes and visual flair based on the meme the level is based off of. We have different sound effects for certain actions and activities.
You can find the UI scripts in Assets/Scripts/UI

The scenes used in the build are GameMenu, Level 0, ShoeBoss, Level 1, Level 1 Boss, Level 2, and Boss Testing. Other scenes in the project are used for debugging. To start playing the game, hit play in the GameMenu scene. The main algorithm-heavy scripts are the Camera scripts, CharacterControl, CustomCharacter, InputController, ShoeAIScript, PepeBossScript, and DoodleBossScript, while other scripts create scaffolding for level sequence and more simple interactions between the player and the world.


Technical Issues and Unresolved Bugs:
Very rarely will the player sometimes be able to double jump infinitely after killing an enemy.
The Pepe Boss will sometimes be stuck in midair while in his stunned animation.
Placing a block inside another gameobject using the Place Block powerup will sometimes push the block back and give the player a ton of momentum.
Jellyfish will sometimes die unintentionally when the player collides with them from below instead of knocking the player back.
The player can sometimes gain a lot of upward momentum if the player presses the jump button at a precise moment after bouncing off an enemy or landing on a ledge.
Some parts of the central mountain in Level 2 is unintentionally scalable by the player by repeatedly jumping up the mountain, though it takes a bit of time.


Who Did What:
Kevin Nguyen: Handled all of the artwork and UI elements, created animations for the player character, implemented the dialog system and the powerup system. Was the primary bug-hunter/balancer along with Kevin Zhu.

Kevin Zhu: Implemented Level 0 and Level 2 and developed the AI/Map for Shoe Boss and Pepe Boss fights. Developed the mechanics for the player and was the primary bug-hunter/balancer along with Kevin Nguyen.

Alex Booth: Implemented the AI/Map for the Doodlebob fight and designed the jellyfish AI, shoe minion AI, and pepe minion AI.

Heena Patel: Implemented Level 1 and designed the moving platforms.

Akshay Karthik: Designed the double-button puzzles for Level 2 and aided with Level 2 implementation.


Attributions:
Player Model - https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-sample-79870

Certain Terrain Textures and Environmental Features (Trees, rocks, plants) - https://assetstore.unity.com/packages/3d/environments/landscapes/lowpoly-environment-pack-99479

Pepe Model and Animations (Except for the Ninja Run) - https://sketchfab.com/3d-models/mr-pepe-decad7495b8a423386bb9bd5a0a9760d

Images used in Level 1 Boss (Doodlebob) - https://spongebob.fandom.com/wiki/DoodleBob/gallery

Pencil model - https://assetstore.unity.com/packages/3d/props/tools/pencil-8741

Powerup SFX - Metroid ~ Item Acquisition Fanfare (https://www.youtube.com/watch?v=xpAB3kkIXg4)
              Super Metroid ~ Item Acquisition Fanfare (https://www.youtube.com/watch?v=MdEFCzMNPa0)

Level 0 Music - Old School RuneScape ~ Harmony (https://www.youtube.com/watch?v=ELTyyPwjtiw)

Boss Music - Phonson (https://opengameart.org/content/boss-fight)

Level 1 Music - Spongebob Battle for Bikini Bottom ~ Jellyfish Fields (https://www.youtube.com/watch?v=fz-Sstui9yc)

Level 2 Music - Soul and Mind - E's Jammy Jam (https://www.youtube.com/watch?v=NGazythwAkU)