# OmniVirt Ad Network: Monetize your Unity Game with 360° Video / VR Ad (iOS, Android, Cardboard, Gear VR, Daydream)

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/screenshot3.jpg)

**OmniVirt Ad Network** is ***VR Advertising Network*** which enables developers and publishers to monetize their apps/games with seamless and engaging VR experiences.

Simply integrate the OmniVirt SDK into your Unity application/game and get paid for presenting sponsored 360° video experiences to your users. Backfill your inventory with premium CPM experiences from OmniVirt’s network of advertisers. We support both 360° and 2D video ads inside VR apps.

OmniVirt Ad Network could be used on **Unity 5.3 or newer**.

# Usage

**OmniVirt Ad Network** can be integrated into your Unity game in just few easy steps.

## Get Started

1. **Sign up** for an account at [OmniVirt](https://www.omnivirt.com/ad-network/)
2. **Create one or more Ad Spaces** for your app (for each Ad Space you can select different content and will get separate reporting)
3. Keep the **AdSpace ID** assigned for further use.

Now an Ad Space is ready. Next step is to enable the Ad on your application/game.

## Add the OmniVirt SDK to your project

1) Download [OmniVirtSDK.unitypackage](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/OmniVirtSDK.unitypackage)

2) Import it to your Unity project via **Assets -> Import Package -> Custom Package** menu.

![Import](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/importpackage3.jpg)

Your project will now contain all necessary files to integrate OmniVirt Ad Network in your game.

## Switch Platform

Currently OmniVirt Ad Network for Unity is supported only on iOS and Android. So to make it works, you need to switch platform to either iOS or Android first. To do so, click at **File -> Build Settings**, choose your target platform (iOS or Android) and then click **Switch Platform**.

![Switch Platform](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/switchplatform.jpg)

Please note that if you do not switch the platform, your code will not be able to compile.

## Prepare a script

First, create an empty GameObject in the scene.

![GameObject](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/emptygameobject.jpg)

And then, create a C# script and rename it to `AdNetworkControl`.

![VRPlayerController](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/adnetworkcontrol.jpg)

**Drag** the script and **drop** it on a created GameObject to assign it to the scene.

![DragDropScript](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/dragdropscript.jpg)

## Initialize a `VRAd` instance

Open `AdNetworkControl.cs` file and add the following line in the header area.

```csharp
using OmniVirt;
```

Declare `VRAd` variable and initialize in `Start()` function.

```csharp
public class AdNetworkControl : MonoBehaviour {

    VRAd vrAd;

    // Use this for initialization
    void Start () {
        vrAd = new VRAd (AD_SPACE_ID); // Replace your Ad Space ID here
        // Register a Callback
        vrAd.AdStatusChanged += OnAdStatusChanged;
    }

    // Update is called once per frame
    void Update () {

    }

    void OnAdStatusChanged() {

    }
  
}
```

**Please note that your must replace `AD_SPACE_ID` with one you got from step above.**

## Load an Ad

Ad must be loaded first before it could be shown. Call `LoadAd()` like shown below to start loading.

```csharp
    // Use this for initialization
    void Start () {
        vrAd = new VRAd (AD_SPACE_ID); // Replace your Ad Space ID here
        // Register a Callback
        vrAd.AdStatusChanged += OnAdStatusChanged;

        // Prepare an Ad
        vrAd.LoadAd();
    }
```

Ad will now be loaded **in the background** and once it is ready, `OnAdStatusChanged` will be called with `Ready` state.

## Show an Ad

If you want ad to start playing automatically, just add the following code snippet to the callback function.

```csharp
...
void OnAdStatusChanged() {
    if (vrAd.IsReady ()) {
        vrAd.Show (false);
    }
}
...
```

### Show an Ad in VR Mode

You can trig the ad to be displayed in VR Mode by passing a parameter in `show()` function like shown below.

```csharp
vrAd.Show (true);
```

With this feature, you will be able to make Ad show with seamless experience as your VR app / game.

And it's all ... done ! Ad will now be shown on the screen.

## Reload an Ad

**`LoadAd()` is needed to be called once per ad served.** You can reload an ad to make it ready for the next session by implementing the code inside `OnAdStatusChanged` like shown below.

```csharp
...

IEnumerator ReloadAd() {
    yield return null;

    if (vrAd != null) {
        vrAd.Unload ();
        vrAd = null;
    }

    vrAd = new VRAd (AD_SPACE_ID);       // REPLACE YOUR AD_SPACE_ID HERE
    vrAd.AdStatusChanged += OnAdStatusChanged;
    vrAd.LoadAd ();
}
    
void OnAdStatusChanged() {
    if (vrAd.IsCompleted ()) {
        // Reload an ad for next session
        StartCoroutine (ReloadAd ());
    }
}
...
```

## Callback

When the state of VRAd has been changed, `OnAdStatusChanged` callback function will be called with the new state in the `AdStatusChangedEventArgs` parameter.

```csharp
...
void OnAdStatusChanged() {
    // New AdState could be retrieved from vrAd.adState
}
...
```

There are different 5 states in total.

- **AdState.Loading** - Ad is being loaded in the background.

- **AdState.Ready** - Ad is ready to be shown. You can call `Show()` function at this state to display the loaded ad.

- **AdState.Showing** - Ad is being displayed.

- **AdState.Completed** - Ad display is finished.

- **AdState.Failed** - Ad could not be loaded.

## Handle Back Pressed

On Android, **back button** is needed to be handled to prevent unexpected behavior.

```csharp
    void Update () {
        // Handle Back Button
        if (Input.GetKeyDown (KeyCode.Escape)) {
            // If Ad is being shown, it will be automatically hide.
            // Don't do anything.
            if (vrAd.IsShowing ())
              return;

            // Else, do whatever you want, for example, quit the app
            //Application.Quit ();
        }
    }
```

## iOS Build

Bitcode is not supported on OmniVirt SDK yet. Please turn the Bitcode off by set `Build Settings -> Bitcode` to **off** for your deployment target.

![Import](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/bitcode.jpg)

# Questions?

If you have any question, please don't hesitate to email us at [adnetwork@omnivirt.com](mailto:adnetwork@omnivirt.com) !
