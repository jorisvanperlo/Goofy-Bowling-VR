using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //GameObjects
    public GameObject pinsPlacer;
    public GameObject pinPuller;
    public GameObject ball;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int highscore;


    //GameManaging
    public int points;
    public int pointReq;

    public float ballsThrown;
    public float attemptAmount;

    public string nextScene;

    public bool doubPointSameRound;
    public bool doubPointNextRound;

    public bool ActivateDoublePoints;

    //PowerUps
    public bool pinGrow;
    public bool pinShrink;

    public bool ballGrow;
    public bool ballShrink;

    public bool doublePoints;

    public bool movingPins;

    public bool gutterWalls;
    public GameObject gutterWallsOb;

    public bool slide;
    public GameObject slideOb;
    public Quaternion slideRot;
    public Vector3 slideSpawn;

    //PowerUpsObjects
    public int randomPowerUp;

    public GameObject SmallBallDebuff;
    public GameObject SmallPinDebuff;
    public GameObject MovingPinsDebuff;
    public GameObject BallBigPowerup;
    public GameObject PinBigPowerup;
    public GameObject GutterWallsPowerup;
    public GameObject SlidePowerup;
    public GameObject DoublePointsPowerup;
    void Start()
    {
        SetupFreshLane();
    }
    public void AddPoint()
    {
        if (doublePoints)
        {
            points += 2;
            scoreText.text = points.ToString();
        }
        else
        {
            points ++;
            scoreText.text = points.ToString();
        }
    }

    public void BallTrown()
    {
        ballsThrown++;
        if(ballsThrown >= attemptAmount)
        {
            GameReset();
        }
    }
    public void GameReset()
    {
        if (points > highscore)
        {
            highscore = points;
            highscoreText.text = highscore.ToString();
        }
        
        ballsThrown = 0;
        points = 0;

    }

    public void SetupFreshLane()
    {
        ClearLane();
        ClearPowerUp();
        PowerUpsManager();
        PinDeployment();
        PowerUpsSpawn();
    }
    public void ClearLane()
    {
        pinPuller.GetComponent<PinPuller>().PullPinDelay();
        ball.GetComponent<BowlingBall>().RespawnBall();
    }
    public void ClearPowerUp()
    {
        if (doubPointSameRound)
        {
            doubPointSameRound = false;
            doubPointNextRound = true;
            doublePoints = true;
        }
        if (doubPointNextRound)
        {
            doublePoints = false;
            doubPointNextRound = false;
        }
     slideOb.SetActive(false);
     gutterWallsOb.GetComponent<Gutterwalls>().MoveBackToA();

     SmallBallDebuff.SetActive(false);
     SmallPinDebuff.SetActive(false);
     MovingPinsDebuff.SetActive(false);
     BallBigPowerup.SetActive(false);
     PinBigPowerup.SetActive(false);
     GutterWallsPowerup.SetActive(false);
     SlidePowerup.SetActive(false);
     DoublePointsPowerup.SetActive(false);
     }

    public void PowerUpsManager()
    {
        ball.GetComponent<BallPowerUps>().gameObject.layer = 0;

        if (ballGrow)
        {
            ball.GetComponent<BowlingBall>().makeBallBig = true;
            ballGrow = false;
        }
        if (ballShrink)
        {
            ball.GetComponent<BowlingBall>().makeBallBig = true;
            ballShrink = false;
        }
        if (movingPins)
        {
            ball.GetComponent<BallPowerUps>().ChangeLayer();
            movingPins = false;
        }
        if (gutterWalls)
        {
            gutterWallsOb.SetActive(false);
            gutterWalls = false;
        }
        if (slide)
        {
            slideOb.SetActive(true);
            slideOb.GetComponent<Transform>().position = slideSpawn;
            slideOb.GetComponent<Transform>().rotation = slideRot;
            slide = false;
        }
        if (movingPins)
        {
            ball.GetComponent<BallPowerUps>().ChangeLayer();
        }
        if (ActivateDoublePoints)
        {
            doublePoints = true;
        }

    }

    public void PinDeployment()
    {
        pinsPlacer.GetComponent<MovingPinsPlacer>().DeployPinsDelay();
    }

    //------PowerUps-----
    public void SmallBall()
    {
        ballShrink = true;
    }
    public void BigBall()
    {
        ballGrow = true;
    }
    public void SmallPin()
    {
        pinShrink = true;
    }
    public void BigPin()
    {
        pinGrow = true;
    }
    public void MovingPins()
    {
        movingPins = true;
    }
    public void GutterWalls()
    {
        gutterWalls = true;
    }
    public void Slide()
    {
        slide = true;
    }
    public void DoublePoints()
    {
        ActivateDoublePoints = true;
    }

    public void PowerUpsSpawn()
    {
        randomPowerUp = Random.Range(1, 9);

        if (randomPowerUp == 1)
        {
            SmallBallDebuff.SetActive(true);
        }
        if (randomPowerUp == 2)
        {
            SmallPinDebuff.SetActive(true);
        }
        if (randomPowerUp == 3)
        {
            MovingPinsDebuff.SetActive(true);
        }
        if (randomPowerUp == 4)
        {
            BallBigPowerup.SetActive(true);
        }
        if (randomPowerUp == 5)
        {
            GutterWallsPowerup.SetActive(true);
        }
        if (randomPowerUp == 6)
        {
            SlidePowerup.SetActive(true);
        }
        if (randomPowerUp == 7)
        {
            DoublePointsPowerup.SetActive(true);
        }
        if (randomPowerUp == 8)
        {
            PinBigPowerup.SetActive(true);
        }
    }
}
