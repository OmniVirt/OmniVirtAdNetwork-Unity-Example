using UnityEngine;
using System.Collections;
using OmniVirt;

public class BillboardAdSceneController : MonoBehaviour {

    public GameObject adPlaneHorizontal;
    public GameObject adPlaneVertical;

    BillboardAd billboardAdHorizontal;
    BillboardAd billboardAdVertical;

	// Use this for initialization
	void Start () {
        billboardAdHorizontal = new BillboardAd(1557);
        billboardAdHorizontal.LoadAd(adPlaneHorizontal);

        billboardAdVertical = new BillboardAd(1556);
        billboardAdVertical.LoadAd(adPlaneVertical);
    }

    // Update is called once per frame
    void Update () {
	
    }
}
