using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitScript : MonoBehaviour
{
    public GameObject CirclePrefab;
    public GameObject storage;
    public GameObject popUpOptions;
    public bool simulationStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        List<UnitMovementScript> temp = new List<UnitMovementScript>();
        for (int i = 0; i < this.transform.childCount; i++)
            temp.Add(this.transform.GetChild(i).GetComponent<UnitMovementScript>());
        unitPrefabCollection.Add(temp);
        EffectColors = new List<(UnityEngine.Color szin, string milyen, int szazalek)>();
    }

    // Update is called once per frame
    byte lessRetargeting = 0;
    void FixedUpdate()
    {
        /*
        ++lessRetargeting;
        if (lessRetargeting == 10 && simulationStarted)
        {
            lessRetargeting = 0;
            retargetAll();
        }*/
    }

    //information storage
    public GameObject battleGroundScriptHolder;
    public List<(UnityEngine.Color szin, string milyen, int szazalek)> EffectColors;

    //Input from user (Through input fields)
    public float size;
    public int N;
    public bool trueIfFix;
    public float AD;
    public float AS;
    public float HP;
    public float Spd;
    public float Def;
    public float AR;

    //these are set by mainScipt/Input from user:
    public Color prefabColor = new Color(255,255,255);
    //these are set by the BoxCreation Script:
    public GameObject square;
    public Vector3 firstCordinate;
    public Vector3 secondCordinate;

    //---------------------
    public List<List<UnitMovementScript>> unitPrefabCollection = new List<List<UnitMovementScript>>();
    //---------------------
    public void createTroops()
    {
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        float xLength = Math.Abs(cam.ScreenToWorldPoint(firstCordinate).x - cam.ScreenToWorldPoint(secondCordinate).x);
        float yLength = Math.Abs(cam.ScreenToWorldPoint(firstCordinate).y - cam.ScreenToWorldPoint(secondCordinate).y);

        #region prímválasztás
        //elso 100 prím szám
        List<int> Primes = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541 };
        List<int> Nprimleosztas = new List<int>();
        while (N != 1)
        {
            foreach (var item in Primes)
            {
                if (N % item == 0)
                {
                    N = N / item;
                    Nprimleosztas.Add(item);
                    break;
                }
            }
        }

        List<List<int>> combos = GetAllCombos(Nprimleosztas);

        List<double> megoldasKetto = bestOption(combos, xLength / yLength, Nprimleosztas);
        #endregion
        
        float xSteps = Math.Abs(xLength / (float)megoldasKetto[0]);
        float ySteps = Math.Abs(yLength / (float)megoldasKetto[1]);

        //Debug.Log(megoldasKetto[0] + " " + megoldasKetto[1]);
        //Debug.Log(xLength + " " + xSteps + "\t" + yLength + " " + ySteps);

        Vector3 temp = square.transform.position;
        float xActPos = temp.x - xLength/2 + xSteps / 2;
        float yActPos = temp.y + yLength/2 - ySteps / 2;

        List<UnitMovementScript> tempUnitMovementList = new List<UnitMovementScript>();
        for (int i = 0; i < megoldasKetto[1]; i++) //y
        {
            for (int j = 0; j < megoldasKetto[0]; j++) //x
            {
                CirclePrefab.transform.GetComponent<SpriteRenderer>().sortingOrder = 11;
                CirclePrefab.transform.localScale = new Vector3(size / 10, size / 10, 0);
                CirclePrefab.GetComponent<SpriteRenderer>().color = prefabColor;
                CirclePrefab.transform.position = new Vector3(xActPos + xSteps * j, yActPos - ySteps * i, 0);
                
                GameObject a = Instantiate(CirclePrefab, storage.transform, true);
                //------
                a.GetComponent<UnitMovementScript>().AD = AD;
                a.GetComponent<UnitMovementScript>().AS = AS;
                a.GetComponent<UnitMovementScript>().HP = HP;
                a.GetComponent<UnitMovementScript>().Spd = Spd;
                a.GetComponent<UnitMovementScript>().Def = Def;
                a.GetComponent<UnitMovementScript>().AR = AR;
                a.GetComponent<UnitMovementScript>().color = this.prefabColor;
                a.GetComponent<UnitMovementScript>().image = battleGroundScriptHolder.GetComponent<battleGroundScript>().image;
                a.GetComponent<UnitMovementScript>().listContainer = this.transform.gameObject;
                a.GetComponent<UnitMovementScript>().startSimulation = false;
                tempUnitMovementList.Add(a.GetComponent<UnitMovementScript>());
            }
        }
        if (tempUnitMovementList.Count != 0)
            unitPrefabCollection.Add(tempUnitMovementList);
    }

    #region prime grouping

    public static List<List<T>> GetAllCombos<T>(List<T> list)
    {
        int comboCount = (int)Math.Pow(2, list.Count) - 1;
        List<List<T>> result = new List<List<T>>();
        for (int i = 1; i < comboCount + 1; i++)
        {
            // make each combo here
            result.Add(new List<T>());
            for (int j = 0; j < list.Count; j++)
            {
                if ((i >> j) % 2 != 0)
                    result.Last().Add(list[j]);
            }
        }
        return result;
    }
    public static List<double> bestOption(List<List<int>> combos, double arany, List<int> eredeti)
    {
        List<double> bestoption = new List<double>() { 0, 0, int.MaxValue };
        foreach (var item in combos)
        {
            int szamEGY = 1;
            int szamKetto = 1;
            List<int> kipotolt = parlistacsinalo(eredeti, item);
            foreach (var i in item)
            {
                szamEGY = szamEGY * i;
            }

            foreach (var i in kipotolt)
            {
                szamKetto = szamKetto * i;
            }

            if (Math.Abs((double)szamEGY / szamKetto - arany) < bestoption[2])
                bestoption = new List<double>() { szamEGY, szamKetto, Math.Abs((double)szamEGY / szamKetto - arany) };
        }
        return bestoption;
    }
    public static List<int> parlistacsinalo(List<int> eredeti, List<int> megvanmar)
    {
        List<int> solution = new List<int>(eredeti);

        for (int i = 0; i < megvanmar.Count; i++)
        {
            for (int j = 0; j < solution.Count; j++)
            {
                if (megvanmar[i] == solution[j])
                {
                    solution.RemoveAt(j);
                    break;
                }
            }
        }

        return solution;
    }

    #endregion

    //Inputs
    public TMP_InputField SizeInput;
    public TMP_InputField NInput;
    public TMP_InputField ADInput;
    public TMP_InputField SpdInput;
    public TMP_InputField DefInput;
    public TMP_InputField ARInput;
    public TMP_InputField ASInput;
    public TMP_InputField HPInput;
    public void doneButtonPressed()
    {
        size = float.Parse(SizeInput.text);
        N = int.Parse(NInput.text);
        AD = int.Parse(ADInput.text);
        Spd = int.Parse(SpdInput.text);
        Def = int.Parse(DefInput.text);
        AR = int.Parse(ARInput.text);
        AS = int.Parse(ASInput.text);
        HP = int.Parse(HPInput.text);
        createTroops();
        popUpOptions.gameObject.SetActive(false);
    }

    //Square-holder:
    public GameObject squareCollection;

    public void StartSimulation()
    {
        simulationStarted = true;
        foreach (var i in unitPrefabCollection)
            foreach (var item in i)
            {
                item.GetComponent<UnitMovementScript>().retarget();
                item.GetComponent<UnitMovementScript>().startSimulation = true;
            }
        
        for (int i = 0; i < squareCollection.transform.childCount; i++)
            GameObject.Destroy(squareCollection.transform.GetChild(i).gameObject);
    }

    //to delete chosen effect:
    public Image deleteImage;
    public TMP_Text deleteType;
    public void Delete()
    {
        for (int i = 0; i < EffectColors.Count; i++)
        {
            if (EffectColors[i].szin == deleteImage.color && EffectColors[i].milyen == deleteType.text)
            {
                EffectColors.RemoveAt(i);
                break;
            }
        }
    }

    //Targeting of Units
    public void retargetAll()
    {
        //check if 'dead'
        foreach (var item in unitPrefabCollection)
        {
            for (int i = 0; i < item.Count; i++)
            {
                if (!item[i].isDead)
                    continue;

                GameObject temp = item[i].gameObject;
                item.RemoveAt(i);
                GameObject.Destroy(temp);
            }
        }

        // !!!!!!!!!!!!!!!!! retarget only if the target has died !!!!!!!!!!
        //retargeting for a 'pack' of units
        foreach (var item in unitPrefabCollection)
        {
            //getting the first in the pack
            Vector3 activePos = item[0].transform.position;

            //For searc of the minimum distance
            int minDist = int.MaxValue;
            Vector3 minPos = new Vector3();
            GameObject minPos_GO = new GameObject();

            #region if it gets laggy
            /* //just cheking the first ot the 'pack'
            foreach (var i in unitPrefabCollection.Where(k=>k[0].color != item[0].color))
            {
                float tempDist = Vector3.Distance(i[0].transform.position, item[0].transform.position);
                if (tempDist >= minDist)
                    continue;
                minDist = (int)tempDist;
                minPos = i[0].transform.position;
            }*/
            #endregion

            //checking every other unit with a different color
            foreach (var i in unitPrefabCollection)
                foreach (var j in i.Where(k=>k.color != item[0].color))
                {
                    float tempDist = Vector3.Distance(j.transform.position, item[0].transform.position);
                    if (tempDist >= minDist)
                        continue;
                    minDist = (int)tempDist;
                    minPos = j.transform.position;
                    minPos_GO = j.gameObject;
                }

            //setting the minPos for every unit in the 'pack'
            foreach (var i in item)
                i.closestTarget = minPos_GO;
        }
    }

    //
    public GameObject checkBoxOne;
    public GameObject checkBoxTwo;

    public void checkBoxFunction()
    {
        if (checkBoxTwo.GetComponent<Toggle>().isOn == true)
        {
            trueIfFix = false;
            checkBoxOne.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            trueIfFix = true;
            checkBoxOne.GetComponent<Toggle>().isOn = false;
        }
    }

    //win:
    public GameObject WinScene;
    public void Win(UnityEngine.Color colorThatWon)
    {
        WinScene.GetComponent<Image>().color = colorThatWon;
        WinScene.SetActive(true);
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).GetComponent<UnitMovementScript>().startSimulation = false;
    }
}
