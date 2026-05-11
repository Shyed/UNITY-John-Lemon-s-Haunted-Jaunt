# John Lemon's Haunted Jaunt

A 3D stealth-survival game developed in Unity where players navigate a haunted mansion while avoiding enemy detection and escaping safely. This project focuses on gameplay systems, AI navigation, stealth mechanics, animation systems, and environmental atmosphere design using Unity and C#.

Originally created through Unity Learn and coursework exploration, the project was later revisited and expanded with detailed developer notes and code documentation for educational and portfolio purposes.

---

## Project Overview

Players control John Lemon as he explores interconnected haunted environments filled with roaming ghost enemies, environmental storytelling, dynamic lighting, and stealth-based gameplay mechanics. The objective is to avoid detection, survive enemy encounters, and successfully escape the mansion.

---

## Key Features

- 3D player movement and animation system
- Enemy AI patrol behavior using Unity NavMesh
- Stealth detection system using raycasting and trigger zones
- Game-over and restart state management
- Dynamic lighting and environmental atmosphere
- Outline shader effects and visual feedback systems
- Audio integration for immersion and gameplay feedback
- Multiple explorable interior environments

---

## Technologies & Tools

- Unity Engine
- C#
- Unity NavMesh System
- Unity Animator Controller
- Unity Physics & Raycasting
- TextMesh Pro
- Visual Studio

---

## Gameplay Systems Implemented

### Player Controller System
- Rigidbody-based movement
- Smooth player rotation
- Animation-driven locomotion
- Footstep audio integration

### Enemy AI System
- Waypoint-based patrol behavior
- NavMesh pathfinding
- Trigger-based awareness system
- Line-of-sight player detection

### Stealth & Detection
- Enemy vision cone simulation
- Raycast visibility checks
- Dynamic fail-state/game-over logic

### Visual Effects
- Dynamic light flickering system
- Outline shader rendering
- Material and emission manipulation

### Game State Management
- Scene restart logic
- Win/lose state handling
- UI fade transitions
- Audio event triggers

---

## Software Engineering Concepts Demonstrated

- Object-Oriented Programming (OOP)
- Component-based architecture
- AI pathfinding systems
- Event-driven programming
- State management
- Physics and collision systems
- Raycasting and spatial calculations
- Animation systems
- Modular gameplay scripting
- Shader/material manipulation
- Custom Unity editor tooling

---

## Project Structure

```text
Assets/
├── Animation/        # Animation clips and controllers
├── Audio/            # Sound effects and environmental audio
├── Materials/        # Materials and lighting assets
├── Models/           # 3D models and FBX assets
├── Prefabs/          # Reusable game objects
├── Scenes/           # Main gameplay scenes
├── Scripts/          # Gameplay and AI logic
├── Shaders/          # Rendering and outline shaders
├── Textures/         # Environment textures
├── TextMesh Pro/     # UI text rendering assets
```

---

## Script Location

All gameplay and logic scripts are located under:

```text
Assets/Scripts/
```

Example scripts include:

- `PlayerMovement.cs`
- `WaypointPatrol.cs`
- `Observer.cs`
- `GameEnding.cs`
- `LightFlicker.cs`
- `Outliner.cs`

---

## Educational Developer Notes

This repository contains heavily documented scripts and beginner-friendly developer notes for educational and portfolio purposes.

Comments were intentionally expanded to:
- explain gameplay architecture
- reinforce Unity concepts
- document programming logic
- improve readability and maintainability
- support long-term learning and review

Because of this, the scripts are more heavily commented than a typical production codebase.

---

## Project Purpose

This project was developed to strengthen practical understanding of:
- Unity gameplay architecture
- AI navigation systems
- stealth game mechanics
- animation and physics systems
- event-driven gameplay logic
- modular software design

It also serves as a portfolio project demonstrating transferable software engineering and game development concepts.

---

## Author

Created by Sheila Demonteverde through Unity Learn and coursework exploration. Expanded and documented for educational and portfolio development purposes.

---

## License

This project is shared for educational and portfolio purposes only. Not intended for commercial distribution.
