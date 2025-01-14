using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisapear : MonoBehaviour
{
   public void HandInvis()
    {
        gameObject.SetActive(false);
    }
    public void Handvis() 
    {
        gameObject.SetActive(true);
    }
  
}
