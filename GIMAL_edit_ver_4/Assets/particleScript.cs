using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    float ptimer;
    void Start()
    {
        ptimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ptimer += Time.deltaTime;
        //if(ptimer > 2f) gameObject.SetActive(false);
        if (ptimer > 2f) Destroy(gameObject);
    }
}
