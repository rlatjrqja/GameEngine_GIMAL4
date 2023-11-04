using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float MousePositionX = 0;
    float MousePositionY = 0;
    public float MouseSesitivity = 500f;//�ΰ���
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

        MouseRotationY += MousePositionX * MouseSesitivity * Time.deltaTime;//�¿� ȸ��(Y�� ȸ��)
        MouseRotationX += MousePositionY * MouseSesitivity * Time.deltaTime;//���� ȸ��(X�� ȸ��)

        if (MouseRotationX > 5f)//�Ʒ��� ���� ����
        {
            MouseRotationX = 5f;
        }
        if (MouseRotationX < -75f)//���� ���� ����
        {
            MouseRotationX = -75f;
        }

        transform.eulerAngles = new Vector3(-MouseRotationX, MouseRotationY, 0);
    }
}
