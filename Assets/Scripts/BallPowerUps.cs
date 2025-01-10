using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class BallPowerUps : MonoBehaviour
{
    public GameObject Ball;
    public Rigidbody rb;
    public Vector3 normalSize;
    public Vector3 largeSize;
    public Vector3 smallSize;
    public float lerpDuration; 

    private float elapsedTime;
    public bool shouldGrow;
    public bool shouldShrink;
    public float growTime;

    public bool noHitLay;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (shouldGrow == true)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / lerpDuration;

            transform.localScale = Vector3.Lerp(normalSize, largeSize, t);

            if (t >= 1f)
            {
                shouldGrow = false; 
                elapsedTime = 0f; 
            }
        }
        if (shouldShrink == true)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / lerpDuration;

            transform.localScale = Vector3.Lerp(normalSize, smallSize, t);

            if (t >= 1f)
            {
                shouldShrink = false;
                elapsedTime = 0f;
            }
        }
    }

    public void BallGrow()
    {
        shouldGrow = true; // Start the lerp
        elapsedTime = 0f; // Reset elapsed time
    }
    public void BallShrink()
    {
        shouldShrink = true; // Start the lerp
        elapsedTime = 0f; // Reset elapsed time
    }
    public void ChangeLayer()
    {
        if (noHitLay)
        {
            gameObject.layer = 7;
            noHitLay = false;
        }
        else
        {
            gameObject.layer = 0;
            noHitLay = true;
        }
    }
}
