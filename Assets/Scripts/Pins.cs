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

    public float largeScale;
    public float smallScale;
    public float targetScale;
    public float scaleTime;

    public float waitTime;
    public float rbWaitTime;


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
            targetScale = largeScale;
            yield return new WaitForSeconds(waitTime);
            StartCoroutine(ScalePinOverTime());
        }
        if (gameManager.GetComponent<GameManager>().pinShrink)
        {
            targetScale = smallScale;
            yield return new WaitForSeconds(waitTime);
            StartCoroutine(ScalePinOverTime());
        }
    }
    public IEnumerator ActivateRB()
    {
        yield return new WaitForSeconds(rbWaitTime);
        rb.isKinematic = false;
        print("hihi");
    }
    public IEnumerator ScalePinOverTime()
    {
        gameManager.GetComponent<GameManager>().pinGrow = false;
        gameManager.GetComponent<GameManager>().pinShrink = false;

        print("Scale pin");

        float addToScale = 1f;
        if (transform.localScale.x > targetScale)
        {
            addToScale --;
        }
        bool canScale = true;
        Vector3 targetScaleVector = new Vector3(targetScale, targetScale, targetScale);
        while (canScale)
        {
            transform.localScale += (new Vector3(1, 1, 1) * addToScale) * Time.deltaTime * scaleTime;
            if (Vector3.Distance(transform.localScale, targetScaleVector) < 0.1f)
            {
                transform.localScale = targetScaleVector;
                canScale = false;
            }
            yield return null;
        }
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


            if (!Physics.Raycast(ray, out RaycastHit hit, rayLength, groundlayer))
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
