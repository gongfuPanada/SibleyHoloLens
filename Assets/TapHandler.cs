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
}
