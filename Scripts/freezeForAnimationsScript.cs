using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeForAnimationsScript : MonoBehaviour
{
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = position;
    }
}
