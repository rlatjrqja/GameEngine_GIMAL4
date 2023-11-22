using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public string axis;
    public float movespeed = 5f;
    public float movedistance = 3f;
    bool path = true;
    Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(axis == "x")
        {
            if (path)
            {
                transform.Translate(Vector3.right * movespeed * Time.deltaTime);
                if(transform.position.x > pos.x + movedistance)
                {
                    path = !path;
                }
            }
            else
            {
                transform.Translate(Vector3.left * movespeed * Time.deltaTime);
                if (transform.position.x < pos.x - movedistance)
                {
                    path = !path;
                }
            }
        }
        if (axis == "y")
        {
            if (path)
            {
                transform.Translate(Vector3.up * movespeed * Time.deltaTime);
                if (transform.position.y > pos.y + movedistance)
                {
                    path = !path;
                }
            }
            else
            {
                transform.Translate(Vector3.down * movespeed * Time.deltaTime);
                if (transform.position.y < pos.y - movedistance)
                {
                    path = !path;
                }
            }
        }
        if (axis == "z")
        {
            if (path)
            {
                transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
                if (transform.position.z > pos.z + movedistance)
                {
                    path = !path;
                }
            }
            else
            {
                transform.Translate(Vector3.back * movespeed * Time.deltaTime);
                if (transform.position.z < pos.z - movedistance)
                {
                    path = !path;
                }
            }
        }
    }
}
