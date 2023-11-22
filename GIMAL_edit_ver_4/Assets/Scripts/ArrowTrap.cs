using UnityEngine;

public class ArrowTrab : MonoBehaviour
{
    public bool isTrapped = false;
    public bool trapreload = true;
    int i = 0;
    public GameObject ArrowShot;
    public GameObject StoneTrap;
    public GameObject PunchTrap;
    public string trapname;

    void Update()
    {
        
        if (isTrapped)
        {
            if (i > 0)
            {
                transform.Translate(Vector3.down * 0.5f * Time.deltaTime);
                i--;
            }
            else if (isTrapped && trapreload)
            {
                trapreload = false;
                if(trapname == "arrow")
                {
                    ArrowShot.SendMessage("Shot");
                }
                if(trapname == "stone")
                {
                    StoneTrap.SendMessage("Roll");
                }
                if(trapname == "punch")
                {
                    PunchTrap.SendMessage("Punch");
                }
                if (trapname == "Manyarrow")
                {
                    ArrowShot.SetActive(true);
                }
            }
        }
        if (!isTrapped)
        {
            if (i < 50)
            {
                transform.Translate(Vector3.up * 0.5f * Time.deltaTime);
                i++;
            }
            else
            {
                trapreload = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTrapped = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrapped = false;
        }
    }
}
