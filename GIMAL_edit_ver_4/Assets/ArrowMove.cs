using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float Speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        // 5�� �Ŀ� ���� ���� ������Ʈ�� �ı�
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ������Ʈ�� �ٶ󺸴� ���� (forward ����)
        Vector3 moveDirection = transform.forward;

        // �̵� ���͸� ����ȭ�Ͽ� ������ �����ϰ�, �̵� �ӵ��� ���մϴ�.
        Vector3 movement = moveDirection.normalized * Speed * Time.deltaTime;

        // ���� ������Ʈ�� �����Դϴ�.
        transform.Translate(movement);
    }
}
