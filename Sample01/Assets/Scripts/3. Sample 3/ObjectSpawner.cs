using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    float spawnTime = 3.0f; //2�� �� ����
    float time = 0.0f; //�ð� üũ�� ����

    //�ð��� ���� ����ؼ�, ������ �����ϰ�
    //�� ������ ���� Ÿ�Ӻ��� Ŀ���� ������Ʈ ����
    //������ 0���� �ʱ�ȭ


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
        GameObject go = Instantiate(objectPrefab);
          time = 0.0f;

            int rand = Random.Range(-3, 4);
            //-3���� 3 ������ ���� �������� ������ �˴ϴ�.

          go.transform.position = new Vector3(rand,5,0);
        }
    }
}
