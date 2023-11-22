using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneScript : MonoBehaviour
{
    Rigidbody rb;

    void start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
