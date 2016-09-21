using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Input;

public class AirTapObjects : MonoBehaviour {

    GestureRecognizer gest;
    GameObject currentGameObject;

	// Use this for initialization
	void Start () {
        gest = new GestureRecognizer();
        gest.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.ManipulationTranslate);
        gest.TappedEvent += Gest_TappedEvent;
        gest.ManipulationStartedEvent += Gest_ManipulationStartedEvent;
        gest.ManipulationUpdatedEvent += Gest_ManipulationUpdatedEvent;
        gest.ManipulationCanceledEvent += Gest_ManipulationCanceledEvent;
        gest.ManipulationCompletedEvent += Gest_ManipulationCompletedEvent;
    }

    private void Gest_ManipulationStartedEvent(InteractionSourceKind source, Vector3 cumulativeDelta, Ray headRay)
    {
    }

    private void Gest_ManipulationUpdatedEvent(InteractionSourceKind source, Vector3 cumulativeDelta, Ray headRay)
    {
    }

    private void Gest_ManipulationCanceledEvent(InteractionSourceKind source, Vector3 cumulativeDelta, Ray headRay)
    {
    }

    private void Gest_ManipulationCompletedEvent(InteractionSourceKind source, Vector3 cumulativeDelta, Ray headRay)
    {
    }

    void OnDestroy()
    {
        gest.TappedEvent -= Gest_TappedEvent;
        gest.ManipulationStartedEvent -= Gest_ManipulationStartedEvent;
        gest.ManipulationUpdatedEvent -= Gest_ManipulationUpdatedEvent;
        gest.ManipulationCanceledEvent -= Gest_ManipulationCanceledEvent;
        gest.ManipulationCompletedEvent -= Gest_ManipulationCompletedEvent;
    }

    private void Gest_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if(currentGameObject != null)
        {
            var mgr = currentGameObject.GetComponent<ReligionManager>();
            if(mgr != null)
            {
                mgr.NextReligion();
            }
        }
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
            if(currentGameObject == null)
            {
                gest.StartCapturingGestures();
            }
            currentGameObject = hit.collider.gameObject;
        }
        else
        {
            gest.StopCapturingGestures();
            currentGameObject = null;
        }
	}
}
