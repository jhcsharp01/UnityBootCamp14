using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//��� �ٿ��� ���� ���
//1. Template : ��� �ٿ��� �������� ��, ���̴� ����Ʈ �׸�
//2. Caption / Item Text : ���� ���õ� �׸� / ����Ʈ �׸� ������ ���� �ؽ�Ʈ
//TMP�� ���� ���, �ѱ� ����� ���� Label�� Item Label���� ��� ���� ��Ʈ��
//������ �ּž� ����� �� �ֽ��ϴ�.

//3. Options : ��� �ٿ ǥ�õ� �׸� ���� ����Ʈ
//   �ν����͸� ���� ���� ����� �����մϴ�.
//   ����ϸ� �ٷ� ����Ʈ�� ����˴ϴ�.

//4. On Value Changed : ����ڰ� �׸��� �������� �� ȣ��Ǵ� �̺�Ʈ
//   �ν����͸� ���� ���� ����� �� �ֽ��ϴ�.
//   ��� �ٿ� ���� ���� ���� �߻� �� ȣ��˴ϴ�.

public class DropdownSample : MonoBehaviour
{
    public TMP_Dropdown dropdown;

   

    //Options�� ����� ���� ���ڿ�

    //����Ʈ�� ���� �ְ� �����ϴ� ���
    //����Ʈ<T> ����Ʈ�� = new ����Ʈ��<T> {���, ���2 , ���3 };
    private List<string> options = new List<string> { "A", "B", "C" };

    private void Start()
    {
        dropdown.ClearOptions(); //��Ӵٿ��� Option ����� �����ϴ� �ڵ�
        dropdown.AddOptions(options); //�غ�� ��ܿ� ���� �߰��ϴ� ���
        dropdown.onValueChanged.AddListener(onDropdownValueChanged);
        //�̺�Ʈ ��� �� �䱸�ϴ� �Լ��� ���´�� �ۼ��� ��ٸ�
        //�Լ��� �̸��� �־� ����� �� �ְ� �˴ϴ�.
    }

    //c# System.Int32 --> int
    //   System.Int64 --> long
    //   System.UInt32 --> unsigned int(��ȣ�� ���� 32��Ʈ ����) (0 ~ 4,294,967,295)

   

    void onDropdownValueChanged(int idx)
    {
  
        Debug.Log("���� ���õ� �޴���  " + dropdown.options[idx].text);
        //�ɼ� ����Ʈ�� idx��° ���� ���� �ؽ�Ʈ
    }
}
