# Unity VR/Billboard Ads - OmniVirt Ad Network for Unity (iOS, Android, Cardboard, Gear VR, Daydream)

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/cover5.jpg)

Meet the OmniVirt's Unity VR Ad SDK. **OmniVirt Ad Network** is ***VR Advertising Network*** which enables developers and publishers to monetize their apps/games with seamless and engaging VR experiences.

Simply integrate the OmniVirt Unity Ad SDK into your Unity application/game and get paid for presenting sponsored 360° video experiences and/or in-game billboard ad to your users. Backfill your inventory with premium CPM experiences from OmniVirt’s network of advertisers. We support both 360° and 2D video ads inside VR apps.

OmniVirt Unity Ad SDK could be used on **Unity 5.4 or newer**.

# Ad Format

There are two formats of Ad available in OmniVirt Unity Ad Network SDK

1) **Billboard Ad** - Provide the billboard ad that can be shown seemlessly with your game scene.

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/billboardad.jpg)

2) **Fullscreen Ad** - Provides the skippable immersive fullscreen video ad for your game.

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/fullscreenad.jpg)

Now let us show you how easy you could integrate our Ad Network SDK to your game!


# Get Started

## Create your first app and ad space

Do the following steps to create an app and the first ad space associated in the OmniVirt system.

1. **Sign up** for an account at [OmniVirt](https://www.omnivirt.com/ad-network/).
2. Go to [**My Apps**](https://upload.omnivirt.com/monetization) page under Dashboard and click at **Submit App** button.

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/submitapp3.jpg)

3. Fill in your VR app's name and click **next**.

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/appdetails.jpg)

4. Fill in your first Ad Space details, choose the Ad Format you wish to use for this Ad Space. If you want to go for the fullscreen ad one, please choose *VR Full-Screen*. In case you want to integrate the billboard ad, choose the orientation that fit your ad unit in the scene best either horizontal or vertical one. Please note that you can create more Ad Space for your app later. This is just the first one. After everything is filled, click at **Finish**

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/adspacedetails.jpg)

5. Keep the **AdSpace ID** assigned for further use. *Don't use the number being shown here, please use yours otherwise the ad revenue will not go to your account.*

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/getadspaceid.jpg)

Now an Ad Space is ready. Next step is to enable the Ad on your application/game.

## Import the OmniVirt SDK to your project

1) Download [OmniVirtSDK.unitypackage](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/OmniVirtSDK.unitypackage)

2) Import it to your Unity project via **Assets -> Import Package -> Custom Package** menu.

![Import](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/importpackage3.jpg)

Your project will now contain all necessary files to integrate OmniVirt Unity VR ads in your game.

## Switch Platform

Currently OmniVirt Ad Network for Unity is supported only on iOS and Android. So to make it works, you need to switch platform to either iOS or Android first. To do so, click at **File -> Build Settings**, choose your target platform (iOS or Android) and then click **Switch Platform**.

![Switch Platform](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/switchplatform.jpg)

Please note that if you do not switch the platform, your code will not be able to compile.


# Integrate Billboard Ad to your app

Here is the steps to integrate the billboard ad to your game scene.

## Prepare the Ad Space ID

Before going to the next step, please make sure that you have already created an app and an ad space with **VR Billboard** ad format with the desired orientation since Ad space ID with the correct format is required.

## Prepare a script

First let's prepare the script to put our logic code inside. To do so, let's create an empty GameObject in the scene.

![GameObject](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/emptygameobject.jpg)

And then, create a C# script and rename it to `BillboardAdControl`.

![VRPlayerController](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/newcsscriptbillboardad320.jpg)

**Drag** the script and **drop** it on a created GameObject to assign it to the scene.

![DragDropScript](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/dragdropbillboardad320.jpg)


## Initialize a `BillboardAd` instance

Open `BillboardAdControl.cs` file and add the following line in the header area.

```csharp
using OmniVirt;
```

Declare `BillboardAd` variable and initialize in `Start()` function.

```csharp
public class BillboardAdControl : MonoBehaviour {

    public GameObject adPlane;

    BillboardAd billboardAd;

    // Use this for initialization
    void Start () {
        billboardAd = new BillboardAd(AD_SPACE_ID);
        billboardAd.LoadAd(adPlane);
    }

    // Update is called once per frame
    void Update () {

    }
}
```

**Please note that your must replace `AD_SPACE_ID` with one you got from step above.**

## Placing Billboard Ad Plane to your scene

## Assign Ad Plane to your script

## Run and test

*Developing...*


# Integrate Fullscreen Ad to your app

Please follow the instructions in this section to enable fullscreen ad in your app.

## Prepare the Ad Space ID

As same as the billboard ad one, before going to the next step, please make sure that you have already created an app and an ad space with **VR Full-Screen** ad format since Ad space ID with the correct format is required.

## Prepare a script

First let's prepare the script to put our logic code inside. To do so, let's create an empty GameObject in the scene.

![GameObject](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/emptygameobject.jpg)

And then, create a C# script and rename it to `AdNetworkControl`.

![VRPlayerController](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/newcsscript3320.jpg?v=2)

**Drag** the script and **drop** it on a created GameObject to assign it to the scene.

![DragDropScript](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/dragdropscript320.jpg)

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

Ad will now be loaded **in the background** and once it is ready, `OnAdStatusChanged` will be called with `Ready` state. Please note that the whole video file of the ad will be downloaded before changing the state. This will make the ad be able to play at super efficient performance in your app. Cache is also implemented so the next time the same ad is requested, it will use the local file instead of downloading the same file again.

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

And that's all ... done! Please run your code and see if everything is working correctly. Expected result is **Fullscreen Ad should be shown at the place you call `Show` function.** Easy, huh? =D

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

# Extras

## Day Dream Controller Support

Since Day Dream game controller support is required on Day Dream compatible application / game, OmniVirt SDK also provides support on this funcionality as well. You can enable it with some easy following steps.

1) Import [Google VR SDK for Unity](https://github.com/googlevr/gvr-unity-sdk/releases) into your project. If your application or game is built for Day Dream, it supposes to have this SDK installed in your project already.

2) Add `GvrControllerMain` and `GvrEditorEmulator` prefab to the scene.

![Gvr](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/daydream_gvrscene.png)

3) Add `OmniVirtGameController` script to **`GvrControllerMain`** game object. (It is important to add script to the correct one otherwise it would not work).

![Add Component](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/daydream_addcomponent2.png)

That's all. Day Dream controller will now magically work with our VR Player in Day Dream mode !

## iOS Build

Bitcode is not supported on OmniVirt SDK yet. Please turn the Bitcode off by set `Build Settings -> Bitcode` to **off** for your deployment target.

![Import](https://github.com/OmniVirt/OmniVirtAdNetwork-Unity-Example/raw/master/Screenshots/bitcode.jpg)


# Questions?

If you have any question, please don't hesitate to email us at [adnetwork@omnivirt.com](mailto:adnetwork@omnivirt.com) !