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
    public SoundManager SoundManager;
    //public GameObject SpawnPoint;

    float playTime = 0;

    AudioSource ad;
    [Header("audioClips")]
    public AudioClip dieSound;
    public AudioClip spawnSound;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //StartPoint = SpawnPoint.transform.position;
        ad = GetComponent<AudioSource>();

        isSaved =false;
        Instantiate(Player, StartPoint, Quaternion.identity);
    }

    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        ad.clip = clip;
        ad.Play();
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
        PlaySound(dieSound);
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
            //PlaySound(spawnSound);
            Instantiate(Player, StartPoint, Quaternion.identity);
            foreach (var SavePointObj in SavePointArray)
            {
                SavePointObj.SetActive(true);
            }
        }
    }
}

