using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPinHolder : MonoBehaviour
{
    public GameObject pinPlacer;
   
    // Start is called before the first frame update
    void Start()
    {
        pinPlacer = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pinPlacer.GetComponent<MovingPinsPlacer>().reachBottom != true)
        {
            transform.localPosition = pinPlacer.transform.localPosition;
        }
    }
}
