using System.Linq;
using UnityEngine;
using UnityEngine.VR.WSA;
using UnityEngine.VR.WSA.Input;
using UnityEngine.VR.WSA.Persistence;

public class AirTapObjects : MonoBehaviour
{
    GestureRecognizer gest;
    GameObject target, held;
    WorldAnchorStore anchorStore;
    Vector3 holdStart, holdOffset;
    GazeFollower gaze;

    void OnDestroy()
    {
        gest.TappedEvent -= Gest_TappedEvent;
        gest.HoldStartedEvent -= Gest_HoldStartedEvent;
        gest.HoldCanceledEvent -= Gest_HoldCanceledEvent;
        gest.HoldCompletedEvent -= Gest_HoldCompletedEvent;
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
        gaze = GetComponentInChildren<GazeFollower>();
    }

    private void Gest_HoldStartedEvent(InteractionSourceKind source, Ray headRay)
    {
        if(target != null && target.name.StartsWith("Icon"))
        {
            held = target;
            var anchor = held.GetComponent<WorldAnchor>();
            if(anchor != null)
            {
                var ids = anchorStore.GetAllIds();
                if(anchorStore != null && ids.Contains(held.name))
                {
                    anchorStore.Delete(held.name);
                }
                DestroyImmediate(anchor);
            }
            holdStart = held.transform.position;
            holdOffset = holdStart - PointerPosition;
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
            var anchor = held.AddComponent<WorldAnchor>();
            if(anchorStore != null && anchor != null)
            {
                anchorStore.Save(held.name, anchor);
            }
            held = null;
        }
    }

    void GotWorldAnchorStore(WorldAnchorStore store)
    {
        anchorStore = store;
        var objs = FindObjectsOfType<GameObject>();
        foreach(var obj in objs)
        {
            if(obj.name.StartsWith("Icon"))
            {
                anchorStore.Load(obj.name, obj);
            }
        }
    }

    private void Gest_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if(target != null)
        {
            var tapper = target.GetComponent<TapHandler>();
            if(tapper != null)
            {
                tapper.Tap(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit selectedObject;

        bool objectHit = Physics.Raycast(
            Camera.main.transform.position,
            Camera.main.transform.forward,
            out selectedObject,
            30.0f,
            Physics.AllLayers);

        if(objectHit)
        {
            if(target == null)
            {
                gest.StartCapturingGestures();
            }
            target = selectedObject.collider.gameObject;
            while(target.transform.parent != null)
            {
                var tapper = target.GetComponent<TapHandler>();
                if(tapper != null)
                {
                    break;
                }
                target = target.transform.parent.gameObject;
            }
            MovePointer(selectedObject.point, selectedObject.normal);
        }
        else
        {
            if(!objectHit && target != null && held == null)
            {
                gest.StopCapturingGestures();
                target = null;
            }
            MovePointer(PointerPosition, -Camera.main.transform.forward);
        }

        if(held != null)
        {
            held.transform.position = PointerPosition + holdOffset;
            held.transform.LookAt(Camera.main.transform);
            var eu = held.transform.eulerAngles;
            eu.x = 0;
            held.transform.eulerAngles = eu;
        }

        if(!objectHit && held == null)
        {
            gaze.SelectedIndex = 0;
        }
        else if(objectHit && held == null)
        {
            gaze.SelectedIndex = 1;
        }
        else if(held != null)
        {
            gaze.SelectedIndex = 2;
        }
    }

    void MovePointer(Vector3 point, Vector3 normal)
    {
        gaze.transform.position = point;
        gaze.transform.LookAt(point + normal);
        HolographicSettings.SetFocusPointForFrame(point, -Camera.main.transform.forward);
    }

    Vector3 PointerPosition
    {
        get
        {
            var vector = Camera.main.transform.forward;
            vector.y = 0;
            var len1 = vector.magnitude;
            vector.Normalize();
            var scale = 1.0f / len1;
            return Camera.main.transform.position + scale * Camera.main.transform.forward;
        }
    }
}
