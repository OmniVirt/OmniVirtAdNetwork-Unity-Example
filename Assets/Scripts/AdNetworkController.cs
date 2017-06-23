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
		ShowAdButton.onClick.AddListener (OnShowAdButtonClicked);

		vrAd = new VRAd (1);
		vrAd.AdStatusChanged += OnAdStatusChanged;

		vrAd.LoadAd ();
	}

	void OnShowAdButtonClicked() {
		// Disable Show Ad button
		ShowAdButton.interactable = false;
		// Show Ad
		vrAd.Show (Mode.Off);
	}

	void OnAdStatusChanged(object sender, AdStatusChangedEventArgs e) {
		AppendLog("AdState Changed to " + e.Status.ToString());
		if (vrAd.IsLoaded ()) {
			// Enable Show Ad button once ad is ready
			ShowAdButton.interactable = true;
		} else if (vrAd.IsCompleted ()) {
			// Reload an ad for next session
			vrAd.LoadAd ();
			// Disable Show Ad button while loading
			ShowAdButton.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		AdjustUIByOrientation ();

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
		
	void AdjustUIByOrientation() {
		RectTransform rectTransform;

		if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
			LogoImage.rectTransform.sizeDelta = new Vector2(1394 * 0.6f, 473 * 0.6f);
			LogoImage.rectTransform.anchorMin = new Vector2 (0, 1);
			LogoImage.rectTransform.anchorMax = new Vector2 (0, 1);
			LogoImage.rectTransform.anchoredPosition = new Vector2 (220, -100);

			rectTransform = ShowAdButton.gameObject.transform as RectTransform;
			rectTransform.sizeDelta = new Vector2(345, 90);
			rectTransform.anchorMin = new Vector2 (0.5f, 0);
			rectTransform.anchorMax = new Vector2 (0.5f, 0);
			rectTransform.anchoredPosition = new Vector2 (0, 100);

			LoggerText.fontSize = 14;
			LoggerText.rectTransform.anchoredPosition = new Vector2 (0, 200);

			Crate.transform.position = new Vector3 (90, 80, 0);
			Crate.transform.localScale = new Vector3 (120, 120, 120);
		} else if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown) {
			LogoImage.rectTransform.sizeDelta = new Vector2(1394.0f, 473.0f);
			LogoImage.rectTransform.anchorMin = new Vector2 (0.5f, 1);
			LogoImage.rectTransform.anchorMax = new Vector2 (0.5f, 1);
			LogoImage.rectTransform.anchoredPosition = new Vector2 (-8, -190);

			rectTransform = ShowAdButton.gameObject.transform as RectTransform;
			rectTransform.sizeDelta = new Vector2(460, 120);
			rectTransform.anchorMin = new Vector2 (0.5f, 0);
			rectTransform.anchorMax = new Vector2 (0.5f, 0);
			rectTransform.anchoredPosition = new Vector2 (0, 160);

			LoggerText.fontSize = 32;
			LoggerText.rectTransform.anchoredPosition = new Vector2 (0, 280);

			Crate.transform.position = new Vector3 (0, 0, 0);
			Crate.transform.localScale = new Vector3 (50, 50, 50);
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
