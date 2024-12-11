using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //gameobjects
    public GameObject pinsPlacer;
    public GameObject pinPuller;
    public GameObject ball;

    //managing
    public int points;
    public int pointReq;

    public float ballsThrown;
    public float attemptAmount;

    public string nextScene;

    // powerups
    public bool pinGrow;
    public bool pinShrink;

    public bool ballGrow;
    public bool ballShrink;

    public bool dubblePoints;
    void Start()
    {
        SetupFreshLane();
    }
    public void AddPoint()
    {
        if (dubblePoints)
        {
            points += 2;
        }
        else
        {
            points ++;
        }
        if(points >= pointReq)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void BallTrown()
    {
        ballsThrown++;
        if(ballsThrown <= attemptAmount)
        {
            GameReset();
        }
    }
    public void GameReset()
    {
        ballsThrown = 0;
        points = 0;
    }

    public void SetupFreshLane()
    {
        ClearLane();
        PowerUpsManager();
        PinDeployment();
    }
    public void ClearLane()
    {
        pinPuller.GetComponent<PinPuller>().PullPinDelay();
        ball.GetComponent<BowlingBall>().RespawnBall();
    }

    public void PowerUpsManager()
    {
        if (ballGrow)
        {
            ball.GetComponent<BowlingBall>().makeBallBig = true;
        }
        if (ballShrink)
        {
            ball.GetComponent<BowlingBall>().makeBallBig = true;
        }
    }

    public void PinDeployment()
    {
        pinsPlacer.GetComponent<MovingPinsPlacer>().DeployPinsDelay();
    }
}
