using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject camera1;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera1.transform.Rotate(0, turnSpeed, 0);
    }

    public void EasyGame()
    {
        SceneManager.LoadScene("EasyStage");
    }

    public void HardGame()
    {
        SceneManager.LoadScene("HardStage");
    }
}
