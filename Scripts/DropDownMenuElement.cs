using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownMenuElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject menu;
    public TextMeshProUGUI mainText;
    public void setMainText()
    {
        mainText.text = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        menu.SetActive(false);
    }
}
