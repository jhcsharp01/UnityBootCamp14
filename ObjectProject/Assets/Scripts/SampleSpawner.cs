using UnityEngine;

public class SampleSpawner : MonoBehaviour
{
    //�ش� ������Ʈ�� ���� �� ������Ʈ�� �����ϰ� , ������Ʈ�� �ο��ϱ�
    void Start()
    {
        GameObject sample = GameObject.Find("Sample");

        //������Ʈ Ž�� ����� ���� ���
        if (sample == null)
        {
            GameObject go = new GameObject("Sample");
            go.AddComponent<Sample>();
        }
        else
        {
            Debug.Log("�̹� �����մϴ�.");
        }
    }
}
