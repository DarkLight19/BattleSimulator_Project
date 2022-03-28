using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddColorUnitStatScript : MonoBehaviour
{
    public GameObject ColorPicker_GO;

    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;
    public UnityEngine.Color originalColor;

    public UnityEngine.Color CROSSoriginalColor;

    public Image background;
    public Image foreground;
    public Image crossOne;
    public Image crossTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isHighlighted = false;

    public void highlighted()
    {
        isHighlighted = true;
        background.color = highlightedColor;
        crossOne.color = highlightedColor;
        crossTwo.color = highlightedColor;

        StartCoroutine(highlightCoroutine());
    }

    public void deHighlight()
    {
        isHighlighted = false;
        background.color = originalColor;
        crossOne.color = CROSSoriginalColor;
        crossTwo.color = CROSSoriginalColor;

        StartCoroutine(deHighlightCoroutine());
    }

    public void pressed()
    {
        background.color = pressedColor;
        crossOne.color = pressedColor;
        crossTwo.color = pressedColor;

        ColorPicker_GO.SetActive(true);
    }

    public void dePressed()
    {
        if (isHighlighted)
        {
            background.color = highlightedColor;
            crossOne.color = highlightedColor;
            crossTwo.color = highlightedColor;
        }
        else
        {
            background.color = originalColor;
            crossOne.color = CROSSoriginalColor;
            crossTwo.color = CROSSoriginalColor;
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
