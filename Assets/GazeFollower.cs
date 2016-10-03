using UnityEngine;

public class GazeFollower : MonoBehaviour {
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
}
