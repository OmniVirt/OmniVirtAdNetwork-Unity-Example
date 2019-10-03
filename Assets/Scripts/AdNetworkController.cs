using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OmniVirt;

public class AdNetworkController : MonoBehaviour {

	public Button ShowAdButton;
	public GameObject Crate;
	public Image LogoImage;
	public Text LoggerText;

	List<string> logs = new List<string> { "", "", "", "", "", "", "", "" };

	VRAd vrAd;

	// Use this for initialization
	void Start () {
		Debug.Log ("OmniVirt SDK Version v" + OmniVirt.SDK.SDK_VERSION);

		ShowAdButton.onClick.AddListener (OnShowAdButtonClicked);

		vrAd = new VRAd (1622);
		vrAd.AdStatusChanged += OnAdStatusChanged;

		vrAd.LoadAd ();
	}

	IEnumerator ReloadAd() {
		yield return null;

		if (vrAd != null) {
			vrAd.Unload ();
			vrAd = null;
		}

		vrAd = new VRAd (1);
		vrAd.AdStatusChanged += OnAdStatusChanged;
		vrAd.LoadAd ();
	}

	void OnShowAdButtonClicked() {
		// Disable Show Ad button
		ShowAdButton.interactable = false;
		// Show Ad
		vrAd.Show (true);
	}

	void OnAdStatusChanged() {
		AppendLog("AdState Changed to " + vrAd.adState);
		if (vrAd.IsReady ()) {
			// Enable Show Ad button once ad is ready
			ShowAdButton.interactable = true;
		} else if (vrAd.IsCompleted () || vrAd.IsFailed()) {
			// Reload an ad for next session
			StartCoroutine (ReloadAd ());

			// Disable Show Ad button while loading
			ShowAdButton.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate Crate
		Crate.transform.Rotate (1, 1.5f, 0.5f);

		// Handle Back Button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			// If Ad is being shown, hide it
			if (vrAd.IsShowing ())
				return;
			// Else, quit the app
			Application.Quit ();
		}
	}

	// Logger

	void AppendLog(string message) {
		logs.RemoveAt (0);
		logs.Add (message);
		string str = "";
		for (int i = 0; i < logs.Count; i++)
			str = str + logs [i] + "\r\n";
		str = str.TrimEnd ();
		LoggerText.text = str;
	}

}
