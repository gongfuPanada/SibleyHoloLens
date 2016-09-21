using System;
using UnityEngine;

public class ReligionManager : MonoBehaviour
{
    int religionIndex, numReligions;

    public void NextReligion()
    {
        if(numReligions > 0)
        {
            religionIndex = (religionIndex + 1) % numReligions;
        }
    }

    // Use this for initialization
    void Start()
    {
        //user defined layers start with layer 8 and unity supports 32 layers
        for(int i = 8; i < 32; i++) 
        {
            if(LayerMask.LayerToName(i).Length > 0)
            {
                ++numReligions;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.cullingMask = (1 << (religionIndex + 8)) | 0x0f;
    }
}
