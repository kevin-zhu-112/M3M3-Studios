# M3M3-Studios
Kevin Zhu, Akshay Karthik, Alex Booth, Heena Patel, Kevin Nguyen

This is the Alpha demo for Meme Quest 2019.
WASD to move around and space to jump for keyboard controls.
D-PAD to move around and A to jump for controller controls.
The goal is to make it to the end of the level and defeat the boss. Enemies can be defeated by jumping on them, but they will try to knock you off the platforms. If you fall off, it's game over.

Technical Requirements:
Game Feel:
We have a full game loop with start menu, pause menu, retry menu for game overs, and a win menu. The player is met with different challenges and obstacles to overcome during the level.

Precursors to Fun Gameplay:
The player is able to interact with buttons and enemies to solve puzzles and advance through the levels. The player has to watch out to not let the enemies knock him off the level and to his doom.

3D Character/Vehicle with Real-Time Control:
While a model and animations were gathered from a third party source (https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-sample-79870), the animation controller, input controls, and blending was customized by us to provide better handling of the model and animations. We also attempted to include controller support for the animations, but are still in progress.
We also have a camera that follows the player and does its best to not clip through obstacles or end up on the other side of walls.

3D World with Physics/Spacial Simulation:
Our environment contains RigidBody obstacles and interactible buttons that the player must use to solve different puzzles.

Real-time NPC Steering Behaviors/Artificial Intelligence:
Our game includes AI that will attempt to attack the player and try to knock them off the level and to their death. The AI will also switch between different states in response to the player's actions, such as fleeing when hurt and regrouping to attack.

Polish:
Our game contains a start menu and pause menu. We also have different sound effects for certain actions and activities.


