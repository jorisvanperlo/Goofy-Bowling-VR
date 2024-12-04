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

    public GameObject pinPuller;

    public float rayLength; // How far the ray should check
    public LayerMask groundLayer; // LayerMask to specify ground layers
    public bool isGrounded; // To store the result of the check
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
        if (beenHit == true && pointGranted == false)
        {
            // Define the starting point of the ray
            Vector3 origin = transform.position;

            // Define the direction of the ray
            Vector3 direction = Vector3.down;

            // Perform the raycast
            isGrounded = Physics.Raycast(origin, direction, rayLength, groundLayer);

            // Visualize the ray in the editor (for debugging)
            Debug.DrawRay(origin, direction * rayLength, isGrounded ? Color.green : Color.red);

           
            if (isGrounded == false)
            {
                print("hit");
                if (pinPuller.GetComponent<PinPuller>().pulling == false)
                {
                    print("point");
                    pointCounter.GetComponent<Points>().lv1Points += 1;
                    pointGranted = true;
                    
                }
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
