using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SwitchUpOrDown();
    }

    public bool fel = true;
    public void SwitchUpOrDown()
    {
        if (fel)
        {
            anim.SetBool("GoDown", false);
            anim.SetBool("GoUp", true);
        }
        else
        {
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", true);
        }

        fel = !fel;
    }

}
