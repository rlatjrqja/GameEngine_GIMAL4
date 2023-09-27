using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody Prigidbody;
    float moveVert =0;
    float moveHor =0;
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        Prigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVert = Input.GetAxis("Vertical")*moveSpeed;
        moveHor = Input.GetAxis("Horizontal")*moveSpeed;

        if(!isJumping ) 
        {
            transform.Translate(moveHor, 0, moveVert);
        }
        else
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Prigidbody.AddForce(Vector3.up * 100f);
            }
        }
    }
}
