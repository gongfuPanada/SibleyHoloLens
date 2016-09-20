using UnityEngine;

public class ReligionManager : MonoBehaviour
{
    private int lastReligionIndex;
    public int religionIndex;
    public GameObject[] icons;

    // Use this for initialization
    void Start()
    {
        lastReligionIndex = 0;
        religionIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastReligionIndex != religionIndex)
        {
            lastReligionIndex = religionIndex;
            if(icons != null)
            {
                foreach(var icon in icons)
                {
                    for(int i = 0; i < icon.transform.childCount; ++i)
                    {
                        var child = icon.transform.GetChild(i);
                        child.gameObject.SetActive(i == religionIndex);
                    }
                }
            }
        }
    }
}
