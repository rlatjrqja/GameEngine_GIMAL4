using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 SavePoint;
    Vector3 StartPoint;
    bool isSaved;
    List<GameObject> SavePointArray = new List<GameObject>();

    public GameObject Player;
    //public GameObject SpawnPoint;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //StartPoint = SpawnPoint.transform.position;
        isSaved =false;
        Instantiate(Player, StartPoint, Quaternion.identity);
    }

    void Update()
    {
        
    }

    public void SetSavePoint(GameObject obj)
    {
        SavePoint = obj.transform.position;
        SavePointArray.Add(obj);
        isSaved=true;
    }

    GameObject target;
    //PlayerControl���� ȣ��
    public void Die(GameObject deadPlayer)
    {
        target = deadPlayer;
        Invoke("DelayToRespawn", 2f);
    }

    //��� �� ��Ȱ���� ��� ���
    void DelayToRespawn()
    {
        Destroy(target);
        if(isSaved)//���̺� �� ���
        {
            Instantiate(Player, SavePoint, Quaternion.identity);
            isSaved=false;
        }
        else//���̺� �� �ι�° ���, �Ծ��� ���̺� ���� ���
        {
            Instantiate(Player, StartPoint, Quaternion.identity);
            foreach (var SavePointObj in SavePointArray)
            {
                SavePointObj.SetActive(true);
            }
        }
    }
}

