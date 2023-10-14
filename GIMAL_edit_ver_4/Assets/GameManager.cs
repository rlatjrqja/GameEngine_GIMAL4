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
    //PlayerControl에서 호출
    public void Die(GameObject deadPlayer)
    {
        target = deadPlayer;
        Invoke("DelayToRespawn", 2f);
    }

    //사망 후 부활까지 잠시 대기
    void DelayToRespawn()
    {
        Destroy(target);
        if(isSaved)//세이브 후 사망
        {
            Instantiate(Player, SavePoint, Quaternion.identity);
            isSaved=false;
        }
        else//세이브 후 두번째 사망, 먹었던 세이브 전부 취소
        {
            Instantiate(Player, StartPoint, Quaternion.identity);
            foreach (var SavePointObj in SavePointArray)
            {
                SavePointObj.SetActive(true);
            }
        }
    }
}

