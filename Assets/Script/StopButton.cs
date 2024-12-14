using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    private int currentFunctionIndex = 0; // 現在の関数インデックス
    private List<System.Action> functions; // 関数のリスト
    public GameObject roulette;
    private Roulette rouletteScript;
    public GameObject updown;
    private Up_Down upDownScript;

    void Start()
    {
        rouletteScript = roulette.GetComponent<Roulette>();
        upDownScript = updown.GetComponent<Up_Down>();
        // 関数リストの初期化
        functions = new List<System.Action>
        {
            rouletteScript.StopLighting,
            upDownScript.StopLighting,
            rouletteScript.ResumeLighting
        };
    }

    public void OnButtonClick()
    {
        // 現在の関数を呼び出す
        if (functions != null && functions.Count > 0)
        {
            functions[currentFunctionIndex]?.Invoke();

            // 次の関数に進む（最後なら最初に戻る）
            currentFunctionIndex = (currentFunctionIndex + 1) % functions.Count;
        }
    }
}
