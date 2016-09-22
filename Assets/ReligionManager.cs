using System;
using UnityEngine;

public class ReligionManager : MonoBehaviour
{
    int religionIndex;
    public int numberOfReligions;
    TapHandler tapper;

    // Use this for initialization
    void Start()
    {
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
        if(numberOfReligions > 0)
        {
            religionIndex = (religionIndex + 1) % numberOfReligions;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.cullingMask = (1 << (religionIndex + 8)) | 0x0f;
    }
}
