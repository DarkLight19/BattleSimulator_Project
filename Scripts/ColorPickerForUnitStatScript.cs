using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerForUnitStatScript : MonoBehaviour
{
    public Image ColorPickerColorImage;
    public Transform prefabPlace;
    public GameObject prefab;
    public void Use()
    {
        GameObject a = GameObject.Instantiate(prefab, prefabPlace);
        a.GetComponent<unitColorPickerPrefabScript>().givenColor = ColorPickerColorImage.color;
        a.GetComponent<unitColorPickerPrefabScript>().onStart();
    }
}
