using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI timerText;

    AudioSource ad;
    [Header("audioClips")]
    public AudioClip dieSound;
    public AudioClip spawnSound;

    public float sec = 0;
    public float min = 0;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartPoint = new Vector3(0,1,0);
        ad = GetComponent<AudioSource>();

        isSaved =false;
        Instantiate(Player, StartPoint, Quaternion.identity);
    }

    void Update()
    {
        playTime += Time.deltaTime;
        sec = playTime % 60;
        min = playTime / 60;
        timerText.text = string.Format("{0:D2}:{1:D2}", (int)min, (int)sec);
        //if(sec>=60) sec
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
    //PlayerControl에서 호출
    public void Die(GameObject deadPlayer)
    {
        target = deadPlayer;
        PlaySound(dieSound);
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
            //PlaySound(spawnSound);
            Instantiate(Player, StartPoint, Quaternion.identity);
            foreach (var SavePointObj in SavePointArray)
            {
                SavePointObj.SetActive(true);
            }
        }
    }
}

