using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularAnimScript : MonoBehaviour
{
    public Image circle;
    public float amount;
    public GameObject x;
    public GameObject KorMaga;
    public GameObject Felso;
    public GameObject AmountStuff;
    public GameObject Buttons;

    private bool mehetAzAnimation = true;
    public void open()
    {
        if (mehetAzAnimation)
        {
            KorMaga.SetActive(true);
            Felso.SetActive(false);
            AmountStuff.SetActive(false);
            Buttons.SetActive(false);

            mehetAzAnimation = false;
            amount = -amount;
            StartCoroutine(fill());
        }
    }

    public void close()
    {
        if (mehetAzAnimation)
        {
            mehetAzAnimation = false;
            amount = Mathf.Abs(amount);
            StartCoroutine(fill());
        }
    }

    IEnumerator fill()
    {
        if (amount > 0)//close
        {
            x.SetActive(false);
            circle.gameObject.SetActive(true);
            while (circle.fillAmount < 0.83333333f)
            {
                circle.fillAmount += amount;
                yield return new WaitForSeconds(0.0166666f);
            }
            Felso.SetActive(true);
            KorMaga.SetActive(false);
            AmountStuff.SetActive(true);
            Buttons.SetActive(true);
        }
        else//open
        {
            while (circle.fillAmount > 0f)
            {
                circle.fillAmount += amount;
                yield return new WaitForSeconds(0.0166666f);
            }
            x.SetActive(true);
            x.GetComponent<CentralMenuButtonsScript>().Start();
            circle.gameObject.SetActive(false);
        }
        mehetAzAnimation = true;
    }
}
