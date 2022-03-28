using System.Collections;
using SFB;
using System.Drawing;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;

public class battleGroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //ColorPicker stuff
    private bool colorPickerEnabled = false;
    public Image colorPickerPreviewPanel;
    public Transform colorpixkerPanelTrans;

    public void EnableColorPicker()
    {
        Cursor.visible = false;
        colorpixkerPanelTrans.gameObject.SetActive(true);
        colorPickerPreviewPanel.color = new Color32(255, 255, 255, 255);
        colorPickerEnabled = true;
    }

    private void DisableColorPicker()
    {
        Cursor.visible = true;
        colorPickerEnabled = false;
        colorpixkerPanelTrans.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (colorPickerEnabled)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            Vector3 toWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            colorpixkerPanelTrans.transform.position = new Vector3(toWorld.x, toWorld.y, 0);
            colorPickerPreviewPanel.color = image.GetPixel(Mathf.FloorToInt(x*image.width/1280), Mathf.FloorToInt(y*image.height/720));
            if (Input.GetMouseButtonDown(0))
            {
                toBeFoundColor = colorPickerPreviewPanel.color;
                effectPanel.GetComponent<EffectManagmentScript>().selectedColor = toBeFoundColor;
                effectPanel.SetActive(true);
                DisableColorPicker();
            }
        }
    }

    //making effectTrigers around colors
    public UnityEngine.Color toBeFoundColor;
    public GameObject effectPanel;

    //background stuff
    public string path;
    public RawImage battleGroundImagePlace;
    public Texture2D image;

    public void ChooseBattleGround()
    {
        path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "",false)[0];
        //path = EditorUtility.OpenFilePanel("V�lassz ki egy k�pet!", "", "*"); //getting the path
        StartCoroutine(setRawImage());
        
    }

    IEnumerator setRawImage()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + path); //connection string
        yield return www.SendWebRequest(); //waiting till we get the connection


        battleGroundImagePlace.color = new Color32(255, 255, 255, 255);
        image = ((DownloadHandlerTexture)www.downloadHandler).texture;

        //Debug.Log("Texture size: " + image.height + " " + image.width);
        /*
        image.width = 720;
        image.height = 1280;
        */
        battleGroundImagePlace.texture = image;
        //Debug.Log("Raw Image size: " + battleGroundImagePlace.texture.width + " " + battleGroundImagePlace.texture.height + " ");

    }
}
