using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public GameObject Arrow; // 인스턴스화할 프리팹

    private void Start()
    {
        
    }

    private void Shot()
    {
        // B 오브젝트의 위치를 가져오고, x 회전은 -90, y와 z 회전은 현재 값으로 설정
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // 프리팹을 인스턴스화하고 위치와 회전을 설정
        GameObject newPrefab = Instantiate(Arrow, spawnPosition, spawnRotation);

    }
}
