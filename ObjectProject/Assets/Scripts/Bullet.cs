using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

//�Ѿ˿� ���� ����, �Ѿ� �ݳ�, �Ѿ� �̵�
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f; //�Ѿ� �̵� �ӵ�
    public float life_time = 2.0f; //�Ѿ� �ݳ� �ð�
    public GameObject effect_prefab; //����Ʈ ������

    private BulletPool pool; //Ǯ
    private Coroutine life_coroutine;

    //Ǯ ����(Ǯ���� �ش� �� ȣ��)
    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }


    //Ȱ��ȭ �ܰ�
    private void OnEnable()
    {
        life_coroutine = StartCoroutine(BulletReturn());
    }

    //��Ȱ��ȭ �ܰ�
    private void OnDisable()
    {
        //if�� �ۼ� �� ��ɹ��� 1���� ��� {} ���� �����մϴ�.
        if (life_coroutine != null)
            StopCoroutine(life_coroutine);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    IEnumerator BulletReturn()
    {
        yield return new WaitForSeconds(life_time);
        ReturnPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ����� Enemy �±׸� ������ �ִ� ������Ʈ�� ���
        //�������� �����ϴ�.�� ���� ������ ���� �ڵ� �ۼ�

        //����Ʈ ����(��ƼŬ)
        if(effect_prefab != null)
            Instantiate(effect_prefab, transform.position, Quaternion.identity);


        ReturnPool();
    }

    //�޼ҵ��� ����� 1���� ���, => �� ����� �� �ֽ��ϴ�.
    void ReturnPool() => pool.Return(gameObject);

}
