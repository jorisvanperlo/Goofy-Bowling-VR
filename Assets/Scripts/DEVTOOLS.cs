using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEVTOOLS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject devPowerUps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            devPowerUps.SetActive(true);
        }
    }
}
