using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchTrap : MonoBehaviour
{
    float posz;
    bool punch = false;
    // Start is called before the first frame update
    void Start()
    {
        posz = transform.position.z;
    }
    void Punch()
    {
        punch = true;
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
        // �浹�� ��ü�� Rigidbody�� ������
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        // �浹�� ��ü�� Rigidbody�� ���� ��쿡�� ���� ����
        if (otherRigidbody != null)
        {
            // �浹�� �������� ���� ���� a ��ü�� �о
            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            otherRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
