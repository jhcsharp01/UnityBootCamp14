using UnityEngine;
//��ư�� OnClick�� ����� ���

public class SkeletonController : MonoBehaviour
{
    public GameObject skeleton;

    //public void �޼ҵ��()
    //{
    // �� �޼ҵ带 ������ ��� ������ ��ɹ��� �ۼ��ϴ� ��ġ
    //}
    public void OnLButtonEnter()
    {
        skeleton.transform.Translate(-1, 0 ,0);
    }
    public void OnRButtonEnter()
    {
        skeleton.transform.Translate(1, 0, 0);
    }
}
