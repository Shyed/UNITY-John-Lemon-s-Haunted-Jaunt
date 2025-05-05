# John Lemon's Haunted Jaunt (Unity 3D Game)

**John Lemon's Haunted Jaunt** is a beginner-friendly 3D stealth game developed in Unity. Players guide John Lemon through a haunted mansion filled with eerie rooms, creepy corridors, and patrolling ghost enemies. The goal is to escape detection and reach the exit.

---

## Features

- Ghost patrol AI using Unity animation and navigation
- Gargoyle AI using Unity animation
- Player controller with idle/walk animations
- Multiple haunted environments: Bathroom, Bedroom, Dining Room, Corridor, etc.
- Character animation with `.fbx` 3D assets
- Real-time lighting and VFX for atmospheric storytelling
- Complete Main Scene with multiple connected rooms

---

## 📁 Project Structure
Assets/
├── Animation/ # Animation clips and controllers
├── Audio/ # Game sound effects and background audio
├── Character_Cactus/ # Character models and supporting data
├── Materials/ # Game materials for lighting and surfaces
├── Models/ # FBX models for characters and objects
├── Prefabs/ # Prebuilt game objects
├── Scenes/ # MainScene.unity and related data
├── Scripts/ # C# logic for AI, controls, game systems
├── Shaders/ # Visual shaders for rendering
├── Textures/ # Texture files used in environments
├── TextMesh Pro/ # UI text rendering
├── TutorialInfo/ # Unity Learn metadata and tutorial links


---

## Getting Started

### Requirements:
- Unity 2020.3 or later
- TextMesh Pro (auto-imported)
- No external packages required

### How to Run:
1. Open Unity Hub and load the project folder.
2. Open `Assets/Scenes/MainScene.unity`.
3. Press Play to start the game.
4. Use arrow keys or WASD to control John Lemon.
5. Avoid ghosts and reach the final room without getting caught!

---

## Learning Objectives

- Understand Unity's Animator Controller system
- Set up 3D character movement and camera following
- Create patrolling enemy AI using basic scripting
- Practice modular scene design and VFX integration
- Learn Unity’s project structure and best practices

---

## Scripts Included

- `Move.cs` – Basic movement logic
- `CameraFollow.cs` – Smooth camera following player
- `Patrol.cs` – Enemy patrol behavior
- `Push.cs`, `Jump.cs`, `AutoRotate.cs` – Interactions and motion
- `Ghost.controller`, `JohnLemon.controller` – Animation logic

---

## Screenshots
> *(Optional section – Add screenshots from your gameplay later)*

---

## Author

Created by **Sheila Demonteverde** as part of MAC 272 coursework and Unity Learn tutorials.

---

## License

This project is shared for educational purposes only. Not for commercial use.


