using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Input;

public class AirTapObjects : MonoBehaviour {

    GestureRecognizer gest;

	// Use this for initialization
	void Start () {
        gest = new GestureRecognizer();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if(Physics.Raycast(
            Camera.main.transform.position,
            Camera.main.transform.forward,
            out hit,
            Camera.main.farClipPlane,
            Physics.DefaultRaycastLayers))
        {
            var mgr = hit.collider.gameObject.GetComponent<ReligionManager>();
            if(mgr != null)
            {
                mgr.NextReligion();
            }
            else if(hit.collider.gameObject.name == "Sun")
            {

            }
        }
	}
}
