# OmniVirt VR Player: 360° Video Player for Unity (iOS & Android)

![Screenshot](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/screenshot3.jpg)

**OmniVirt** makes the leading player for 360° video experiences across mobile and desktop. Upload your 360° content to OmniVirt and serve it into your app with few easy steps.

# Usage

**OmniVirt VR Player** for Unity provides you a really easy way to embed 360° content on your iOS and Android game with just few lines of code.

## Get Started

1. **Sign up** for an account at [OmniVirt](https://www.omnivirt.com)
2. **Upload** your VR / 360° photo or video on [OmniVirt](https://www.omnivirt.com/).
3. Keep the **Content ID** assigned to your content for further use.

Content is now ready. It is time to work on Unity editor.

## Add the OmniVirt SDK to your project

1) Download [OmniVirtSDK.unitypackage](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/OmniVirtSDK.unitypackage)

2) Import it to your Unity project via **Assets -> Import Package -> Custom Package** menu.

![Import](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/importpackage2.jpg)

Your project will now contain all necessary files to run OmniVirt VR Player.

## Switch Platform

Currently OmniVirt VR Player for Unity is supported only on iOS and Android. So to make it works, you need to switch platform to either iOS or Android first. To do so, click at **File -> Build Settings**, choose your target platform (iOS or Android) and then click **Switch Platform**.

![Switch Platform](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/switchplatform.jpg)

Please note that if you do not switch the platform, your code will not be able to compile.

## Prepare a script

You can now let you VR content played in your game with just a single line of code !

First, create an empty GameObject in the scene.

![GameObject](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/emptygameobject.jpg)

And then, create a C# script and rename it to `VRPlayerControl`.

![VRPlayerController](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/newcsscript2.jpg)

**Drag** the script and **drop** it a created GameObject to assign it to the scene.

![DragDropScript](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/dragdropscript.jpg)

## Launch a VR Player

Open `VRPlayerControl.cs` file and add the following line in the header area.

```csharp
using OmniVirt;
```

The following code snippet is used to launch a VR Player.

```csharp
vrPlayer.LoadAndPlay (CONTENT_ID,
                      true           // Cardboard Enabled; false for non-VR mode
                      );
```

Replace `CONTENT_ID` with a **Content ID** got from step above to let it play the specific content you need, for example,

```csharp
public class VRPlayerControl : MonoBehaviour {

	VRPlayer vrPlayer;

	// Use this for initialization
	void Start () {
		// Create VR Player instance
		vrPlayer = new VRPlayer ();

		// Register Callback for Video Playing Completion Event
		vrPlayer.OnVideoEnd += OnVRPlayerEnded;
		vrPlayer.OnUnloaded += OnVRPlayerUnloaded;

		// Play
		vrPlayer.LoadAndPlay (24, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*************************
	 * Callback for VR Player
	 *************************/

	// Video Playing Completion Event
	void OnVRPlayerEnded() {
		if (vrPlayer != null)
			vrPlayer.Unload ();
	}

	// VR Player Unloaded Event
	void OnVRPlayerUnloaded() {
		vrPlayer = null;		
	}
}
```

And ... done ! It is this easy ! You can now build project and run to test the VR Player.

## Extra: Earn Money

Would like to earn money from your 360° content? You can create an **Ad Space** on [OmniVirt](www.omnivirt.com) and pass the **Ad Space ID** acquired to the command like shown below to enable ad on the player.

```csharp
vrPlayer.LoadAndPlay (CONTENT_ID,
                      AD_SPACE_ID,   // AD Space ID
                      true           // Cardboard Enabled; false for non-VR mode
                      );
```

Once you set it up correctly, user will sometime see an ad among the player and that will turn into your revenue !

## Player Callback

Any change on the player could be detected by registering a callback function in the pattern like this.

```csharp
void Start () {
    ...
    
    // Register a Callback
    vrPlayer.OnVideoEnd += OnVRPlayerEnded;
}

// Video Playing Completion Event
void OnVRPlayerEnded() {

}
```

These are the list of callback functions available.

- **`OnVideoReady()`**

  Called when video is ready to play.

- **`OnVideoEnd()`**

  Called when VR Player has finished playing.

- **`OnUnloaded()`**

  Called when VR Player has been destroyed.


# Questions?

Please feel free to email us at [contact@omnivirt.com](mailto:contact@omnivirt.com) !
