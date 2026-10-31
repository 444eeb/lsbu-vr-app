# SouthBankVisuals

A virtual reality campus tour of London South Bank University (LSBU), built in Unity for open day visitors. Users explore four real campus locations (Courtyard, Café, Library and Classroom) as 360-degree video, switch between them freely, and open an info panel in each scene for more detail. The Café also includes a second, robot-filmed walkthrough that can be toggled on.

Built for the CSI-6-ART AR/VR Technologies module as a team of three.

## What it does

- Welcome screen leading into a Main Menu with the four locations in a 2×2 grid
- Each location plays 360-degree footage on the inside of a skysphere
- Navigation bar in every scene (menu button, scene counter, location label, info toggle)
- Info panel overlay in each scene, plus a Robot View toggle in the Café
- Works with controllers or gaze (1.5 second fuse), so first-time VR users can still use it
- A mouse-look camera (`FreeLookCamera.cs`) for demoing without a headset

## Tech

- Unity 2022.3 LTS (developed on 2022.3.62f3)
- OpenXR, targeting standalone Android VR headsets (ARM64), with PC VR profiles also configured
- C# scripts: `SkysphereController`, `SceneLoader`, `InfoPanelController`, `FreeLookCamera`

## How to run it

### Option 1: Install the built app (headset)

1. Download `SouthBankVisuals.apk` from this repo.
2. Put your headset in developer mode and connect it to your computer.
3. Install it with `adb install SouthBankVisuals.apk`.
4. Launch it from the Unknown Sources section of your headset library.

### Option 2: Run it in Unity

1. Install Unity Hub and Unity **2022.3 LTS**. Add **Android Build Support** during install.
2. Clone the repo: `git clone https://github.com/444eeb/lsbu-vr-app.git`
3. In Unity Hub, choose **Add project from disk** and select the `SouthBankVisuals` folder.
4. **Add the 360 videos.** The video files were too large for GitHub, so they are excluded by `.gitignore`. Place these five files in `Assets/Content/Videos/`:
   `courtyard`, `cafe`, `library`, `classroom`, `robot`
5. If a skysphere shows no video, open that scene, select the `Skysphere` object and drag the matching clip into **Panoramic Video** in the Skysphere Controller. In `Scene_Cafe`, also assign the robot and original clips on the Info Panel Controller.
6. Open the scene `0 - Welcome` and press **Play**.
7. No headset? Use the mouse to look around with `FreeLookCamera`.

### Building the APK yourself

1. Go to **File > Build Settings** and switch the platform to **Android**.
2. Check that all seven scenes are listed in this order: Welcome, MainMenu, Scene_Courtyard, Scene_Cafe, Scene_Library, Scene_Classroom, NavPanel.
3. Click **Build** (or **Build and Run** with the headset connected).

## My role

I was responsible for the Unity application development. This covered the scene structure, OpenXR set up, the C# scripts, the UI implementation, integrating the 360 content, and Git version control. Filming was shared across the whole team.

## Team

Three-person student team, LSBU School of Engineering, BSc (Hons) Computer Science.
