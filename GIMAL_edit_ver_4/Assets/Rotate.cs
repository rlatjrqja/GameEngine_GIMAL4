using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //물체를 회전시키는 스크립트
    public string Axis = "y";
    public float speed = 1f;
    public Vector3 rotate = new Vector3(0, 0, 0);
    void Start()
    {
        
    }

    void Update()
    {
        if(Axis == "x") 
        {
            rotate.x = 30 * speed;
            rotate.y = 0;
            rotate.z = 0;
        }
        if (Axis == "y")
        {
            rotate.y = 30 * speed;
            rotate.x = 0;
            rotate.z = 0;
        }
        if (Axis == "z")
        {
            rotate.z = 30 * speed;
            rotate.y = 0;
            rotate.x = 0;
        }
        transform.Rotate(rotate * Time.deltaTime);
    }
}
