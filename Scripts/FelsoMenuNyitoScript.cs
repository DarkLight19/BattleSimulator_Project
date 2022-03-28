using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FelsoMenuNyitoScript : MonoBehaviour
{
    public UnityEngine.Color baseColor;
    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;

    public RawImage belso;
    public RawImage also;

    private int highlighted = 0;

    public void Highlighted()
    {
        highlighted = 1;
        belso.color = highlightedColor;
        also.color = highlightedColor;
    }

    public void Deselect()
    {
        if (highlighted == 0)
        {
            belso.color = baseColor;
            also.color = baseColor;
        }
        else
        {
            belso.color = highlightedColor;
            also.color = highlightedColor;
        }
    }

    public void DeHighlight()
    {
        highlighted = 0;
        belso.color = baseColor;
        also.color = baseColor;
    }

    public void Pressed()
    {
        belso.color = pressedColor;
        also.color = pressedColor;
    }

}
