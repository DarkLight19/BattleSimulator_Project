using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorPickerMenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public (UnityEngine.Color, string, int) melyikelem;
    public GameObject whereToPlace;
    public void PopUp()
    {
        whereToPlace.SetActive(true);
        whereToPlace.transform.GetChild(1).GetComponent<Image>().color = melyikelem.Item1;
        whereToPlace.transform.GetChild(2).GetComponent<TMP_Text>().text = melyikelem.Item2;
        whereToPlace.transform.GetChild(3).GetComponent<TMP_Text>().text = melyikelem.Item3.ToString();
    }
    
}
