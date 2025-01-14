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
    public GameObject gameManager;

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

    public bool changeLayer;
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
                gameManager.GetComponent<GameManager>().SetupFreshLane();
            }
        }
    }

    public void RespawnBall()
    {
        gameManager.GetComponent<GameManager>().BallTrown();
        transform.position = ballSpawn;
        rb.velocity = Vector3.zero;
        rb.mass = normalWeight;
        transform.localScale = new Vector3(1, 1, 1);
        gameObject.layer = 0;
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
                if (changeLayer)
                {
                    gameObject.GetComponent<BallPowerUps>().ChangeLayer();
                    changeLayer = false;
                }
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
        if (other.gameObject.tag == "BallDetector")
        {
            //hihi nothing
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SmallBall")
        {
            gameManager.GetComponent<GameManager>().SmallBall();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "BigBall")
        {
            gameManager.GetComponent<GameManager>().BigBall();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "SmallPin")
        {
            gameManager.GetComponent<GameManager>().SmallPin();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "BigPin")
        {
            gameManager.GetComponent<GameManager>().BigPin();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "MovingPins")
        {
            gameManager.GetComponent<GameManager>().MovingPins();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "GutterWalls")
        {
            gameManager.GetComponent<GameManager>().GutterWalls();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Slide")
        {
            gameManager.GetComponent<GameManager>().Slide();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "DoublePoints")
        {
            gameManager.GetComponent<GameManager>().DoublePoints();
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathPlane")
        {
            gameManager.GetComponent<GameManager>().SetupFreshLane();
            startDeathTimer = false;
            deathTimer = startTime;
        }
    }
}
