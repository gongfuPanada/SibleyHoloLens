# SibleyHoloLens

An augmented reality application using the Microsoft HoloLens where a person can place the device on their head, leverage voice commands to navigate the menu options, and view an arrangement of religious icons within the chapel.

## DOCUMENTATION

* [Windows Holographic documentation](https://developer.microsoft.com/en-us/windows/holographic/documentation)
* [HoloLens Unity Development Overview](https://developer.microsoft.com/en-us/windows/holographic/unity_development_overview)
* [Unity HoloLens forum](http://forum.unity3d.com/forums/hololens.102/)

## INSTALL DEVELOPMENT TOOLS

* [Install Tools](https://developer.microsoft.com/en-us/windows/holographic/install_the_tools):
  * [Install Visual Studio 2015](https://developer.microsoft.com/en-us/windows/downloads). Community Edition is acceptable.
  * Install HoloLens emulator.
  * Install Unity HoloLens Technology Preview.
  * Install Microsoft HoloLens app out of Windows Store on development PC.
  * Check back regularly for updates to emulator and Unity.

## START A NEW UNITY PROJECT FOR HOLOLENS
* Change the basic scene rendering settings:
  * Select the `Main Camera`.
  * Set its `position` to the origin `(0, 0, 0)`.
  * Change `Clear Flags` to `Solid Color`.
  * Change `Background` to solid black.
  * Change `Clipping Planes - Near` to `0.85` meters (as per HoloLens design recommendations).
  * Save the Scene (`CTRL+S`, or `File > Save Scene`).
* Under `Edit > Projects settings > Quality`:
  * select the dropdown arrow under the row of checkboxes in the column for Windows Store.
  * select `Fastest` for the default render quality.
* Under `File > Build settings...`:
  *
  * Select `Windows Store`.
  * Change `SDK` to `Universal 10`.
  * Change `UWP Build Type` to `D3D`.
  * Check `Unity C# Projects`.
  * Click `Player Settings...` button.
    * Change `Company Name` and `Product Name` as necessary.
    * Here is also where you will change the Icon.
    * Under `Settings for Windows Store`:
      * Under `Publishing Settings > Capabilities`, select
        * `WebCam` (probably won't need it)
        * `SpatialPerception`
        * `Microphone`
        * `PicturesLibrary` (probably won't need it)
        * `VideosLibrary` (probably won't need it)
        * `MusicLibrary` (probably won't need it)
        * (Might also need `InternetClient`)
        * (Might also need `Proximity`)
        * (Might also need `Location`)
      * Under `Other Settings > Rendering`:
        * check `Virtual Reality Supported.
        * select `Windows Holographic` for the device.
 * Close `Build Settings`.
* Save the Project (`File > Save Project`).
* Open `File > Build settings...`
  * Click `Build`
    * Create a directory named `App`.
    * Note the full path of the `App` directory.
    * Select that folder and click `OK`.


## DEPLOY UNITY APP TO HOLOLENS
* Open the Unity-created SLN file in Visual Studio 2015.
  * Right-click Package.appxmanifest and select `View code`.
    * Change `Package > Dependencies > TargetDeviceFamily > @Name` to `Windows.Holographic`.
    * Change `Package > Dependencies > TargetDeviceFamily > @MaxVersionTested` to `10.0.10586.0`.
  * Pair HoloLens with dev PC.
    * On HoloLens, go to `Settings`:
      * Go to `Network & Internet > Advanced options` and note `IPv4 address`.
      * Go back to `Settings > Update & security > For developers`.
        * Enable `Developer mode`.
        * Enabled `Device portal`.
    * Change build configuration to `Debug, x86` and select either:
      * `HoloLens Emulator`.
      * `Device`.
      * `Remote Machine`:
        * Enter the IP Address of the HoloLens.
        * For `Authentication Mode` use `Universal (Unencrypted protocol)`
    * Select `Debug > Start without debugging`.
      * The first time deploying to a real HoloLens (not the Emulator) from a particular dev PC requires pairing the two devices together with a PIN.
        * When prompted for PIN on dev PC, open `Settings > Updates & security > For developers` on HoloLens and click `Pair`.
        * Enter the PIN number that HoloLens displays into textbox on dev PC.
        * You'll be prompted to create a user account for the Device Portal.
        * You can now access the Device Portal at https://<HOLOLENS_IP_ADDRESS>
  * After several seconds of deployment process, view the running app on the HoloLens.

## TODO

### READING (Mark your initials next to each entry when complete)
* Understanding HoloLens
  * [Hologram](https://developer.microsoft.com/en-us/windows/holographic/hologram) - (STM)
  * [Hardware details](https://developer.microsoft.com/en-us/windows/holographic/hardware_details) - (STM)
    * Only a 32-bit processor.
    * Only about 2 to 3 hours of use.
    * 64GB of storage.
    * 2GB of RAM.
  * [HoloLens shell overview](https://developer.microsoft.com/en-us/windows/holographic/hololens_shell_overview) - (STM)
    * App views are either standard 2D or Holographic.
    * Only one Holographic app is allowed at a time.
    * Multiple 2D apps are allowed to run.
    * Holographic apps that need to use the virtual keyboard have to first switch to 2D mode.
  * [App views on HoloLens](https://developer.microsoft.com/en-us/windows/holographic/app_views_on_hololens) - (STM)
  * [Using mixed reality capture](https://developer.microsoft.com/en-us/windows/holographic/using_mixed_reality_capture) - (STM)
    * MR capture throttles framerate to 30Hz.
  * [Working with accessories](https://developer.microsoft.com/en-us/windows/holographic/working_with_accessories) - (STM)
    * Bluetooth audio is not supported.
    * Bluetooth gamepads that are not the Xbox One S Wireless Controller will be hit-or-miss.
* Developing for HoloLens
  * [Development overview](https://developer.microsoft.com/en-us/windows/holographic/development_overview) - (STM)
    * [Holographic Academy](https://developer.microsoft.com/en-us/windows/holographic/academy)
  * [App model](https://developer.microsoft.com/en-us/windows/holographic/app_model) - (STM)
    * It's all just standard Universal Windows Platform apps.
    * Only one app runs at a time.
    * Multiple instances of a single app are treated as just different "entry points" into the app. It's only one app.
    * Switching between instances of a single app causes that app to be activated with different TileIds.
    * Switching between different apps causes the last app to be suspended and the next app to resume.
    * A single app can have multiple views, and they can be either holographic or 2D.
    * (some details on switching view modes that I don't yet understand, will need to reference in the future.)
    * 2D app views are a fixed resolution and aspect ratio. Resizing them just makes them bigger/"zoomed in".
    * Dealing with file saving and loading is possible, but sounds super annoying.
  * [Install the tools](https://developer.microsoft.com/en-us/windows/holographic/install_the_tools) - (STM)
  * [Using Visual Studio](https://developer.microsoft.com/en-us/windows/holographic/using_visual_studio) - (STM)
    * `Developer mode` on the HoloLens has to be enabled first, see setup instructions above.
    * Use the x86 build configuration. HoloLens runs a 32-bit Intel processor.
    * Use the emulator for quick tests. Both the `Device` and `Remote Machine` deployments take a significant amount of time to deploy, and the HoloLens does not have a large battery.
    * The Graphics Debugger and Profiler are their own types of application starters, you don't need to start the app first.
    * Don't close the Emulator or power off the HoloLens before turning off the Graphics Debugger or Profiler.
  * [Using the HoloLens emulator](https://developer.microsoft.com/en-us/windows/holographic/using_the_hololens_emulator) - (STM)
    * WASD keys or Xbox controller left-stick to move.
    * Drag mouse, arrow keys, or Xbox controller right-stick to look around.
    * Right click, enter key, or A button on Xbox controller to air-tap.
    * Win-key, F2, or B button on Xbox controller for bloom.
    * Hold the Alt + Right click + drag mouse up and down, or right trigger + A button + right stick up and down for hand movement scrolling.
    * There are a number of different "rooms" of test data to use with the emulator.
  * [Using the Windows device portal](https://developer.microsoft.com/en-us/windows/holographic/using_the_windows_device_portal) - (STM)
    * A lot of the management of the HoloLens is a lot easier over the Device Portal than in the device itself.
    * Can also use it to download an OBJ file of the room data.
  * [Performance recommendations](https://developer.microsoft.com/en-us/windows/holographic/performance_recommendations) - (STM)
    * In general, try not to use any sort of deferred shading.
    * Need to maintain 60FPS.
    * No more than 1 frame of latency.
    * Keep memory usage under 900MB.
    * Read the article for the rest.
  * [Testing](https://developer.microsoft.com/en-us/windows/holographic/testing) - (STM)
    * In many rooms, with different features, crossing room boundaries, up and down stairs.
    * In a variety of lighting conditions. Though note, HoloLens is not meant for outdoor use.
    * In a variety of noise conditions.
    * In different motion conditions. Moving versus standing still. Crouched. Sitting.
    * From a variety of angles, and with real world objects in the way.
    * Use spatial audio cues.
    * At a variety of distances.
    * Test the App Bar.
    * Test to make sure the app works in a reasonable manner when the position is unknown.
  * [Submitting an app to the Windows Store](https://developer.microsoft.com/en-us/windows/holographic/submitting_an_app_to_the_windows_store) - (STM)
    * Read at least the section on `Packaging an app for HoloLens`, as it includes specifications for icons that will be necessary for any app, not just those submitted to the Windows Store.
  * [FAQ](https://developer.microsoft.com/en-us/windows/holographic/faq) - (STM)
  * [Release notes](https://developer.microsoft.com/en-us/windows/holographic/release_notes) - (STM)
    * Microsoft HoloLens Commercial Suite and Kiosk mode will be important.
  * [Known issues](https://developer.microsoft.com/en-us/windows/holographic/known_issues) - (STM)
    * Use a Bluetooth keyboard to enter WiFi passwords.
* Building blocks of Holographic apps
  * [World coordinates](https://developer.microsoft.com/en-us/windows/holographic/coordinate_systems) - (STM)
    * Values are in meters.
    * Coordinate system is right-handed (because of Direct3D).
      * +x is right
      * +y is up
      * +z is backwards
        * This is the opposite of OpenGL, which is left-handed, where +z is forwards.
    * The origin is anchored to a "stationary frame of reference" that is fixed for the room. They move as the system updates to figure out the true structure of the room.
    * Spatial Anchors can be placed that compensate for the shifting of the Spatial Frame of Reference and maintain their relative position to each other.
    * Objects in Spatial Frame of Reference stay in rigid relationship to each other, but may appear to drift apart.
    * Objects on Spatial Anchors may appear unmoved, but may have to update their relationship between each other.
    * Keep objects within 3 meters of a Spatial Anchor to avoid compounding error effects.
    * Spatial Anchors can be persisted to a special store just for them.
    * Objects can also be persisted, with their Spatial Anchor recorded, so their location can be recalled even after application reload.
    * Spatial Anchors and environment maps can be shared between HoloLens devices so separate uses can see objects appear in the same location.
    * Objects can be attached to the user in an "attached frame of reference".
      * This is also the fallback mode when position is unknown.
      * Test to make sure the app works in a reasonable manner when the position is unknown.
    * Avoid head-locked content. Even cursors should be placed in World Coordinates, landing on the objects at which they are pointing.
    * Tracking errors:
      * Covering the sensors or using the device in low light can cause a loss in position tracking.
        * Make suggestions to the user to try to get tracking back.
      * Lots of moving objects can confuse the sensor, causing holograms to appear to jump or drift.
      * Significant changes to the environment over time can cause holograms to drift.
      * Very similar environments can be recognized as the same environment, which can cause holograms in one to show up in the other.
  * [Gaze input](https://developer.microsoft.com/en-us/windows/holographic/gaze) - (STM)
    * Don't track the hand directly. Track the gaze, then when the hand is activated, use it for relative adjustments.
    * Move the cursor to where the gaze ray intersects an object.
    * Provide contextual actions at the gaze point through gestures or voice.
  * [Gesture input](https://developer.microsoft.com/en-us/windows/holographic/gestures)
  * [Voice input](https://developer.microsoft.com/en-us/windows/holographic/voice_input)
  * [Spatial sound](https://developer.microsoft.com/en-us/windows/holographic/spatial_sound)
  * [Spatial mapping](https://developer.microsoft.com/en-us/windows/holographic/spatial_mapping)
* Building 2D apps
  * [Building 2D apps](https://developer.microsoft.com/en-us/windows/holographic/building_2d_apps)
  * [Current limitations for apps using APIs from the shell](https://developer.microsoft.com/en-us/windows/holographic/current_limitations_for_apps_using_apis_from_the_shell)
* Building holographic apps with Unity
  * [Unity development overview](https://developer.microsoft.com/en-us/windows/holographic/unity_development_overview)
  * [Recommended settings for Unity](https://developer.microsoft.com/en-us/windows/holographic/recommended_settings_for_unity)
  * [Performance recommendations for Unity](https://developer.microsoft.com/en-us/windows/holographic/performance_recommendations_for_unity)
  * [Exporting and building a Unity Visual Studio solution](https://developer.microsoft.com/en-us/windows/holographic/exporting_and_building_a_unity_visual_studio_solution)
  * [Best practices working with Unity and Visual Studio](https://developer.microsoft.com/en-us/windows/holographic/best_practices_for_working_with_unity_and_visual_studio)
* Designing hologram
  * [Designing for mixed reality](https://developer.microsoft.com/en-us/windows/holographic/designing_for_mixed_reality)
  * [Types of holographic apps](https://developer.microsoft.com/en-us/windows/holographic/types_of_holographic_apps)
  * [Cursor](https://developer.microsoft.com/en-us/windows/holographic/cursors)
  * [Gaze targeting](https://developer.microsoft.com/en-us/windows/holographic/gaze_targeting)
  * [Gesture design](https://developer.microsoft.com/en-us/windows/holographic/gesture_design)
  * [Voice design](https://developer.microsoft.com/en-us/windows/holographic/voice_design)
  * [Spatial sound design](https://developer.microsoft.com/en-us/windows/holographic/spatial_sound_design)
  * [Spatial mapping design](https://developer.microsoft.com/en-us/windows/holographic/spatial_mapping_design)
  * [Color design](https://developer.microsoft.com/en-us/windows/holographic/color_design)
  * [Updating your existing universal app for HoloLens](https://developer.microsoft.com/en-us/windows/holographic/updating_your_existing_universal_app_for_hololens)
* [Case studies](https://developer.microsoft.com/en-us/windows/holographic/case_studies)
* Unity HoloLens Forum
  * [Known issues](http://forum.unity3d.com/threads/known-issues.394627/) - (STM)
    * D3D is the recommended build type over XAML because XAML apps sometimes fail to start. However, this also prevents use with the virtual keyboard.
    * Mixed Reality Capture is not supported.
    * Unity's "Play Mode" does not deploy to the HoloLens. Need to follow the normal, Visual Studio-based deployment process.
* [Holographic Academy](https://developer.microsoft.com/en-us/windows/holographic/academy)
  * [Holograms 100](https://developer.microsoft.com/en-us/windows/holographic/holograms_100) - (STM)
    * Chapter 1 - Creating a default, empty, 3D project.
    * Chapter 2 - Basic Scene Rendering settings.
    * Chapter 3 - Making a cube.
    * Chapter 4 - Project Settings.
    * Chapter 5 - Deployment.
  * [Holograms 101E - Introduction with Emulator](https://developer.microsoft.com/en-us/windows/holographic/holograms_101e)
  * [Holograms 101 - Introduction with Device](https://developer.microsoft.com/en-us/windows/holographic/holograms_101)
  * [Holograms 210 - Gaze](https://developer.microsoft.com/en-us/windows/holographic/holograms_210)
  * [Holograms 211 - Gesture](https://developer.microsoft.com/en-us/windows/holographic/holograms_211)
  * [Holograms 212 - Voice](https://developer.microsoft.com/en-us/windows/holographic/holograms_212)
  * [Holograms 220 - Spatial sound](https://developer.microsoft.com/en-us/windows/holographic/holograms_220)
  * [Holograms 230 - Spatial mapping](https://developer.microsoft.com/en-us/windows/holographic/holograms_230)
  * [Holograms 240 - Sharing holograms](https://developer.microsoft.com/en-us/windows/holographic/holograms_240)
* Other
  * [Spatial Anchors](https://developer.microsoft.com/en-us/windows/holographic/spatial_anchors)
