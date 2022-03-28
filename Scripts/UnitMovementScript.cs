using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitMovementScript : MonoBehaviour
{
    //timer
    public Stopwatch timer = new Stopwatch();

    //main variables
    public bool isDead = false;
    public bool AlowedToMove = true;
    public bool startSimulation = false;

    public GameObject closestTarget;
    public UnityEngine.Color color = new UnityEngine.Color(0,0,0,0);
    public Texture2D image;
    public GameObject listContainer;
    public Camera cam;

    //original
    public float AD;
    public float AS;
    public float HP;
    public float Def;
    public float Spd;
    public bool trueIfFix;
    public float AR;

    //effected
    public float ADeffected;
    public float ASeffected;
    public float HPeffected;
    public float Spdeffected;
    public float Defeffected;
    public float AReffected;
    // Start is called before the first frame update
    void Start()
    {
        resetEffects();
        timer.Start();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startSimulation)
        {
            float tempDist = Vector2.Distance(closestTarget.transform.position, this.transform.position);

            //retarget if the target has died
            if (closestTarget.GetComponent<UnitMovementScript>().isDead)
                retarget();

            //movement
            if (tempDist > AR-0.1f)
                this.transform.position = Vector2.MoveTowards(this.transform.position, closestTarget.transform.position, Spdeffected / 100);

            //checkforEffect:
            Vector3 screenpoint = cam.WorldToScreenPoint(this.transform.position);
            UnityEngine.Color tempcolor = (UnityEngine.Color)(image.GetPixel(Mathf.FloorToInt(screenpoint.x * image.width / 1280), Mathf.FloorToInt(screenpoint.y * image.height / 720)));
            aplyEffect(tempcolor);

            //checkforAttack
            if (timer.Elapsed.TotalSeconds > AS && tempDist < AR)
                Attack();
        }
    }

    #region Effect Stuff

    public void resetEffects()
    {
        ADeffected = AD;
        ASeffected = AS;
        HPeffected = HP;
        Spdeffected = Spd;
        Defeffected = Def;
        AReffected = AR;
    }
    public void activateEffect(string name, float percentage)
    {
        if (name == "sebesség")
            Spdeffected = Spd + Spd * (1f + (percentage / 100));
        else if (name == "sebzés")
            ADeffected = AD + AD * (1f + (percentage / 100));
        else if (name == "páncél")
            Defeffected = Def + Def * (1f + (percentage / 100));
        else if (name == "támadási távolság")
            AReffected = AR + AR * (1f + (percentage / 100));
        else if (name == "támadási sebesség")
            AReffected = AR + AR * (1f + (percentage / 100));
        else if (name == "életerõ")
            HPeffected = HP + HP * (1f + (percentage / 100));
    }
    public void aplyEffect(UnityEngine.Color color)
    {
        //ment to be used for multiple effects within one color
        resetEffects();
        foreach ((UnityEngine.Color szin, string milyen, int szazalek) item in listContainer.GetComponent<UnitScript>().EffectColors.Where(k=>k.szin == color))
                activateEffect(item.milyen, item.szazalek);
    }

    #endregion

    public void retarget()
    {
        long checkforWinCounter = 0;
        float tempDist = 0;
        float minDist = long.MaxValue;
        GameObject toBetarget = new GameObject();
        toBetarget.transform.position = new Vector3(0, 0, 0); //ha valaki nem csinál 2 csapatot

        for (int i = 0; i < listContainer.transform.childCount; i++)
        {
            if (listContainer.transform.GetChild(i).GetComponent<UnitMovementScript>().color == this.color || listContainer.transform.GetChild(i).GetComponent<UnitMovementScript>().isDead)
                continue;

            tempDist = Vector2.Distance(this.transform.position, listContainer.transform.GetChild(i).transform.position);
            if (tempDist >= minDist)
                continue;

            ++checkforWinCounter;
            minDist = tempDist;
            toBetarget = listContainer.transform.GetChild(i).gameObject;
        }
        if (checkforWinCounter != 0)
            this.closestTarget = toBetarget;
        else
            listContainer.GetComponent<UnitScript>().Win(this.color);
    }

    public void Attack()
    {
        timer.Restart();
        closestTarget.GetComponent<UnitMovementScript>().Damaged(AD);
    }

    public void Damaged(float damage)
    {
        float effectiveDamage = 0;
        if (trueIfFix)
        {
            if (Defeffected < damage)
                effectiveDamage = damage - Defeffected;
        }
        else
        {
            if (Defeffected < 100)
                effectiveDamage = damage * (1 - (Defeffected / 100));
        }

        if (HPeffected - effectiveDamage < 0)
        {
            isDead = true;
            this.gameObject.SetActive(false);
        }
        else
        {
            HPeffected -= effectiveDamage;
            if (HPeffected < HP)
                HP = HPeffected;

            //valami animáció is kell
        }
    }
}
