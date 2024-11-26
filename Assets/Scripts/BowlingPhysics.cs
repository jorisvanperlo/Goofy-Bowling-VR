using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPhysics : MonoBehaviour
{
    public GameObject BowlingBall;
    public Rigidbody BowlBody;
    public float ballResistance;
    public float airResis;
    public float groundResis;
    

    public float rayLength; // How far the ray should check
    public LayerMask groundLayer; // LayerMask to specify ground layers
    public bool isGrounded; // To store the result of the check
   
    void Start()
    {
            
    }

 
    void Update()
    {
        // Define the starting point of the ray
        Vector3 origin = transform.position;

        // Define the direction of the ray
        Vector3 direction = Vector3.down;

        // Perform the raycast
        isGrounded = Physics.Raycast(origin, direction, rayLength, groundLayer);

        // Visualize the ray in the editor (for debugging)
        Debug.DrawRay(origin, direction * rayLength, isGrounded ? Color.green : Color.red);

        // Optionally, output to console for testing
        if (isGrounded)
        {
            BowlBody.drag = groundResis;
        }
        else
        {
            BowlBody.drag = airResis;
        }
    }
}
