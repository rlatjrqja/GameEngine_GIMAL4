using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    //������� ���� ��ũ��Ʈ
    public bool isPlayerEnter = false;
    public bool isDisappeared = false;
    public float timer;
    //������µ� �ɸ��� �ð�
    public float timelimit = 3f;
    Collider col;
    Renderer ren;
    void Start()
    {
        col = GetComponent<Collider>();
        ren = GetComponent<Renderer>();
        timer = timelimit;
    }

    void Update()
    {
        if(isPlayerEnter)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if(timer <= 0)
            {
                col.isTrigger = true;
                ren.enabled = false;
                isDisappeared = true;
                isPlayerEnter = false;
                timer = 0f;
            }
        }
        else
        {
            if(isDisappeared)
            {
                //2�� �� �����
                if (timer <= 2)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    isDisappeared = false;
                    col.isTrigger = false;
                    ren.enabled = true;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!isPlayerEnter) 
            {
                isPlayerEnter = true;
            }
        }
    }
}
