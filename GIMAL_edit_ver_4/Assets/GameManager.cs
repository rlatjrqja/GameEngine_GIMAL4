using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 StartPoint;
    Vector3 SavePoint;
    bool isSaved;
    //public SavePoint[] SavePointArray;
    List<GameObject> SavePointArray = new List<GameObject>();

    public GameObject Player;

    void Start()
    {
        isSaved=false;
        Instantiate(Player, SavePoint, Quaternion.identity);
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

