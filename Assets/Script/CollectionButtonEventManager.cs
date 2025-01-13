using UnityEngine;
using UnityEngine.UI;

public class CollectionButtonEventManager : MonoBehaviour
{
    public Button targetButton;  // イベントを設定するボタン
    private ButtonTransition buttonTransition;  // ButtonTransition スクリプトの参照

    private void Start()
    {
        // ButtonTransition スクリプトの取得
        buttonTransition = FindObjectOfType<ButtonTransition>();

        if (buttonTransition == null)
        {
            Debug.LogError("ButtonTransition スクリプトが見つかりません！");
            return;
        }

        UpdateButtonEventBasedOnCollectionLength();  // ボタンイベントをコレクションリストに応じて設定
    }

    /// <summary>
    /// コレクションリストの長さに応じてボタンイベントを変更する
    /// </summary>
    public void UpdateButtonEventBasedOnCollectionLength()
    {
        int collectionLength = CollectionManager.Instance.GetCollectionList().Count;  // コレクションリストの長さ

        targetButton.onClick.RemoveAllListeners();  // 古いリスナーを削除

        if (collectionLength == 0)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGame);  // コレクションが0のとき
        }
        else if (collectionLength == 1)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGameRabbit);  // コレクションが1のとき
        }
        else if (collectionLength == 2)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGamePumpkin);  // コレクションが2のとき
        }
        else if (collectionLength >= 3)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGameEgg);  // コレクションが3以上のとき
        }

        Debug.Log($"ボタンイベントをコレクションリストの長さ {collectionLength} に基づいて設定しました。");
    }
}
