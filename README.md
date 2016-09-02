# SibleyHoloLens

An augmented reality application using the Microsoft HoloLens where a person can place the device on their head, leverage voice commands to navigate the menu options, and view an arrangement of religious icons within the chapel.

## DOCUMENTATION

* [Windows Holographic documentation](https://developer.microsoft.com/en-us/windows/holographic/documentation)
* [HoloLens Unity Development Overview](https://developer.microsoft.com/en-us/windows/holographic/unity_development_overview)
* [Unity HoloLens forum](http://forum.unity3d.com/forums/hololens.102/)

## STEPS

* [Install Tools](https://developer.microsoft.com/en-us/windows/holographic/install_the_tools):
  * [Install Visual Studio 2015](https://developer.microsoft.com/en-us/windows/downloads). Community Edition is acceptable.
  * Install HoloLens emulator.
  * Install Unity HoloLens Technology Preview.
  * Check back regularly for updates to emulator and Unity.
* Start a new, blank Unity project.
* Change the project settings:
  * Under `File > Build Settings...`:
    * Select `Windows Store`.
    * Change `SDK` to `Universal 10`.
    * Change `UWP Build Type` to `D3D`.
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
  * Under `Edit > Projects Settings > Quality`:
    * select the dropdown arrow under the row of checkboxes in the column for Windows Store.
    * select `Fastest` for the default render quality.
  * Save the Project (`File > Save Project`).
* Change the basic scene rendering settings:
  * Select the `Main Camera`.
  * Set its `position` to the origin `(0, 0, 0)`.
  * Change `Clear Flags` to `Solid Color`.
  * Change `Background` to solid black.
  * Change `Clipping Planes - Near` to `0.85` meters (as per HoloLens design recommendations).
  * Save the Scene (`CTRL+S`, or `File > Save Scene`).

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
    * Apps are either standard 2D or Holographic.
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
  * [App model](https://developer.microsoft.com/en-us/windows/holographic/app_model)
  * [Install the tools](https://developer.microsoft.com/en-us/windows/holographic/install_the_tools) - (STM)
  * [Using Visual Studio](https://developer.microsoft.com/en-us/windows/holographic/using_visual_studio)
  * [Using the HoloLens emulator](https://developer.microsoft.com/en-us/windows/holographic/using_the_hololens_emulator)
  * [Using the Windows device portal](https://developer.microsoft.com/en-us/windows/holographic/using_the_windows_device_portal)
  * [Performance recommendations](https://developer.microsoft.com/en-us/windows/holographic/performance_recommendations)
  * [Testing](https://developer.microsoft.com/en-us/windows/holographic/testing)
  * [Submitting an app to the Windows Store](https://developer.microsoft.com/en-us/windows/holographic/submitting_an_app_to_the_windows_store)
  * [FAQ](https://developer.microsoft.com/en-us/windows/holographic/faq)
  * [Release notes](https://developer.microsoft.com/en-us/windows/holographic/release_notes)
  * [Known issues](https://developer.microsoft.com/en-us/windows/holographic/known_issues) - (STM)
    * Use a Bluetooth keyboard to enter WiFi passwords.
* Building blocks of Holographic apps
  * [World coordinates](https://developer.microsoft.com/en-us/windows/holographic/coordinate_systems)
  * [Gaze input](https://developer.microsoft.com/en-us/windows/holographic/gaze)
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
  * [Updating your existing universal app for HoloLens]https://developer.microsoft.com/en-us/windows/holographic/updating_your_existing_universal_app_for_hololens)
* [Case studies](https://developer.microsoft.com/en-us/windows/holographic/case_studies)
* Unity HoloLens Forum
  * [Known issues](http://forum.unity3d.com/threads/known-issues.394627/) - (STM)
    * D3D is the recommended build type over XAML because XAML apps sometimes fail to start. However, this also prevents use with the virtual keyboard.
    * Mixed Reality Capture is not supported.
    * Unity's "Play Mode" does not deploy to the HoloLens. Need to follow the normal, Visual Studio-based deployment process.