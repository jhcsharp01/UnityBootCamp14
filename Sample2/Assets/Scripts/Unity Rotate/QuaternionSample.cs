using UnityEngine;

//���ʹϿ� ��� ����
//Quaternion.identity = ȸ�� ����
//Quaternion.Euler(x,y,z) = ���Ϸ� �� -> ���ʹϿ� ��ȯ
//Quaternion.AngleAxis(angle, axis) Ư�� �� ������ ȸ��
//Quaternion.LookRotation(forward,upward[default : Vector3.up]); �ش� ���� ������ �ٶ󺸴� ȸ�� ���¿� ���� return

//forward : ȸ�� ��ų ����(Vector3)
//upward : ������ �ٶ󺸰� ���� ���� �� �κ��� ����(�⺻ ���� up���� �����Ǿ��־ Ư���� ���ƴϸ� �ǵ帱 ���� ����)

//ȸ�� �� ����
//transform.rotation = Quaternion.Euler(x,y,z); //���� ������Ʈ�� ȸ�� ���� �����մϴ�.

//ȸ���� ���� ����
//Quaternion.Slerp(from, to, t)   : ���� ���� ����
//Quaternion.Lerp(from, to , t)   : ���� ����
//Quaternion.RotateTowards(from, to , maxDegree) : ���� ������ŭ ���������� ȸ���� ó���մϴ�./


//transform.LookAt() vs Quaternion.LookRotation()
//�Ѵ� Ư�� ������ �����ϴ� �ڵ�


//1. LookAt(target) : �߰� ȸ�� �����̳� ��� ��ư�, �������� ���� �������� transform.rotation�� �ڵ�����
//�������ִ� ��� ( ���ο��� Quaternion.LookRotation()�� ����ϴ� ���)
// --> �׳� �� �ٶ������ ���ڴ�.

//2. LookRotation(direction) �� ���� ȸ�� ���� ����ϰ� �������� ������ ���� �ʽ��ϴ�.
// --> ����� �������� �߰����� �۾����� ����� ó���ϸ� ���� ������?

public class QuaternionSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
