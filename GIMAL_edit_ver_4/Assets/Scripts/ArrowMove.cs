using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float Speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        // 5초 후에 현재 게임 오브젝트를 파괴
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 게임 오브젝트가 바라보는 방향 (forward 방향)
        Vector3 moveDirection = transform.forward;

        // 이동 벡터를 정규화하여 방향을 유지하고, 이동 속도를 곱합니다.
        Vector3 movement = moveDirection.normalized * Speed * Time.deltaTime;

        // 게임 오브젝트를 움직입니다.
        transform.Translate(movement);
    }
}
