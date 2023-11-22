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
    Animator anim;


    public AudioClip jumpSound;
    public AudioClip landingSound;

    void Start()
    {
        transform.position = new Vector3(-204, -3, 133);

        Prigidbody = GetComponent<Rigidbody>();
        GM = FindObjectOfType<GameManager>();
        anim = gameObject.GetComponentInChildren<Animator>();
        //GM = GetComponent<GameManager>();
    }

    void Update()
    {
        moveVert = Input.GetAxis("Vertical") * moveSpeed;
        moveHor = Input.GetAxis("Horizontal") * moveSpeed;

        transform.Translate(moveHor, 0, moveVert);

        //공중에 있는게 아니라면 조작가능
        if (!isJumping )
        {

            //공중에 있는게 아니라면 점프 가능(미완)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GM.PlaySound(jumpSound);
                Prigidbody.AddForce(Vector3.up * 300f);
                isJumping=true;
                anim.SetBool("isJump", true);
            }

            //전진 중에는 카메라 방향으로 이동
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))//&& Input.anyKey == false
            {
                transform.eulerAngles = new Vector3(0,CameraControl.MouseRotationY , 0);
                anim.SetInteger("AnimationPar", 1);
            }
            else anim.SetInteger("AnimationPar", 0);
        }

        if(transform.position.y < -10)
        {
            GM.Die(this.gameObject);
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            GM.Die(this.gameObject);
            Destroy(this);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        isJumping = false;
        GM.PlaySound(landingSound);
        anim.SetBool("isJump", false);
    }
}
