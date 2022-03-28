using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectManagmentScript : MonoBehaviour
{
    public GameObject content; // ide tesszük a szineket
    public GameObject prefabButton; // hogy tudjuk törölni a szint
    public GameObject unitMakerScriptHolder; // hozzá tudjuk adni a szineket a listához
    public UnityEngine.Color selectedColor; // kulso sourceból kapjuk meg
    public TMP_Text amountInput;
    public TMP_Text typeInput;

    //ColorDeletePopUp
    public GameObject colorDeletePopUp_GO;

    //private things
    private string type;
    private int amount;
    public int db;
    private List<GameObject> effeklista;

    // Start is called before the first frame update
    void Start()
    {
        effeklista = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aplyEffects()
    {
        ++db;
        type = typeInput.text;
        if (type == "támadási-S")
            type = "támadási sebesség";
        else if (type == "támadási-T")
            type = "támadási távolság";
        int.TryParse(amountInput.text.ToString(), out int result);
        amount = result;
        GameObject temp = GameObject.Instantiate(prefabButton, content.transform);
        temp.GetComponent<Image>().color = selectedColor;
        if (db > 16)
            content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, content.GetComponent<RectTransform>().rect.width + 60);
        temp.GetComponent<ColorPickerMenuButtonScript>().melyikelem = (selectedColor, type, amount);
        temp.GetComponent<ColorPickerMenuButtonScript>().whereToPlace = colorDeletePopUp_GO;
        effeklista.Add(temp);
        unitMakerScriptHolder.GetComponent<UnitScript>().EffectColors.Add((selectedColor, type, amount));

    }
    //for removeEffect()
    public Image removeffectColor;
    public TMP_Text removeString;
    public void removeEffect()
    {
        for (int i = 0; i < effeklista.Count; i++)
        {
            var item = effeklista[i];
            if (item.GetComponent<ColorPickerMenuButtonScript>().melyikelem.Item1 == removeffectColor.color && item.GetComponent<ColorPickerMenuButtonScript>().melyikelem.Item2 == removeString.text)
            {
                effeklista.RemoveAt(i);
                GameObject.Destroy(item);
            }
        }
        if(db>16)
        {
            content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, content.GetComponent<RectTransform>().rect.width - 60);
        }
        --db;
    }
}
