using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CirclearButtonScript : MonoBehaviour
{
    public Camera cam;

    public (RawImage, int) felso;
    public (RawImage, int) jobbFelso;
    public (RawImage, int) jobbAlso;
    public (RawImage, int) Also;
    public (RawImage, int) balAlso;
    public (RawImage, int) balFelso;

    public UnityEngine.Color originalColor;
    public UnityEngine.Color highlightedColor;
    public UnityEngine.Color pressedColor;

    public GameObject MainFelsoButton;
    public GameObject CircuralPicker;

    // Start is called before the first frame update
    void Start()
    {
        felso.Item1 = this.transform.GetChild(0).GetComponent<RawImage>();
        jobbFelso.Item1 = this.transform.GetChild(1).GetComponent<RawImage>();
        jobbAlso.Item1 = this.transform.GetChild(2).GetComponent<RawImage>();
        Also.Item1 = this.transform.GetChild(3).GetComponent<RawImage>();
        balAlso.Item1 = this.transform.GetChild(4).GetComponent<RawImage>();
        balFelso.Item1 = this.transform.GetChild(5).GetComponent<RawImage>();
    }

    public bool alowedToUpdate = true;
    // Update is called once per frame
    void LateUpdate()
    {
        if (alowedToUpdate)
        {
            Vector2 mouspos = cam.ScreenToWorldPoint(Input.mousePosition);
            deHighlightEverything();

            if (mouspos.magnitude > 3 && alowedToUpdate)
            {
                float angle = Vector2.Angle(new Vector2(1, 0), mouspos);
                if (mouspos.y < 0)
                    angle = -angle;

                if (angle > 0 && angle <= 60)
                    highlighted(1);
                else if (angle > 60 && angle <= 120)
                    highlighted(0);
                if (angle > 120 && angle <= 180)
                    highlighted(5);
                if (angle > -60 && angle <= 0)
                    highlighted(2);
                if (angle > -120 && angle <= -60)
                    highlighted(3);
                if (angle > -180 && angle <= -120)
                    highlighted(4);
                //Debug.Log(angle + " vector: " + mouspos);
            }
        }

    }

    public void onClickRelese()
    {
        alowedToUpdate = true;
    }
    public void OnClick()
    {
        LateUpdate();
        if (felso.Item2 == 1)
        {
            MainFelsoButton.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "sebesség";
            pressed(0);
        }
        else if (jobbFelso.Item2 == 1)
        {
            MainFelsoButton.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "sebzés";
            pressed(1);
        }
        else if (jobbAlso.Item2 == 1)
        {
            MainFelsoButton.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "támadási-S";
            pressed(2);
        }
        else if (Also.Item2 == 1)
        {
            MainFelsoButton.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "támadási-T";
            pressed(3);
        }
        else if (balAlso.Item2 == 1)
        {
            MainFelsoButton.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "életerõ";
            pressed(4);
        }
        else if (balFelso.Item2 == 1)
        {
            MainFelsoButton.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "páncél";
            pressed(5);
        }

        alowedToUpdate = false;
        CircuralPicker.GetComponent<CircularAnimScript>().close();
        //ide kell majd nyomni a klikknél
    }

    private void deHighlightEverything()
    {
        deHighlighted(0);
        deHighlighted(1);
        deHighlighted(2);
        deHighlighted(3);
        deHighlighted(4);
        deHighlighted(5);
    }

    public void highlighted(int hanyadikRawImage)
    {
        if (hanyadikRawImage == 0)
        {
            felso.Item1.color = highlightedColor;
            //this.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            felso.Item2 = 1;
        }
        else if (hanyadikRawImage == 1)
        {
            jobbFelso.Item1.color = highlightedColor;
            //this.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            jobbFelso.Item2 = 1;
        }
        else if (hanyadikRawImage == 2)
        {
            jobbAlso.Item1.color = highlightedColor;
            //this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            jobbAlso.Item2 = 1;
        }
        else if (hanyadikRawImage == 3)
        {
            Also.Item1.color = highlightedColor;
            //this.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            Also.Item2 = 1;
        }
        else if (hanyadikRawImage == 4)
        {
            balAlso.Item1.color = highlightedColor;
            //this.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
            balAlso.Item2 = 1;
        }
        else if (hanyadikRawImage == 5)
        {
            balFelso.Item1.color = highlightedColor;
            //this.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(5).GetChild(1).gameObject.SetActive(true);
            balFelso.Item2 = 1;
        }
    }

    public void deHighlighted(int hanyadikRawImage)
    {
        if (hanyadikRawImage == 0)
        {
            felso.Item1.color = originalColor;
            //this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            //this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            felso.Item2 = 0;
        }
        else if (hanyadikRawImage == 1)
        {
            jobbFelso.Item1.color = originalColor;
            //this.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            //this.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            jobbFelso.Item2 = 0;
        }
        else if (hanyadikRawImage == 2)
        {
            jobbAlso.Item1.color = originalColor;
            //this.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            //this.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            jobbAlso.Item2 = 0;
        }
        else if (hanyadikRawImage == 3)
        {
            Also.Item1.color = originalColor;
            //this.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            //this.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
            Also.Item2 = 0;
        }
        else if (hanyadikRawImage == 4)
        {
            balAlso.Item1.color = originalColor;
            //this.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
            //this.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
            balAlso.Item2 = 0;
        }
        else if (hanyadikRawImage == 5)
        {
            balFelso.Item1.color = originalColor;
            //this.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
            //this.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
            balFelso.Item2 = 0;
        }
    }

    public void pressed(int hanyadikRawImage)
    {
        if (hanyadikRawImage == 0)
            felso.Item1.color = pressedColor;
        else if (hanyadikRawImage == 1)
            jobbFelso.Item1.color = pressedColor;
        else if (hanyadikRawImage == 2)
            jobbAlso.Item1.color = pressedColor;
        else if (hanyadikRawImage == 3)
            Also.Item1.color = pressedColor;
        else if (hanyadikRawImage == 4)
            balAlso.Item1.color = pressedColor;
        else if (hanyadikRawImage == 5)
            balFelso.Item1.color = pressedColor;
    }

    public void dePressed(int hanyadikRawImage)
    {
        if (hanyadikRawImage == 0)
        {
            if (felso.Item2 == 0)
                deHighlighted(0);
            else
                highlighted(0);
        }
        else if (hanyadikRawImage == 1)
        {
            if (jobbFelso.Item2 == 0)
                deHighlighted(1);
            else
                highlighted(1);
        }
        else if (hanyadikRawImage == 2)
        {
            if (jobbAlso.Item2 == 0)
                deHighlighted(2);
            else
                highlighted(2);
        }
        else if (hanyadikRawImage == 3)
        {
            if (Also.Item2 == 0)
                deHighlighted(3);
            else
                highlighted(3);
        }
        else if (hanyadikRawImage == 4)
        {
            if (balAlso.Item2 == 0)
                deHighlighted(4);
            else
                highlighted(4);
        }
        else if (hanyadikRawImage == 5)
        {
            if (balFelso.Item2 == 0)
                deHighlighted(5);
            else
                highlighted(5);
        }
    }
}
