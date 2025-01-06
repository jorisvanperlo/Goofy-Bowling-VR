using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPowerUpHolder : MonoBehaviour
{
    // Public variables for setting points and speed in the Unity Editor
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;

    // Internal variable to track the current progress between the two points
    private float t = 0.0f;
    private bool movingToB = true;

    void Update()
    {
        // Calculate movement over time
        if (movingToB)
        {
            t += Time.deltaTime * speed;
            if (t >= 1.0f)
            {
                t = 1.0f;
                movingToB = false;
            }
        }
        else
        {
            t -= Time.deltaTime * speed;
            if (t <= 0.0f)
            {
                t = 0.0f;
                movingToB = true;
            }
        }

        // Interpolate between pointA and pointB using Mathf.Lerp
        transform.position = Vector3.Lerp(pointA, pointB, t);
    }
}
