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
  * (Optional) Install [Visual Studio 2015 Tools for Unity](https://visualstudiogallery.msdn.microsoft.com/8d26236e-4a64-4d64-8486-7df95156aba9)

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

## READING (Mark your initials next to each entry when complete)

### WINDOWS HOLOGRAPHIC
[Windows Holographic Documentation](https://developer.microsoft.com/en-us/windows/holographic/documentation) - (STM)
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
  * [Gesture input](https://developer.microsoft.com/en-us/windows/holographic/gestures) - (STM)
    * System can track both hands separately.
    * System ignores hands that are not in Ready or Pressed state.
    * Bloom is not a positionally tracked gesture.
    * Gesture recognition is wider than FOV, but only by about 50% per side.
    * The Clicker doesn't need to be in the gesture volume.
  * [Voice input](https://developer.microsoft.com/en-us/windows/holographic/voice_input) - (STM)
    * Provide labels on objects that have voice interaction.
    * A few commands:
      * Select
      * Face me
      * Bigger | Enhance
      * Smaller
      * Hey Cortana...
      * Remove
      * Place
  * [Spatial sound](https://developer.microsoft.com/en-us/windows/holographic/spatial_sound) - (STM)
    * "Window's spatial sound engine only supports 48k samplerate for playback. Most middleware programs, like Unity, will automatically convert sound files into the supported format, but when using Windows Audio APIs directly please match the format of the content to the format supported by the effect."
  * [Spatial mapping](https://developer.microsoft.com/en-us/windows/holographic/spatial_mapping)
    * Holograms that interact with the real world surface seem more real.
    * Occlusion makes them feel solid.
      * Consider rendering occluded objects at reduced brightness if the user needs to find them.
    * Draw a shadow on the ground surface under holograms that are being placed.
    * Raw spatial data is pretty rough.
    * (continue)
* Building 2D apps
  * [Building 2D apps](https://developer.microsoft.com/en-us/windows/holographic/building_2d_apps) - (STM)
    * Only concerning existing apps.
  * [Current limitations for apps using APIs from the shell](https://developer.microsoft.com/en-us/windows/holographic/current_limitations_for_apps_using_apis_from_the_shell) - (STM)
    * No support for:
      * Notifications
      * Share Contract
      * Windows Shell localization (localization still available for apps)
      * File explorer
      * Toast API
      * Contacts
      * Calendars
      * EmailRT and MessagingRT
      * App services (for now)
      * Printing-related operations
* Building holographic apps with Unity
  * [Unity development overview](https://developer.microsoft.com/en-us/windows/holographic/unity_development_overview) - (STM)
    * Just covers basic setup again.
  * [Recommended settings for Unity](https://developer.microsoft.com/en-us/windows/holographic/recommended_settings_for_unity) - (STM)
    * Get a Pro license to be able to show a custom splash screen.
    * Unity stops rendering on a tracking loss. A splash screen can optionally be shown.
      * This behavior can be disabled at `Edit > Project Settings... > Player` page, click on the `Windows Store` tab and find the `Windows Holographic > On Tracking Loss Pause and Show Image` checkbox.
      * If you do this, only show body-locked holograms when tracking is lost.
    * Don't really need the MusicLibrary permission for this app.
    * The Picture- and Video-related permissions are only important for taking screenshots.
  * [Performance recommendations for Unity](https://developer.microsoft.com/en-us/windows/holographic/performance_recommendations_for_unity)
  * [Exporting and building a Unity Visual Studio solution](https://developer.microsoft.com/en-us/windows/holographic/exporting_and_building_a_unity_visual_studio_solution) - (STM)
    * Need to re-export after:
      * Adding or removing assets in the Project tab.
      * Changing any value in the Inspector tab.
      * Adding or removing objects from the Hierarchy tab.
      * Changing any Unity project settings.
    * Build configs:
      * Debug is debug.
      * Master is the new Release.
      * Release is an intermediate debug for performance (profiling).
  * [Best practices working with Unity and Visual Studio](https://developer.microsoft.com/en-us/windows/holographic/best_practices_for_working_with_unity_and_visual_studio) - (STM)
    * Switch to text-based assets to make diffing easier.
    * Regenerate UWP Visual Studio solutions after Windows SDK or Unity upgrade.
    * Public class variables are editable in the Unity property grids.
  * Additional links
    * [Camera](https://developer.microsoft.com/en-us/windows/holographic/camera_in_unity) - (STM)
      * Content is a repeat of "Start a new Unity Project for Hololens".
    * [Gaze](https://developer.microsoft.com/en-us/windows/holographic/gaze_in_unity)
    * [Gestures](https://developer.microsoft.com/en-us/windows/holographic/gestures_in_unity)
    * [Voice Input](https://developer.microsoft.com/en-us/windows/holographic/voice_input_in_unity)
    * [World Anchors](https://developer.microsoft.com/en-us/windows/holographic/world_anchor_in_unity)
    * [Persistence](https://developer.microsoft.com/en-us/windows/holographic/persistence_in_unity)
    * [Spatial Sound](https://developer.microsoft.com/en-us/windows/holographic/spatial_sound_in_unity)
    * [Spatial Mapping](https://developer.microsoft.com/en-us/windows/holographic/spatial_mapping_in_unity)
    * [Shared Holograms](https://developer.microsoft.com/en-us/windows/holographic/shared_holographic_experiences_in_unity)
    * [Locatable Camera](https://developer.microsoft.com/en-us/windows/holographic/locatable_camera_in_unity)
    * [Focus Point](https://developer.microsoft.com/en-us/windows/holographic/focus_point_in_unity)
    * [Tracking Loss](https://developer.microsoft.com/en-us/windows/holographic/tracking_loss_in_unity)
    * [Keyboard Input](https://developer.microsoft.com/en-us/windows/holographic/keyboard_input_in_unity)
* Designing holograms
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

[Holographic Academy](https://developer.microsoft.com/en-us/windows/holographic/academy)
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

Other
* [Spatial Anchors](https://developer.microsoft.com/en-us/windows/holographic/spatial_anchors)

### UNITY DOCUMENTATION
[Unity Manual](https://docs.unity3d.com/Manual/index.html)
* [Overview](https://docs.unity3d.com/Manual/UnityOverview.html)
  * [Basics](*https://docs.unity3d.com/Manual/UnityBasics.html)

[Unity Tutorials](https://unity3d.com/learn/tutorials)