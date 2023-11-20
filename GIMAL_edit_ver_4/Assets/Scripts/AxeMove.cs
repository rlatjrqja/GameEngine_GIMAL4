using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeMove : MonoBehaviour
{
    public float amplitude = 90f;  // 진폭
    public float period = 2f;      // 주기
    Vector3 pos;
    private float timeElapsed = 0f;

    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // 진자 운동을 위한 각도 계산
        float angle = amplitude * Mathf.Sin(2 * Mathf.PI * timeElapsed / period);

        // 회전 축을 정의하고 물체를 회전
        transform.rotation = Quaternion.Euler(angle, 0f, 90f);

        // 높이를 조절하여 출발과 멈춤 높이를 같게 만듭니다.
        float heightOffset = Mathf.Sin(angle * Mathf.Deg2Rad) * amplitude;
        transform.position = pos;
    }
}
