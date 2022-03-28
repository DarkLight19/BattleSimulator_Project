using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listContainerAnimScript : MonoBehaviour
{
    public Animator anim;
    public void closeOrOpen()
    {
        if (anim.GetFloat("OpenClose") > 0)
            anim.SetFloat("OpenClose", -1);
        else
            anim.SetFloat("OpenClose", 1);
    }
}
