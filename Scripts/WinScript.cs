using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject unitHolder;
    public void Win()
    {
        for (int i = 0; i < unitHolder.transform.childCount; i++)
            GameObject.Destroy(unitHolder.transform.GetChild(i).gameObject);

        this.gameObject.SetActive(false);
    }
}
