using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    GameObject level1Select;
    GameObject level2Select;
    GameObject cancelLevelSelect;
    GameObject buttonStartGame;
    GameObject buttonSettings;
    GameObject buttonCredits;
    GameObject buttonQuit;
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
        
    }
}
