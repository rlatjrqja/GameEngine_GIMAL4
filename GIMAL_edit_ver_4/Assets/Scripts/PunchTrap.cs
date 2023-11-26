using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchTrap : MonoBehaviour
{
    float posz;
    bool punch = false;
    public Vector3 initT;

    // Start is called before the first frame update
    void Start()
    {
        initT = transform.position;

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
            transform.Translate(Vector3.up * 0.1f);
        }

    }
    public float pushForce = 100f;

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

    void ReLoad()
    {
        punch = false;
        transform.position = initT;

    }
}
