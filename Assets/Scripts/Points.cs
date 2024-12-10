using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public int points;
    public int pointReq;

    public float ballsThrown;
    public float attemptAmount;

    public string nextScene;

    public bool dubblePoints;
    void Start()
    {

    }

    void Update()
    {
        if (points >= pointReq)
        {
            //you won next level
            SceneManager.LoadScene(nextScene);
        }
        if (ballsThrown >= attemptAmount)
        {
            points = 0;
            ballsThrown = 0;
            //Reset game with UI
        }
    }
    public void AddPoint()
    {
        if (dubblePoints == true)
        {
            points += 2;
        }
        else
        {
            points += 1;
        }
        
    }
}
