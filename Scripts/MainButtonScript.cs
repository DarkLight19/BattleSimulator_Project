using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject UnitMaker_GO;
    public int pressedCounter = 1;
    public void pressed()
    {
        if (pressedCounter == 1)
        {
            --pressedCounter;
            UnitMaker_GO.GetComponent<UnitScript>().StartSimulation();
        }
        else
            ++pressedCounter;
    }

    public void resetCounter()
    {
        pressedCounter = 0;
    }
}
