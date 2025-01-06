using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    public GameObject level1Select;
    public GameObject level2Select;
    public GameObject cancelLevelSelect;
    public GameObject buttonStartGame;
    public GameObject buttonSettings;
    public GameObject buttonCredits;
    public GameObject buttonQuit;
    public GameObject buttonQuitNo;
    public GameObject buttonQuitYes;
    public GameObject quitYesNoText;

    public void ButtonStartGame()
    {
        level1Select.SetActive(true);
        level2Select.SetActive(true);
        cancelLevelSelect.SetActive(true);
        buttonStartGame.SetActive(false);
        buttonSettings.SetActive(false);
        buttonCredits.SetActive(false);
        buttonQuit.SetActive(false);
        
    }
    public void ButtonSettings()
    {

    }
    public void ButtonCredits()
    {

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
    public void LevelSelectCancel()
    {
        level1Select.SetActive(false);
        level2Select.SetActive(false);
        cancelLevelSelect.SetActive(false);
        buttonStartGame.SetActive(true);
        buttonSettings.SetActive(true);
        buttonCredits.SetActive(true);
        buttonQuit.SetActive(true);
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
}
