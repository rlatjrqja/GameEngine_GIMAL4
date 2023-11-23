using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class endingScript : MonoBehaviour
{
    public GameObject particle;
    GameObject[] particleArr = new GameObject[50];

    bool isGoal;
    GameObject goalPlayer;
    Transform playerTrans;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;

        for (int i=0;i<50;i++)
        {
            particleArr[i] = Instantiate(particle);
            particleArr[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoal)
        {
            playerTrans = goalPlayer.transform;
            goalPlayer.transform.Translate(Vector3.up * Time.deltaTime * 0.7f);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            goalPlayer = col.gameObject;
            isGoal = true;
            InvokeRepeating("MakeParticle", 0, 0.1f);


            rb = goalPlayer.GetComponent<Rigidbody>();
            rb.useGravity = false;
            Destroy(goalPlayer.GetComponent<PlayerControl>());
        }

    }

    void MakeParticle()
    {
        foreach(var particle in particleArr)
        {

            if (particle.activeSelf == false && particle != null)
            {
                float radX = Random.Range(-2f, 2f);
                float spawnY = particle.transform.position.y+4f;
                float radZ = Random.Range(-2f, 2f);

                particle.transform.position = playerTrans.position + new Vector3(radX, spawnY, radZ);
                particle.SetActive(true);
                break;
            }
        }
    }
}
