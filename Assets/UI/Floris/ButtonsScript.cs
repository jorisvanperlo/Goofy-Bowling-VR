using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public GameObject buttonStartGame;
    public GameObject buttonSettings;
    public GameObject buttonCredits;
    public GameObject buttonQuit;
    public GameObject buttonQuitNo;
    public GameObject buttonQuitYes;
    public GameObject quitYesNoText;
    public GameObject creditText;
    public GameObject creditsReturn;
    public string level1;

    public void ButtonStartGame()
    {
        SceneManager.LoadScene(level1);
    }
    public void ButtonSettings()
    {

    }
    public void ButtonCredits()
    {
        creditText.SetActive(true);
        creditsReturn.SetActive(true);

        buttonStartGame.SetActive(false);
        buttonSettings.SetActive(false);
        buttonCredits.SetActive(false);
        buttonQuit.SetActive(false);
    }
    public void ButtonQuit()
    {
        buttonQuitNo.SetActive(true);
        buttonQuitYes.SetActive(true);
        quitYesNoText.SetActive(true);

        buttonStartGame.SetActive(false);
        buttonSettings.SetActive(false);
        buttonCredits.SetActive(false);
        buttonQuit.SetActive(false);
    }
    public void QuitNo()
    {
        buttonQuitNo.SetActive(false);
        buttonQuitYes.SetActive(false);
        quitYesNoText.SetActive(false);

        buttonStartGame.SetActive(true);
        buttonSettings.SetActive(true);
        buttonCredits.SetActive(true);
        buttonQuit.SetActive(true);
    }
    public void QuitYes()
    {
        Application.Quit();
    }
    public void CreditsReturn()
    {
        creditText.SetActive(false);
        creditsReturn.SetActive(false);

        buttonStartGame.SetActive(true);
        buttonSettings.SetActive(true);
        buttonCredits.SetActive(true);
        buttonQuit.SetActive(true);
    }
}
