using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuAnimationScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonPressed()
    {
        if (anim.GetFloat("playButtonFloat") > 0)
            anim.SetFloat("playButtonFloat", -1);
        else
            anim.SetFloat("playButtonFloat", 1);
    }

    public void InfoButtonPressed()
    {
        if (anim.GetFloat("infoButtonFloat") > 0)
            anim.SetFloat("infoButtonFloat", -1);
        else
            anim.SetFloat("infoButtonFloat", 1);
    }
}
