using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endingScript : MonoBehaviour
{
    public GameObject particle;
    GameObject[] particleArr;

    bool isGoal;
    GameObject goalPlayer;
    Transform playerTrans;

    Rigidbody rb;
    public GameManager GM;

    public GameObject endscreen;
    public TextMeshProUGUI record;
    public GameObject reBTN;

    float sec;
    float min;

    // Start is called before the first frame update
    void Start()
    {
        particleArr = new GameObject[50];
        isGoal = false;

        for (int i=0;i<50;i++)
        {
            //particleArr[i] = null;
            //particleArr[i] = Instantiate(particle);
            //particleArr[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoal)
        {
            playerTrans = goalPlayer.transform;
            goalPlayer.transform.Translate(Vector3.up * Time.deltaTime * 0.7f);
            goalPlayer.transform.Rotate(0, -0.03f, 0);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            goalPlayer = col.gameObject;
            isGoal = true;
            InvokeRepeating("MakeParticle2", 0, 0.2f);


            rb = goalPlayer.GetComponent<Rigidbody>();
            rb.useGravity = false;
            Destroy(goalPlayer.GetComponent<PlayerControl>());

            sec = GM.sec;
            min = GM.min;
            Invoke("ViewEnd", 4.5f);
        }

    }

    void MakeParticle()
    {
        foreach(var particle in particleArr)
        {
            if (particle == null) continue;
            if (particle.activeSelf == false)// && particle != null
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

    void MakeParticle2()
    {
        float radX = Random.Range(-2f, 2f);
        float spawnY = particle.transform.position.y + 4f;
        float radZ = Random.Range(-2f, 2f);

        GameObject a = Instantiate(particle);
        a.transform.position = playerTrans.position + new Vector3(radX, spawnY, radZ);

        //ViewEnd();
    }

    void ViewEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //float sec = GM.sec;
        

        endscreen.SetActive(true);

        Image img = endscreen.GetComponent<Image>();
        record.text = string.Format("{0:D2}:{1:D2}", (int)min, (int)sec);
        //while (img.color.a < 160) Debug.Log('1');
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage1");
    }
}
