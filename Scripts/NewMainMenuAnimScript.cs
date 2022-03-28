using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMainMenuAnimScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeOrOpen()
    {
        if (anim.GetFloat("FelLe") > 0)
            anim.SetFloat("FelLe", -1);
        else
            anim.SetFloat("FelLe", 1);
    }
}
