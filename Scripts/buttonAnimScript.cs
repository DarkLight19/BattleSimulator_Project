using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAnimScript : MonoBehaviour
{
    public void pressedAnim()
    {
        this.transform.GetComponent<Animator>().SetBool("pressed", true);
        StartCoroutine(waitsometime());
    }

    public void changecolor()
    {
        UnityEngine.Color color = this.transform.GetChild(0).GetComponent<Text>().color;
        if (color.r == 0)//fekete
            this.transform.GetChild(0).GetComponent<Text>().color = new Color(255,255,255);
        else
            this.transform.GetChild(0).GetComponent<Text>().color = new Color(0,0,0);
    }
    IEnumerator waitsometime()
    {
        //yield return new WaitForSecondsRealtime(0.05f);
        yield return new WaitForEndOfFrame();
        this.transform.GetComponent<Animator>().SetBool("pressed", false);
    }
 }
