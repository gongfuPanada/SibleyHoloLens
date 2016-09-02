# SibleyHoloLens

An augmented reality application using the Microsoft HoloLens where a person can place the device on their head, leverage voice commands to navigate the menu options, and view an arrangement of religious icons within the chapel.

# Documentation

[Windows Holographic documentation](https://developer.microsoft.com/en-us/windows/holographic/documentation)

[HoloLens Unity Development Overview](https://developer.microsoft.com/en-us/windows/holographic/unity_development_overview)

# Steps

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