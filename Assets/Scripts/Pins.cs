using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public Rigidbody rb;
    public bool beenHit;
    public bool pointGranted;
    public GameObject gameManager;
    public LayerMask groundlayer;

    public GameObject pinPuller;
    public Vector3 raySpawn;
    public float rayLength;

    public Vector3 largeScale;
    public Vector3 smallScale;

    public Vector3 startScale;
    public Vector3 endScale;

    public float duration;

    public float waitTime;
    public float rbWaitTime;

    public bool canRay;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(PowerUpsCheck());
        StartCoroutine(ActivateRB());

    }
    public IEnumerator PowerUpsCheck()
    {
        if (gameManager.GetComponent<GameManager>().pinGrow)
        {
            
            yield return new WaitForSeconds(waitTime);

            endScale = largeScale;

            StartCoroutine(ScalePinOverTime());
            gameManager.GetComponent<GameManager>().pinGrow = false;
        }
        if (gameManager.GetComponent<GameManager>().pinShrink)
        {
            
            
            yield return new WaitForSeconds(waitTime);

            endScale = smallScale; 

            StartCoroutine(ScalePinOverTime());
            gameManager.GetComponent<GameManager>().pinShrink = false;
        }
    }
    public IEnumerator ActivateRB()
    {
        yield return new WaitForSeconds(rbWaitTime);
        rb.isKinematic = false;
        canRay = true;
    }
    public IEnumerator ScalePinOverTime()
    {
        float elapsedTime = 0f;

        // Set the initial scale
        transform.localScale = startScale;

        while (elapsedTime < duration)
        {
            // Calculate the current scale based on elapsed time
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final scale is set
        transform.localScale = endScale;
    }

    void Update()
    {
        CheckIffCanAddPoints();
    }

    void CheckIffCanAddPoints()
    {
            raySpawn = transform.position;
            raySpawn.y += 0.05f;

            Ray ray = new Ray(raySpawn, -transform.up);


            if (!Physics.Raycast(ray, out RaycastHit hit, rayLength, groundlayer) & canRay)
            {
                if (!pointGranted && !pinPuller.GetComponent<PinPuller>().pulling)
                {
                    gameManager.GetComponent<GameManager>().AddPoint();
                    pointGranted = true;
                }
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathPlane" || collision.gameObject.tag == "PinPuller")
        {
            Destroy(gameObject);
        }
    }
}
