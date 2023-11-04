using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float MousePositionX = 0;
    float MousePositionY = 0;
    public float MouseSesitivity = 500f;//민감도
    public float MouseRotationX = 0;
    public float MouseRotationY = 0;

    public GameObject mainCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MousePositionX = Input.GetAxis("Mouse X");
        MousePositionY = Input.GetAxis("Mouse Y");

        MouseRotationY += MousePositionX * MouseSesitivity * Time.deltaTime;//좌우 회전(Y축 회전)
        MouseRotationX += MousePositionY * MouseSesitivity * Time.deltaTime;//상하 회전(X축 회전)

        if (MouseRotationX > 5f)//아래쪽 보기 제한
        {
            MouseRotationX = 5f;
        }
        if (MouseRotationX < -75f)//위쪽 보기 제한
        {
            MouseRotationX = -75f;
        }

        transform.eulerAngles = new Vector3(-MouseRotationX, MouseRotationY, 0);
    }
}
