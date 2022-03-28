using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitColorPickerPrefabScript : MonoBehaviour
{
    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;
    public UnityEngine.Color originalColor;
    public UnityEngine.Color activeColor;

    public GameObject UnitMakerPanel_GO;
    public UnityEngine.Color givenColor;
    public Image background;
    public Image foreground;

    // Start is called before the first frame update
    public void onStart()
    {
        UnitMakerPanel_GO = GameObject.Find("UnitMakerPanel");
        foreground.color = givenColor;
    }
    void Start()
    {
        UnitMakerPanel_GO = GameObject.Find("UnitMakerPanel");
        foreground.color = givenColor;
    }

    private bool isHighlighted = false;
    private bool selected = false;

    public void highlighted()
    {
        isHighlighted = true;
        background.color = highlightedColor;
        StartCoroutine(highlightCoroutine());
    }

    public void deHighlight()
    {
        isHighlighted = false;
        if (selected)
            background.color = activeColor;
        else
            background.color = originalColor;
        StartCoroutine(deHighlightCoroutine());
    }

    public void pressed()
    {
        if(!selected)
        {
            for (int i = 1; i < this.transform.parent.childCount; i++)
            {
                this.transform.parent.GetChild(i).GetComponent<unitColorPickerPrefabScript>().selected = false;
            }
            selected = true;
        }
        background.color = pressedColor;
        UnitMakerPanel_GO.GetComponent<UnitScript>().prefabColor = givenColor;
    }

    public void dePressed()
    {
        if (isHighlighted)
            background.color = highlightedColor;
        else
        {
            if (selected)
                background.color = activeColor;
            else
                background.color = originalColor;
        }
    }

    IEnumerator highlightCoroutine()
    {
        while (background.rectTransform.sizeDelta.x > 28 && isHighlighted)
        {
            background.rectTransform.sizeDelta = new Vector2(background.rectTransform.sizeDelta.x - 2, background.rectTransform.sizeDelta.y - 2);
            foreground.rectTransform.sizeDelta = new Vector2(foreground.rectTransform.sizeDelta.x - 2, foreground.rectTransform.sizeDelta.y - 2);
            yield return new WaitForSeconds(1 / 60f);
        }
    }

    IEnumerator deHighlightCoroutine()
    {
        while (background.rectTransform.sizeDelta.x < 34 && !isHighlighted)
        {
            background.rectTransform.sizeDelta = new Vector2(background.rectTransform.sizeDelta.x + 2, background.rectTransform.sizeDelta.y + 2);
            foreground.rectTransform.sizeDelta = new Vector2(foreground.rectTransform.sizeDelta.x + 2, foreground.rectTransform.sizeDelta.y + 2);
            yield return new WaitForSeconds(1 / 60f);
        }
    }
}
