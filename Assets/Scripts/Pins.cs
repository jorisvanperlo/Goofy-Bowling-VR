using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public Rigidbody rb;
    public bool beenHit;
    public bool pointGranted;
    public GameObject pointCounter;
    public LayerMask groundlayer;

    public GameObject pinPuller;

    public float rayLength; // How far the ray should check
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        pointCounter = GameObject.Find("PointCounter");
    }

    // Update is called once per frame
    void Update()
    {
        if (beenHit == true && pointGranted == false && pinPuller.GetComponent<PinPuller>().pulling == false)
        {
          Ray ray = new Ray(transform.position, -transform.up);
         
           
            if (Physics.Raycast(ray, out RaycastHit hit, rayLength, groundlayer))
            {
                //You suck

            }
            else
            {
                print("point");
                pointCounter.GetComponent<Points>().lv1Points += 1;
                pointGranted = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Pin" )
        {
            
            rb.isKinematic = false;
            beenHit = true;
        }
        if (collision.gameObject.tag == "DeathPlane" || collision.gameObject.tag == "PinPuller")
        {
            Destroy(gameObject);
        }
    }
}
