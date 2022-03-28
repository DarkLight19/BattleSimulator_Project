using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class EffectManagment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (content.transform.childCount < 9 && content.GetComponent<RectTransform>().rect.width > 600)
            content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, content.GetComponent<RectTransform>().sizeDelta.x - 60);
    }

    public GameObject menu;
    public GameObject unitMakerSciprtHolder;
    public UnityEngine.Color pickedColor;
    public void DropDownMenu()
    {
        if (menu.activeSelf)
            menu.SetActive(false);
        else
            menu.SetActive(true);
    }

    public TextMeshProUGUI mainText;
    public TextMeshProUGUI inputFieldText;
    public TMP_InputField inputField;

    //adding the selected color to the menu
    public GameObject content;
    public Button prefabButton;
    public GameObject DeleteColorButtonPopUpGO;
    public void EffectSend()
    {
        //hozzáadás az adatbázishoz
        int number = int.Parse(inputField.text);

        unitMakerSciprtHolder.GetComponent<UnitScript>().EffectColors.Add(((UnityEngine.Color)pickedColor, mainText.text.ToString(), number));
        
        if(content.transform.childCount > 8)
            content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, content.GetComponent<RectTransform>().sizeDelta.x + 60);

        prefabButton.GetComponent<ColorPickerMenuButtonScript>().whereToPlace = DeleteColorButtonPopUpGO;
        prefabButton.GetComponent<Image>().color = (UnityEngine.Color)pickedColor;
        GameObject a = GameObject.Instantiate(prefabButton, content.transform).gameObject;
        a.GetComponent<ColorPickerMenuButtonScript>().melyikelem = ((UnityEngine.Color)pickedColor, mainText.text.ToString(), number);
    }

    //kinézet
    public void changeSkin()
    {
        //List<Image> x = this.transform.GetComponentsInChildren<Image>(true).ToList()/*.Where(k => k.color != Color.black).ToList()*/;
        foreach (Image item in this.transform.GetComponentsInChildren<Image>(true))
        {
            /*UnityEngine.Color temp = item.color;
            if ((temp.r == 0f && temp.g == 0f && temp.b == 0f))
                item.color = temp;
            else*/
            item.color = new UnityEngine.Color(pickedColor.r, pickedColor.g, pickedColor.b, item.color.a);
        }
    }

    //for Delete()
    public Image colorToBeDeleted;
    public TMP_Text typeToBeDeleted;
    public void Delete()
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            if(content.transform.GetChild(i).GetComponent<ColorPickerMenuButtonScript>().melyikelem.Item1 == colorToBeDeleted.color && content.transform.GetChild(i).GetComponent<ColorPickerMenuButtonScript>().melyikelem.Item2 == typeToBeDeleted.text)
            {
                GameObject.Destroy(content.transform.GetChild(i).gameObject);
            }
        }
    }
    
}
