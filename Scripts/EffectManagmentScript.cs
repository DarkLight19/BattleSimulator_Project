using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectManagmentScript : MonoBehaviour
{
    public GameObject content; // ide tessz�k a szineket
    public GameObject prefabButton; // hogy tudjuk t�r�lni a szint
    public GameObject unitMakerScriptHolder; // hozz� tudjuk adni a szineket a list�hoz
    public UnityEngine.Color selectedColor; // kulso sourceb�l kapjuk meg
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
        if (type == "t�mad�si-S")
            type = "t�mad�si sebess�g";
        else if (type == "t�mad�si-T")
            type = "t�mad�si t�vols�g";
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
