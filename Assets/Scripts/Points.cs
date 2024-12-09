using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points;
    public int pointReq;

    public float ballsThrown;
    public float attemptAmount;
    void Start()
    {

    }

    void Update()
    {
        if (points >= pointReq)
        {
            //you won next level
        }
        if (ballsThrown >= attemptAmount)
        {
            points = 0;
            ballsThrown = 0;
            //Reset game with UI
        }
    }
}
