using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPuller : MonoBehaviour
{
    public Vector3 top;
    public Vector3 bottom;
    public Vector3 bottomBack;
    public float waitTime;

    public float speed; // Speed of movement
    
    public Vector3[] points; // Array to store the sequence of points
    private int currentPointIndex = 0; // Index of the current target point

    public bool pulling;

    public GameObject pinPlacer;

    public void Start()
    {
        
       
    }

    public void PullPinDelay()
    {
        
        Invoke(nameof(PullPins), waitTime);
        
    }
    public void PullPins()
    {
        pulling = true;
        points = new Vector3[] { top, bottom, bottomBack, bottom, top };
        transform.position = top; // Start at point A
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenPoints();
    }
    private void MoveBetweenPoints()
    {
        if (points.Length > 0)
        {
            // Move towards the current target point
            transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex], speed * Time.deltaTime);

            // Check if the object has reached the current target point
            if (transform.position == points[currentPointIndex])
            {
                // Move to the next point in the sequence
                currentPointIndex++;
                if (currentPointIndex >= points.Length)
                {
                    points = new Vector3[] {top};
                    currentPointIndex = 0; // Restart the sequence
                   
                }
            }
        }
    }
}
