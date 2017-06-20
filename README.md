# OmniVirt Ad Network: Monetize your VR app with Unity Framework
![API](https://img.shields.io/badge/API-17%2B-blue.svg?style=flat)

![Screenshot](https://github.com/OmniVirt/OmniVirtAdNetwork-Android-Example/blob/master/screenshotad.jpg?raw=true)

**OmniVirt Ad Network** provides you ***an advertising platform*** enables developers and publishers to monetize their apps with engaging VR content in seamless user experience way.

Simply integrate the OmniVirt SDK into your iOS, Android or Web application and get paid for presenting sponsored 360° video experiences to your users. Backfill your inventory with premium CPM experiences from OmniVirt’s network of advertisers. We support both 360° and 2D video ads inside VR apps.

Visit [omnivirt.com](https://omnivirt.com/) to create ad space to start monetizing. Contact us for more info at [contact@omnivirt.com](mailto:contact@omnivirt.com).

## Import OmniVirt Unity Framework to your Unity project
 
Search for OmniVirt VRKit from Unity Asset Store or download OmniVirt Unity package from [here](https://www.dropbox.com/s/t5ajbgzb4gwbria/vrkit-unity.zip?dl=0).

## Usage

**OmniVirt Ad Network** can be integrated into your Android application in just few easy steps.

### Get Started

1. **Sign up** for an account at [OmniVirt](www.omnivirt.com)
2. **Create one or more Ad Spaces** for your app (for each Ad Space you can select different content and will get separate reporting)
3. Keep the **AdSpace ID** assigned for further use.

Now an Ad Space is ready. Next step is to enable the Ad on your application.


### Initialize a `VRAd` instance
 
First of all, create an `VRAd` instance with **AdSpace ID** provided by step above along with the callback listener.
```cs
...
protected VRAd myAd;

void Start() {
  myAd = new VRAd(AD_SPACE_ID, /* TBD: Show event handler */);
  myAd.load();
}
...
```

Ad will now be loaded **in the background** and once it is ready, `onAdStatusChanged` will be called with `Ready` state.

### Show an Ad

If you want ad to start playing automatically, just add the following code snippet to the callback function.

```java
...
@Override
public void onAdStatusChanged(VRAd vrAd, AdState adState) {
    if (vrAd.isLoaded()) {
        vrAd.show();
    }
}
...
```

And it's all ... done ! Ad will now be shown on the screen.

### Reload an Ad

**`load(...)` is needed to be called once per ad served.** You can reload an ad to make it ready for the next session by implementing the code inside `onAdStatusChanged` like shown below.

```java
...
@Override
public void onAdStatusChanged(VRAd vrAd, AdState adState) {
    ...
    if (vrAd.isCompleted())
        vrAd.load(MainActivity.this);
}
...
```

### Callback

When the state of VRAd has been changed, `onAdStatusChanged` callback function will be called with the new state in the `adState` parameter.

```java
...
@Override
public void onAdStatusChanged(VRAd vrAd, AdState adState) {
    // Check adState
}
...
```

There are different 5 states in total.

- **AdState.Loading** - Ad is being loaded in the background.

- **AdState.Ready** - Ad is ready to be shown. You can call `show()` function at this state to display the loaded ad.

- **AdState.Showing** - Ad is being displayed.

- **AdState.Completed** - Ad display is finished.

- **AdState.Failed** - Ad could not be loaded.

### Handle Back Pressed

In case that user press **back button** while ad is playing, `onBackPressed` is needed to be handled to prevent unexpected behavior. For example, if you want to let ad close and return to your normal Activity, this code snippet is needed to be added in your Activity.

```cs
    ????
```

But if you want to prevent user from pressing back, you can just comment `vrAd.unloadAd();` and it will work like you wish.

# Questions?

If you have any question, please don't hesitate to email us at [contact@omnivirt.com](mailto:contact@omnivirt.com) !