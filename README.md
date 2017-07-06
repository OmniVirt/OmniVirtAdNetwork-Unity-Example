# OmniVirt Ad Network: Monetize your Unity Game with 360° Video Ad

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/screenshot.jpg)

**OmniVirt Ad Network** provides you ***an advertising platform*** enables developers and publishers to monetize their apps/games with engaging VR content in seamless user experience way.

Simply integrate the OmniVirt SDK into your Unity application/game and get paid for presenting sponsored 360° video experiences to your users. Backfill your inventory with premium CPM experiences from OmniVirt’s network of advertisers. We support both 360° and 2D video ads inside VR apps.

# Usage

**OmniVirt Ad Network** can be integrated into your Unity game in just few easy steps.

## Get Started

1. **Sign up** for an account at [OmniVirt](https://www.omnivirt.com)
2. **Create one or more Ad Spaces** for your app (for each Ad Space you can select different content and will get separate reporting)
3. Keep the **AdSpace ID** assigned for further use.

Now an Ad Space is ready. Next step is to enable the Ad on your application/game.

## Add the OmniVirt SDK to your project

1) Download [OmniVirtSDK.unitypackage](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/OmniVirtSDK.unitypackage)

2) Import it to your Unity project via **Assets -> Import Package -> Custom Package** menu.

![Import](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/importpackage.jpg)

Your project will now contain all necessary files to integrate OmniVirt Ad Network in your game.

## Prepare a script

First, create an empty GameObject in the scene.

![GameObject](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/emptygameobject.jpg)

And then, create a C# script and rename it to `VRPlayerControl`.

![VRPlayerController](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/adnetworkcontrol.jpg)

**Drag** the script and **drop** it a created GameObject to assign it to the scene.

![DragDropScript](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/dragdropscript.jpg)

## Initialize a `VRAd` instance

Open `AdNetworkControl.cs` file and add the following line in the header area.

```csharp
using OmniVirt;
```

Declare `VRAd` variable and initialize in `Start()` function.

```csharp
public class VRPlayerControl : MonoBehaviour {

    VRAd vrAd;

    // Use this for initialization
    void Start () {
        vrAd = new VRAd (AD_SPACE_ID);
        // Register a Callback
        vrAd.AdStatusChanged += OnAdStatusChanged;
    }

    // Update is called once per frame
    void Update () {

    }

    void OnAdStatusChanged(object sender, AdStatusChangedEventArgs e) {

    }
  
}
```

**Please note that your must replace `AD_SPACE_ID` with one you got from step above.**

## Load an Ad

Ad must be loaded first before it could be shown. Call `LoadAd()` like shown below to start loading.

```csharp
    // Use this for initialization
    void Start () {
        vrAd = new VRAd (AD_SPACE_ID);
        // Register a Callback
        vrAd.AdStatusChanged += OnAdStatusChanged;

        vrAd.LoadAd();
    }
```

Ad will now be loaded **in the background** and once it is ready, `OnAdStatusChanged` will be called with `Ready` state.

## Show an Ad

If you want ad to start playing automatically, just add the following code snippet to the callback function.

```csharp
...
void OnAdStatusChanged(object sender, AdStatusChangedEventArgs e) {
    if (vrAd.IsLoaded ()) {
        vrAd.Show (Mode.Off);
    }
}
...
```

### Show an Ad in VR Mode

You can trig the ad to be displayed in VR Mode by passing a parameter in `show()` function like shown below.

```csharp
vrAd.show (Mode.On);
```

With this feature, you will be able to make Ad show with seamless experience as your VR app / game.

And it's all ... done ! Ad will now be shown on the screen.

## Reload an Ad

**`LoadAd()` is needed to be called once per ad served.** You can reload an ad to make it ready for the next session by implementing the code inside `OnAdStatusChanged` like shown below.

```csharp
...
void OnAdStatusChanged(object sender, AdStatusChangedEventArgs e) {
    if (vrAd.IsCompleted ()) {
        vrAd.LoadAd ();
    }
}
...
```

## Callback

When the state of VRAd has been changed, `OnAdStatusChanged` callback function will be called with the new state in the `AdStatusChangedEventArgs` parameter.

```csharp
...
void OnAdStatusChanged(object sender, AdStatusChangedEventArgs e) {
    // New AdState could be retrieved from e.Status
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

# Questions?

If you have any question, please don't hesitate to email us at [contact@omnivirt.com](mailto:contact@omnivirt.com) !
