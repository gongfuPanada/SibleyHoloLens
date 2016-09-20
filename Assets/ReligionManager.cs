using System;
using UnityEngine;

public class ReligionManager : MonoBehaviour
{
    private int religionIndex;
    private int numReligions;
    public GameObject[] icons;

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
        religionIndex = 0;
        numReligions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(icons != null)
        {
            numReligions = int.MaxValue;
            for(int i = 0; i < icons.Length; ++i)
            {
                var icon = icons[i];
                numReligions = Math.Min(numReligions, icon.transform.childCount);
                for(int j = 0; j < icon.transform.childCount; ++j)
                {
                    var child = icon.transform.GetChild(j);
                    child.gameObject.SetActive(j == religionIndex);
                }
            }
            if(numReligions == int.MaxValue)
            {
                numReligions = 0;
            }
        }
    }
}
