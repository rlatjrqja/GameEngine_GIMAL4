using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchTrap : MonoBehaviour
{
    float posz;
    bool punch = false;
    Transform initT;

    // Start is called before the first frame update
    void Start()
    {
        posz = transform.position.z;

        initT = transform;

        Debug.Log(initT.position);
    }
    void Punch()
    {
        punch = true;
        Invoke("ReLoad", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(punch)
        {
            if(transform.position.z < posz + 3)
            {
                transform.Translate(Vector3.up * 0.1f);
            }
        }

    }
    public float pushForce = 10000000f;

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 Rigidbody를 가져옴
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        // 충돌한 물체에 Rigidbody가 있을 경우에만 힘을 적용
        if (otherRigidbody != null)
        {
            // 충돌한 방향으로 힘을 가해 a 물체를 밀어냄
            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            otherRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }

    void ReLoad()
    {
        punch = false;
        transform.position = initT.position;
        transform.rotation = initT.rotation;

        Debug.Log(initT.position);
    }
}
