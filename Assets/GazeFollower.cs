using UnityEngine;
using System.Collections;

public class GazeFollower : MonoBehaviour {
    public Color cursorColor;
    public int SelectedIndex
    {
        set
        {
            for(int i = 0; i < transform.childCount; ++i)
            {
                var child = transform.GetChild(i).gameObject;
                child.SetActive(i == value);
            }
        }
    }
	// Use this for initialization
	void Start ()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            var child = transform.GetChild(i).gameObject;
            var sprite = child.GetComponent<SpriteRenderer>();
            if(sprite != null)
            {
                sprite.color = cursorColor;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
