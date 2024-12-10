using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Unity.VisualScripting;

public class BowlingBall : XRGrabInteractable
{
    public Vector3 ballSpawn;
    public bool startDeathTimer;
    public float deathTimer;
    public float startTime;
    public int ballsThrown;

    public GameObject pinPuller;
    public GameObject pinPlacer;

    public bool isBeingHeld;
    public UnityEvent OnLetGo;
    public GameObject pointCounter;

    public Rigidbody rb;
    public float gutterSpeed;

    //----PowerUps---//
    public GameObject ball;

    public float normalWeight;

    public bool makeBallBig;
    public float bigWeight;

    public bool makeBallSmall;
    public float smallWeight;

    public bool dubblePoints;

    void Start()
    {
        transform.position = ballSpawn;
        deathTimer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startDeathTimer == true)
        {
            deathTimer -= 1.0f * Time.deltaTime;
            if (deathTimer < 0.0f)
            {
                startDeathTimer = false;
                deathTimer = startTime;
                RespawnBall();
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathPlane")
        {
            pinPuller.GetComponent<PinPuller>().PullPinDelay();
            pinPlacer.GetComponent<MovingPinsPlacer>().DeployPinsDelay();
            RespawnBall();
            startDeathTimer = false;
            deathTimer = startTime;

            rb.mass = normalWeight;
            transform.localScale = new Vector3(1, 1, 1);
            pointCounter.GetComponent<Points>().dubblePoints = false;
        }
    }

    private void RespawnBall()
    {
        pointCounter.GetComponent<Points>().ballsThrown += 1;
        transform.position = ballSpawn;
    }

    

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Mark the object as being held
        isBeingHeld = true;
        Debug.Log($"{gameObject.name} has been grabbed.");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Check if no interactors are holding the object
        if (interactorsSelecting.Count == 0)
        {
            // Trigger the OnLetGo event
            Debug.Log($"{gameObject.name} has been released.");
            OnLetGo?.Invoke();
            if (isBeingHeld == true)
            {
                startDeathTimer = true;
                if (makeBallBig == true)
                {
                    ball.GetComponent<BallPowerUps>().BallGrow();
                    rb.mass = bigWeight;
                    makeBallBig = false;
                }
                if (makeBallSmall == true)
                {
                    ball.GetComponent<BallPowerUps>().BallShrink();
                    rb.mass = smallWeight;
                    makeBallSmall = false;
                }
                if (dubblePoints == true)
                {
                    pointCounter.GetComponent <Points>().dubblePoints = true;
                }
            }
            isBeingHeld = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GutterAccel")
        {
            rb.AddForce(-Vector3.forward * gutterSpeed);
        }
    }
}
