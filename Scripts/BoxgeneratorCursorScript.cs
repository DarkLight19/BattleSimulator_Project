using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxgeneratorCursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Camera cam;
    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = (Vector2)(cam.ScreenToWorldPoint(Input.mousePosition));
    }
}
