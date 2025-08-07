using System;
using UnityEngine;
using UnityEngine.UI;



public class UpgradeUI : MonoBehaviour
{
    public Button button01;
    public Text message;
    public Text icon_text;

    public UnitStat unitStat;
    public UnitInventory inventory;

    //�迭�� �� ���� ���� ä�� �����˴ϴ�.
    //�ڷ���[] �迭�� = new �ڷ���[] {
    //��, ��2, ��3
    //
    //};
    
    private  string[] materials = new string[]
    {
        "100 ���",
        "100 ���+���",
        "200 ���+�����̾�+���¼�",
        "�ִ� ��ȭ �Ϸ�"
    };
    //max_level�� ����� ��� �迭�� ���� -1�� ���� ������ �˴ϴ�.

    private int upgrade = 0; 
    private int max_level => materials.Length - 1;
    //�迭���� �ε������ ������ �����մϴ�.
    //ex) materials�� �ϳ��� �����̰�, �ű⼭ 2��° �����ʹ� materials[1]�Դϴ�.
    //   (ī��Ʈ�� 0���� ��)

    private void Start()
    {
        button01.onClick.AddListener(OnUpgradeBtnClick);
        //AddListener�� ����Ƽ�� UI�� �̺�Ʈ�� ����� �������ִ� �ڵ�
        //������ �� �ִ� ���� ���°� �������վ �� ���´�� ����������մϴ�.
        //�ٸ� ���·� ���� ���(�Ű������� �ٸ� ���)��� delegate�� Ȱ���մϴ�.
        //Ư¡) �� ����� ���� �̺�Ʈ�� ����� �����Ѵٸ�
        //����Ƽ �ν����Ϳ��� ����� �� Ȯ�� �� �� �����ϴ�.

        //���� : ���� ������� �ʾƼ� �߸� ���� Ȯ���� �������ϴ�.
        UpdateUI();
        //���� �� UI�� ���� ������ ����
    }

    //��ư Ŭ�� �� ȣ���� �޼ҵ� ����
    private void OnUpgradeBtnClick()
    {
        if(upgrade < max_level)
        {
            if(Upgrade(upgrade))
            {
                upgrade++;
                unitStat.atk += 10;
                unitStat.hp += 5;
                UpdateUI();
            }
        }
    }

    private bool Upgrade(int upgrade)
    {
        //���׷��̵� ��ġ��ŭ�� �ε����� �޾� materials�� �����Ͽ�
        //�ش� ��Ḧ �� ������ ���� ��� �Ҹ��ϰ� ���׷��̵�
        string[] requiredMaterials = materials[upgrade].Split('+');
        int gold_value = int.Parse(requiredMaterials[0].Split(" ")[0]);

        if (inventory.gold < gold_value)
        {
            Debug.Log("���׷��̵� �ܾ��� �����մϴ�.");
            return false;
        }
        else
        {
            inventory.gold -= gold_value;
            //���� �������� �κ��丮�� �����ϴ� �������̶��
            //ī��Ʈ�� �����ϰ� ��ȭ�ϱ�
        }
            return true;
    }

    private void UpdateUI()
    {
        icon_text.text = $"������ + {upgrade}";
        message.text = materials[upgrade];
    }
}
