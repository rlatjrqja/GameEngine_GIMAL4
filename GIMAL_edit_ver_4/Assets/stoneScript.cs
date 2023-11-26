using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneScript : MonoBehaviour
{
    public Vector3 pos;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.useGravity = false;
        rb.isKinematic = true;
        pos = transform.position;
    }
    void Roll()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        Invoke("Reload", 30f);
    }
    void Reload()
    {
        transform.position = pos;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

}
