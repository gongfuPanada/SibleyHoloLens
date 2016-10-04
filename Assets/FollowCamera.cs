using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    float uiTurn, maxY, maxX;

    // Use this for initialization
    void Start()
    {
        uiTurn = 0;
        maxY = 10;
        maxX = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position;
        var followEuler = Camera.main.transform.eulerAngles;
        float turn = followEuler.y,
            deltaTurnA = turn - uiTurn,
            deltaTurnB = deltaTurnA + 360,
            deltaTurnC = deltaTurnA - 360,
            deltaTurn;
        if(Math.Abs(deltaTurnA) < Math.Abs(deltaTurnB))
        {
            if(Math.Abs(deltaTurnA) < Math.Abs(deltaTurnC))
            {
                deltaTurn = deltaTurnA;
            }
            else
            {
                deltaTurn = deltaTurnC;
            }
        }
        else if(Math.Abs(deltaTurnB) < Math.Abs(deltaTurnC))
        {
            deltaTurn = deltaTurnB;
        }
        else
        {
            deltaTurn = deltaTurnC;
        }

        if(Math.Abs(deltaTurn) > maxY)
        {
            uiTurn += deltaTurn * 0.02f;
        }
        followEuler.x = maxX;
        followEuler.y = uiTurn;
        followEuler.z = 0;
        transform.eulerAngles = followEuler;
    }
}
