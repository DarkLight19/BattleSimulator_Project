using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScrpt : MonoBehaviour
{
    private int counter = 0;
    public Sprite threeBars;
    public Sprite twoBars;
    public Sprite oneBar;
    public Sprite muted;
    public Button volumeButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        if (counter == 0)
            volumeButton.image.sprite = twoBars;
        else if (counter == 1)
            volumeButton.image.sprite = oneBar;
        else if (counter == 2)
            volumeButton.image.sprite = muted;
        else if (counter == 3)
            volumeButton.image.sprite = threeBars;

        if (counter == 3)
            counter = 0;
        else
            ++counter;
    }
}
