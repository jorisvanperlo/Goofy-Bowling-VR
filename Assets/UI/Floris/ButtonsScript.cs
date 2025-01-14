using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject creditTextImage;
    public GameObject creditsReturn;
    public GameObject title;
    public GameObject quitYesNoTextImage;
    public string level1;
    public string mainMenu;

    public void ButtonStartGame()
    {
        SceneManager.LoadScene(level1);
        print("StartGame");
    }
    public void ButtonSettings()
    {

    }
    public void ButtonCredits()
    {
        creditText.SetActive(true);
        creditsReturn.SetActive(true);
        creditTextImage.SetActive(true);

        buttonStartGame.SetActive(false);
        buttonSettings.SetActive(false);
        buttonCredits.SetActive(false);
        buttonQuit.SetActive(false);
        title.SetActive(false); 
        print("Credits");
    }
    public void ButtonQuit()
    {
        buttonQuitNo.SetActive(true);
        buttonQuitYes.SetActive(true);
        quitYesNoText.SetActive(true);
        quitYesNoTextImage.SetActive(true);

        buttonStartGame.SetActive(false);
        buttonSettings.SetActive(false);
        buttonCredits.SetActive(false);
        buttonQuit.SetActive(false);
        title.SetActive(false);
        print("Quit");
    }
    public void QuitNo()
    {
        buttonQuitNo.SetActive(false);
        buttonQuitYes.SetActive(false);
        quitYesNoText.SetActive(false);
        quitYesNoTextImage.SetActive(false);   

        buttonStartGame.SetActive(true);
        buttonSettings.SetActive(true);
        buttonCredits.SetActive(true);
        buttonQuit.SetActive(true);
        title.SetActive(true);
    }
    public void QuitYes()
    {
        Application.Quit();
    }
    public void CreditsReturn()
    {
        creditText.SetActive(false);
        creditsReturn.SetActive(false);
        creditTextImage.SetActive(false);

        buttonStartGame.SetActive(true);
        buttonSettings.SetActive(true);
        buttonCredits.SetActive(true);
        buttonQuit.SetActive(true);
        title.SetActive(true);
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
