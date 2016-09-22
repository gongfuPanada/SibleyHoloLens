using UnityEngine;
using System;

public class TapHandler : MonoBehaviour
{

    public event EventHandler OnTap;

    public void Tap(object source)
    {
        if(OnTap != null)
        {
            OnTap(source, EventArgs.Empty);
        }
    }

    // Use this for initialization
    void Start()
    {
        var tv = transform.localPosition;
        tv.z = 2;
        transform.localPosition = tv;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
