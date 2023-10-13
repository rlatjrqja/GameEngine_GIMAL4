using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 StartPoint;
    Vector3 SavePoint;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        StartPoint = Player.transform.position;
        SavePoint = StartPoint;
        Instantiate(Player, SavePoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSavePoint(Vector3 TakenPosition)
    {
        SavePoint = TakenPosition;
    }

    GameObject target;
    public void Die(GameObject deadPlayer)
    {
        target = deadPlayer;
        Invoke("DelayToRespawn", 2f);
    }

    void DelayToRespawn()
    {
        Destroy(target);
        Instantiate(Player, SavePoint, Quaternion.identity);
    }
}
