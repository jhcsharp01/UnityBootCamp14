using UnityEngine;

public class Sample : MonoBehaviour
{
    string items = "빨간 포션,파란 포션,주황 포션";

    string[] item_table;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        item_table = items.Split(',');
        //문장 전체에서 ,를 기준으로 문장을 나누는 기능 

        foreach (string item in item_table)
        {
            Debug.Log(item);
        }
    }
}
