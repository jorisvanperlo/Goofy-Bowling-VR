using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutterwalls : MonoBehaviour
{
    // Public variables for setting points and speed in the Unity Editor
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;

    // Internal variables to track movement
    private bool movingToB = true;
    private bool movingToA = false;
    private float t = 0.0f;

    void Start()
    {
        // Start moving to pointB at the beginning
        movingToB = true;
        movingToA = false;
        t = 0.0f;
    }

    void Update()
    {
        if (movingToB)
        {
            t += Time.deltaTime * speed;
            if (t >= 1.0f)
            {
                t = 1.0f;
                movingToB = false;
            }
        }
        else if (movingToA)
        {
            t -= Time.deltaTime * speed;
            if (t <= 0.0f)
            {
                t = 0.0f;
                movingToA = false;
                gameObject.SetActive(false);
            }
        }

        // Interpolate between pointA and pointB using Mathf.Lerp
        transform.position = Vector3.Lerp(pointA, pointB, t);
    }

    // Public method to start moving back to pointA
    public void MoveBackToA()
    {
        movingToA = true;
        movingToB = false;
    }
}
