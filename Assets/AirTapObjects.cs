using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Input;
using UnityEngine.VR.WSA.Persistence;

public class AirTapObjects : MonoBehaviour
{
    public GameObject selector, cursor;

    GestureRecognizer gest;
    GameObject target;
    WorldAnchorStore anchorStore;

    // Use this for initialization
    void Start()
    {
        gest = new GestureRecognizer();
        gest.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.ManipulationTranslate);
        gest.TappedEvent += Gest_TappedEvent;
        gest.ManipulationStartedEvent += Gest_ManipulationStartedEvent;
        gest.ManipulationUpdatedEvent += Gest_ManipulationUpdatedEvent;
        gest.ManipulationCanceledEvent += Gest_ManipulationCanceledEvent;
        gest.ManipulationCompletedEvent += Gest_ManipulationCompletedEvent;
        WorldAnchorStore.GetAsync(new WorldAnchorStore.GetAsyncDelegate(GotWorldAnchorStore));
    }

    void GotWorldAnchorStore(WorldAnchorStore store)
    {
        anchorStore = store;
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
        if(target != null)
        {
            var mgr = target.GetComponent<ReligionManager>();
            if(mgr != null)
            {
                mgr.NextReligion();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(
            Camera.main.transform.position,
            Camera.main.transform.forward,
            out hit,
            Camera.main.farClipPlane,
            Physics.AllLayers))
        {
            if(target == null)
            {
                gest.StartCapturingGestures();
                cursor.SetActive(false);
                selector.SetActive(true);
            }
            target = hit.collider.gameObject;
            selector.transform.position = hit.point;
            selector.transform.LookAt(hit.point + hit.normal);
        }
        else if(target != null)
        {
            gest.StopCapturingGestures();
            cursor.SetActive(true);
            selector.SetActive(false);
            target = null;
        }
    }
}
