using System.Collections;
using UnityEngine;

//"100 골드",
//       "100 골드+루비",
//        "200 골드+사파이어+마력석",
//       "최대 강화 완료"


public class UnitInventory : MonoBehaviour
{
    public int gold = 200;
    public string[] items = new string[] { "루비", "사파이어", "마력석" };
    //public int[] counts = { 1, 1, 1 }; 

    public bool HasItem(string name)
    {
        foreach (string item in items)
        {
            if (name.Equals(item))
            {
                return true;
            }
        }
        return false;
    }
}
