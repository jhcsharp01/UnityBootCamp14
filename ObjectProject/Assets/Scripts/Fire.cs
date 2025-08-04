using UnityEngine;

//�� �ڵ�� �Ѿ˿� ���� �߻�(����) ��ɸ� ����մϴ�.
public class Fire : MonoBehaviour
{
    //�Ѿ� �߻縦 ���� Ǯ
    public BulletPool pool;

    //�Ѿ� �߻� ����
    public Transform pos;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            var bullet = pool.GetBullet();
            bullet.transform.position = pos.position;
            bullet.transform.rotation = pos.rotation;
        }
    }
}
