using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentralMenuButtonsScript : MonoBehaviour
{
    public UnityEngine.Color baseColor;
    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;

    private int highlighted = 0;

    public void Start()
    {
        this.transform.GetComponent<Image>().color = baseColor;
    }

    public void Highlighted()
    {
        highlighted = 1;
        this.transform.GetComponent<Image>().color = highlightedColor;
    }

    public void Deselect()
    {
        if (highlighted == 0)
            this.transform.GetComponent<Image>().color = baseColor;
        else
            this.transform.GetComponent<Image>().color = highlightedColor;
    }
    
    public void DeHighlight()
    {
        highlighted = 0;
        this.transform.GetComponent<Image>().color = baseColor;
    }

    public void Pressed()
    {
        this.transform.GetComponent<Image>().color = pressedColor;
    }
}
