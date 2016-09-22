﻿using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.VR.WSA.Persistence;
using UnityEngine.VR.WSA;

public class ResetPosition : MonoBehaviour
{

    WorldAnchorStore anchorStore;
    TapHandler tapper;
    List<GameObject> icons = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

        WorldAnchorStore.GetAsync(new WorldAnchorStore.GetAsyncDelegate(GotWorldAnchorStore));

        tapper = GetComponent<TapHandler>();
        if(tapper != null)
        {
            tapper.OnTap += Tapper_OnTap;
        }
    }

    void OnDestroy()
    {
        tapper.OnTap -= Tapper_OnTap;
    }

    private void Tapper_OnTap(object sender, EventArgs e)
    {
        if(anchorStore != null)
        {
            var objs = FindObjectsOfType<GameObject>();
            icons.Clear();
            foreach(var obj in objs)
            {
                var anchor = obj.GetComponent<WorldAnchor>();
                if(anchor != null)
                {
                    Destroy(anchor);
                }
                if(obj.name.StartsWith("Icon"))
                {
                    icons.Add(obj);
                }
            }
            icons.Sort(new Comparison<GameObject>(delegate (GameObject a, GameObject b)
            {
                return a.name.CompareTo(b.name);
            }));
            float d = (icons.Count - 1) / 2;
            for(int i = 0; i < icons.Count; ++i)
            {
                var obj = icons[i];
                obj.transform.position = new Vector3(1.5f * (i - d), 0, 2f) + Camera.main.transform.position;
                obj.transform.LookAt(Camera.main.transform);
            }
            anchorStore.Clear();
        }
    }

    void GotWorldAnchorStore(WorldAnchorStore store)
    {
        anchorStore = store;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
