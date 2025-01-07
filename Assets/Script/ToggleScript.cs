using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject targetObject;
    public Button targetButton;     // 背景画像を切り替えるボタン
    public Sprite[] images;
    private MonoBehaviour playerViewScript;
    private MonoBehaviour playerViewGyroScript;
    private bool isScriptEnabled = true;  // 初期状態
    private int currentIndex = 0;

    void Start()
    {
        playerViewScript = targetObject.GetComponent<Player>();
        playerViewGyroScript = targetObject.GetComponent<Player_gyro>();
        if (images.Length > 0)
        {
            targetButton.image.sprite = images[currentIndex];
        }
    }

    // ボタンを押したときの処理
    public void ToggleScriptState()
    {
        isScriptEnabled = !isScriptEnabled;  // 状態を反転
        playerViewScript.enabled = isScriptEnabled;  // スクリプトの有効/無効を切り替え
        playerViewGyroScript.enabled = !isScriptEnabled;
        currentIndex = (currentIndex + 1) % images.Length;  // 配列の範囲内でループ
        targetButton.image.sprite = images[currentIndex];  // 新しい画像を設定
    }
}
