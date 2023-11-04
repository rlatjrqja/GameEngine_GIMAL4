using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public GameObject Arrow; // �ν��Ͻ�ȭ�� ������

    private void Start()
    {
        
    }

    private void Shot()
    {
        // B ������Ʈ�� ��ġ�� ��������, x ȸ���� -90, y�� z ȸ���� ���� ������ ����
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // �������� �ν��Ͻ�ȭ�ϰ� ��ġ�� ȸ���� ����
        GameObject newPrefab = Instantiate(Arrow, spawnPosition, spawnRotation);

    }
}
