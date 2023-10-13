using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody Prigidbody;
    float moveVert =0;
    float moveHor =0;
    bool isJumping;

    public CameraControl CameraControl;
    GameManager GM;

    void Start()
    {
        Prigidbody = GetComponent<Rigidbody>();
        GM = FindObjectOfType<GameManager>();
        //GM = GetComponent<GameManager>();
    }

    void Update()
    {
        moveVert = Input.GetAxis("Vertical") * moveSpeed;
        moveHor = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(moveHor, 0, moveVert);


        //���߿� �ִ°� �ƴ϶�� ���۰���
        if (!isJumping )
        {

            //���߿� �ִ°� �ƴ϶�� ���� ����(�̿�)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Prigidbody.AddForce(Vector3.up * 1000f);
                isJumping=true;
            }

            //���� �߿��� ī�޶� �������� �̵�
            if (Input.GetKey(KeyCode.W))//&& Input.anyKey == false
            {
                transform.eulerAngles = new Vector3(0,CameraControl.MouseRotationY , 0);
            }
        }

        if(transform.position.y < -10)
        {
            GM.Die(this.gameObject);
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
