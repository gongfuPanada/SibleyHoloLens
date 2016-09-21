using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Input;
using UnityEngine.VR.WSA.Persistence;

public class AirTapObjects : MonoBehaviour
{
    public GameObject selector, cursor, mover;

    GestureRecognizer gest;
    GameObject target, held;
    WorldAnchorStore anchorStore;
    Vector3 holdStart, holdOffset;    

    void OnDestroy()
    {
        gest.TappedEvent -= Gest_TappedEvent;
        gest.HoldStartedEvent -= Gest_HoldStartedEvent;
        gest.HoldCanceledEvent -= Gest_HoldCanceledEvent;
    }
    void Start()
    {
        gest = new GestureRecognizer();
        gest.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.Hold);
        gest.TappedEvent += Gest_TappedEvent;
        gest.HoldStartedEvent += Gest_HoldStartedEvent;
        gest.HoldCanceledEvent += Gest_HoldCanceledEvent;
        gest.HoldCompletedEvent += Gest_HoldCompletedEvent;
        WorldAnchorStore.GetAsync(new WorldAnchorStore.GetAsyncDelegate(GotWorldAnchorStore));
    }

    Vector3 pokerPosition
    {
        get
        {
            return Camera.main.transform.position + Camera.main.transform.forward * 2;
        }
    }

    private void Gest_HoldStartedEvent(InteractionSourceKind source, Ray headRay)
    {
        if(target != null)
        {
            held = target;
            holdStart = held.transform.position;
            holdOffset = holdStart - pokerPosition;
        }
    }

    private void Gest_HoldCanceledEvent(InteractionSourceKind source, Ray headRay)
    {
        if(held != null)
        {
            held.transform.position = holdStart;
            held = null;
        }
    }

    private void Gest_HoldCompletedEvent(InteractionSourceKind source, Ray headRay)
    {
        if(held != null)
        {
            held = null;
        }
    }

    void GotWorldAnchorStore(WorldAnchorStore store)
    {
        anchorStore = store;
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
            }
            target = hit.collider.gameObject;
            while(target.transform.parent != null)
            {
                target = target.transform.parent.gameObject;
            }
            var obj = held == null ? selector : mover;
            obj.transform.position = hit.point;
            obj.transform.LookAt(hit.point + hit.normal);
        }
        else if(target != null)
        {
            gest.StopCapturingGestures();
            target = null;
        }

        if(held != null)
        {
            held.transform.position = pokerPosition + holdOffset;
            held.transform.LookAt(Camera.main.transform);
            var eu = held.transform.eulerAngles;
            eu.x = 0;
            held.transform.eulerAngles = eu;
        }

        cursor.SetActive(target == null && held == null);
        selector.SetActive(target != null && held == null);
        mover.SetActive(target != null && held != null);
    }
}
