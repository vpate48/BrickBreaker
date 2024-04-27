Brick Breaker Game

Description

This is a Brick Breaker game developed in Unity, showcasing advanced techniques in game development. The game challenges players to destroy all the bricks on the screen using a ball that bounces off a paddle. It employs various game mechanics, including power-ups, dynamic scoring, and multiple levels with increasing difficulty.

Key Features
1. Dynamic Paddle Control
The paddle's movement is controlled using Unity's built-in physics system, enabling smooth and responsive gameplay.
Utilizes FixedUpdate() for consistent paddle movement regardless of frame rate fluctuations.
Implements input handling using Input.GetAxisRaw("Horizontal"), ensuring precise control over paddle movement.
2. Modular Block Behavior
Blocks are designed as modular GameObjects with customizable properties such as durability and appearance.
Implements OnCollisionEnter2D() to detect collisions between the ball and blocks, allowing for dynamic block destruction based on ball velocity and block durability.
3. Engaging Power-Up System
Features various power-up items that spawn randomly when certain blocks are destroyed, adding depth and excitement to gameplay.
Implements OnTriggerEnter2D() to detect collisions between the paddle and power-ups, triggering corresponding effects such as score boosts or extra lives.
4. Advanced UI Management
Utilizes Unity's UI system to create dynamic and visually appealing user interfaces for displaying score, lives, and level information.
Implements Update() to continuously update UI elements based on game events such as score increases, life changes, and level transitions.
5. Level Management and Progression
Implements a level system with multiple levels of increasing difficulty, providing players with a progressively challenging experience.
Utilizes Unity's scene management to seamlessly transition between levels, maintaining player progression and game state.
