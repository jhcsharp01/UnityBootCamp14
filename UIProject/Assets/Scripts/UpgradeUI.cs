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

    //배열이 그 값을 가진 채로 생성됩니다.
    //자료형[] 배열명 = new 자료형[] {
    //값, 값2, 값3
    //
    //};
    
    private  string[] materials = new string[]
    {
        "100 골드",
        "100 골드+루비",
        "200 골드+사파이어+마력석",
        "최대 강화 완료"
    };
    //max_level을 사용할 경우 배열의 길이 -1의 값을 가지게 됩니다.

    private int upgrade = 0; 
    private int max_level => materials.Length - 1;
    //배열에는 인덱스라는 개념이 존재합니다.
    //ex) materials가 하나의 묶음이고, 거기서 2번째 데이터는 materials[1]입니다.
    //   (카운트를 0부터 셈)

    private void Start()
    {
        button01.onClick.AddListener(OnUpgradeBtnClick);
        //AddListener는 유니티의 UI의 이벤트에 기능을 연결해주는 코드
        //전달할 수 있는 값의 형태가 정해져잇어서 그 형태대로 설계해줘야합니다.
        //다른 형태로 쓰는 경우(매개변수가 다른 경우)라면 delegate를 활용합니다.
        //특징) 이 기능을 통해 이벤트에 기능을 전달한다면
        //유니티 인스펙터에서 연결된 걸 확인 할 수 없습니다.

        //장점 : 직접 등록하지 않아서 잘못 넣을 확률이 낮아집니다.
        UpdateUI();
        //시작 시 UI에 대한 렌더링 설정
    }

    //버튼 클릭 시 호출할 메소드 설계
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
        //업그레이드 수치만큼을 인덱스로 받아 materials에 접근하여
        //해당 재료를 다 가지고 있을 경우 소모하고 업그레이드
        string[] requiredMaterials = materials[upgrade].Split('+');
        int gold_value = int.Parse(requiredMaterials[0].Split(" ")[0]);

        if (inventory.gold < gold_value)
        {
            Debug.Log("업그레이드 잔액이 부족합니다.");
            return false;
        }
        else
        {
            inventory.gold -= gold_value;
            //남은 아이템이 인벤토리에 존재하는 아이템이라면
            //카운트를 감소하고 강화하기
        }
            return true;
    }

    private void UpdateUI()
    {
        icon_text.text = $"마법사 + {upgrade}";
        message.text = materials[upgrade];
    }
}
