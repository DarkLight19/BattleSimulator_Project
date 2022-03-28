using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeAndAplyButtonScript : MonoBehaviour
{
    public UnityEngine.Color baseColor;
    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;

    public Image belso;
    public Image also;
    public Image alsoKetto;

    private int highlighted = 0;

    public void Highlighted()
    {
        highlighted = 1;
        belso.color = highlightedColor;
        also.color = highlightedColor;
        alsoKetto.color = highlightedColor;
    }

    public void Deselect()
    {
        if (highlighted == 0)
        {
            belso.color = baseColor;
            also.color = baseColor;
            alsoKetto.color = baseColor;
        }
        else
        {
            belso.color = highlightedColor;
            also.color = highlightedColor;
            alsoKetto.color = highlightedColor;
        }
    }

    public void DeHighlight()
    {
        highlighted = 0;
        belso.color = baseColor;
        also.color = baseColor;
        alsoKetto.color = baseColor;
    }

    public void Pressed()
    {
        belso.color = pressedColor;
        also.color = pressedColor;
        alsoKetto.color = pressedColor;
    }
}
