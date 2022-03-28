using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitPrefabScrit : MonoBehaviour
{
    public bool startSimulation = false;

    //original
    public Color color;
    public float AD;
    public float HP;
    public float Spd;
    public float Def;
    public float AR;

    //effected
    public float ADeffected;
    public float HPeffected;
    public float Spdeffected;
    public float Defeffected;
    public float AReffected;
    //effects:
    public Camera cam;
    public Texture2D image;
    public GameObject listContainer;

    public void resetEffects()
    {
        ADeffected = AD;
        HPeffected = HP;
        Spdeffected = Spd;
        Defeffected = Def;
        AReffected = AR;
    }

    public void activateEffect(string name, float percentage)
    {
        if (name == "Sebesség")
            Spdeffected = Spd + Spd * (1f + (percentage / 100));
        else if (name == "Sebzés")
            ADeffected = AD + AD * (1f + (percentage / 100));
        else if (name == "Páncél")
            Defeffected = Def + Def * (1f + (percentage / 100));
        else if (name == "Támadási Távolság")
            AReffected = AR + AR * (1f + (percentage / 100));
        else if (name == "Életerõ")
            HPeffected = HP + HP * (1f + (percentage / 100));
    }
    //enemy:
    List<Transform> enemys = new List<Transform>();
    float distance = float.MaxValue;
    public Vector3 closestTarget;

    // Start is called before the first frame update
    void Start()
    {
        resetEffects();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        TimeAlapsed = 0f;
        /*
        GameObject UnitmakerObj = GameObject.Find("UnitMakerPanel");
        foreach (Transform item in UnitmakerObj.transform)
        {
            //add the enemys
            if (item.gameObject.GetComponent<unitPrefabScrit>().color != color)
            {
                enemys.Add(item);
                float tempDistance = (item.position - this.transform.position).magnitude;
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                }
            }*
        }*/
    }


    // Update is called once per frame
    void Update()
    {

    }

    private float TimeAlapsed;
    private void FixedUpdate()
    {
        //TimeAlapsed += Time.deltaTime;
        if (startSimulation)
        {

            Vector3 fromPlayerTarget = (closestTarget- this.transform.position);
            this.transform.position += fromPlayerTarget / fromPlayerTarget.magnitude * Spdeffected / 100f;

            //checkforEffect:
            Vector3 screenpoint = cam.WorldToScreenPoint(this.transform.position);
            UnityEngine.Color tempcolor = (UnityEngine.Color)(image.GetPixel(Mathf.FloorToInt(screenpoint.x * image.width / 1280), Mathf.FloorToInt(screenpoint.y * image.height / 720)));
            aplyEffect(tempcolor);
        }
    }

    public void aplyEffect(UnityEngine.Color color)
    {
        //ment to be used for multiple effects within one color
        resetEffects();
        foreach ((UnityEngine.Color szin,string milyen ,int szazalek) item in listContainer.GetComponent<UnitScript>().EffectColors)
        {
            if (item.szin == color)
            {
                activateEffect(item.milyen, item.szazalek);
            }
        }
    }
}
