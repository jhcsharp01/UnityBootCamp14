using UnityEngine;
using TMPro;

public class TextMeshProSample : MonoBehaviour
{
    //TMP�� ����ϴ� UI ������Ʈ
    public TextMeshProUGUI textUI;

    private void Start()
    {
        //��ġ �ؽ�Ʈ(HTML �±� ���� ����) ����
        textUI.text = "<size=150%>�ȳ��ϼ���</size> <s>�� �� ���</s>";
    }

    public void SetText(bool warning)
    {
        if(warning)
        {
            textUI.text = "<color=red><b>WARNING!!!</b></color>";
        }
        else
        {
            textUI.text = "<color=green>NORMAL</color>";
        }
    }

}
