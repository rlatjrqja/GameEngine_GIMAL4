using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMove : MonoBehaviour
{
    public GameObject belt1;
    public GameObject belt2;
    public float speed;
    float posx;
    float posy;
    float posz;
    bool playerenter = false;
    public GameObject player;
    void Start()
    {
        posx = transform.position.x;
        posy = transform.position.y;
        posz = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(belt1.transform.position.x > posx + 7)
        {
            belt1.transform.position = new Vector3(posx - 2f, posy, posz);
        } 
        if (belt2.transform.position.x > posx + 7)
        {
            belt2.transform.position = new Vector3(posx - 2f, posy, posz);
        }
        if(playerenter)
        {
            player.transform.Translate(new Vector3(-3, 0, 0) * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        playerenter = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerenter = false;
    }
}
