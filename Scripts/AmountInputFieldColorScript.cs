using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountInputFieldColorScript : MonoBehaviour
{
    public UnityEngine.Color baseColor;
    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;

    public Image belso;

    private int highlighted = 0;

    public void Highlighted()
    {
        highlighted = 1;
        belso.color = highlightedColor;
    }

    public void Deselect()
    {
        if (highlighted == 0)
        {
            belso.color = baseColor;
        }
        else
        {
            belso.color = highlightedColor;
        }
    }

    public void DeHighlight()
    {
        highlighted = 0;
        belso.color = baseColor;
    }

    public void Pressed()
    {
        belso.color = pressedColor;
    }

}
