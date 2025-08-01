using UnityEngine;
//�ﰢ �Լ�
//����Ƽ���� �������ִ� �ﰢ�Լ��� �ַ� ȸ��, ī�޶� ����, � , �����ӿ� ���� ǥ������ ���˴ϴ�.

//Ư¡) ������ �������� ����մϴ�. 1 ���� = �� 57��


public class Tfunction : MonoBehaviour
{
    //���
    //Sin(Radian) : �־��� ������ Y ��ǥ (���� ���� ��ġ)
    //Cos(Radian) : �־��� ������ X ��ǥ (���� ���� ��ġ)
    //Tan(Radian) : �־��� ������ ���� ( Y / X )

    //���� ȸ��
    public void CircleRotate()
    {
        float angle = Time.time * 90.0f;
        float radian = angle * Mathf.Deg2Rad; //���� �ش� ���� �����ָ� �������� ��ȯ�˴ϴ�.

        var x = Mathf.Cos(radian) * 5.0f;
        var y = Mathf.Sin(radian) * 5.0f;

        transform.position = new Vector3(x, y, 0);
    }

    public void ButterFly()
    {
        float t = Time.time * 2;
        float x = Mathf.Sin(t) * 2;
        float y = Mathf.Sin(t * 2f) * 2 * 2;

        transform.position = new Vector3(x, y, 0);
    }


    //Time.time : �������� ������ ���������� �ð�
    //Time.deltaTime : �������� �����ϰ� ������ �ð�

    public void Wave()
    {
        var offset = Mathf.Sin(Time.time * 2.0f) * 10f;
        transform.position = pos + Vector3.left * offset;
    }

    Vector3 pos; //��ǥ(��ġ)

    private void Start()
    {
        pos = transform.position; //������ �� ������Ʈ�� ��ġ ����
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� Ŭ�� ���� ���� CircleRotate ȣ��
        if (Input.GetMouseButton(0))
        {
            CircleRotate();
        }
        if (Input.GetMouseButton(1))
        {
            Wave();
        }
        if(Input.GetMouseButton(2))
        {
            ButterFly();
        }
    }
}
