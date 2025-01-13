using UnityEngine;
using UnityEngine.UI;

public class CollectionButtonEventManager : MonoBehaviour
{
    public Button targetButton; 
    private ButtonTransition buttonTransition; 

    private void Start()
    {
        // ButtonTransition スクリプトの取得
        buttonTransition = FindObjectOfType<ButtonTransition>();

        if (buttonTransition == null)
        {
            Debug.LogError("ButtonTransition スクリプトが見つかりません！");
            return;
        }

        UpdateButtonEventBasedOnCollectionLength();  
    }


    /// コレクションリストの長さに応じてボタンイベントを変更する
    public void UpdateButtonEventBasedOnCollectionLength()
    {
        int collectionLength = CollectionManager.Instance.GetCollectionList().Count;  

        targetButton.onClick.RemoveAllListeners();  

        if (collectionLength == 0)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGame);  
        }
        else if (collectionLength == 1)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGameRabbit);  
        }
        else if (collectionLength == 2)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGamePumpkin);  
        }
        else if (collectionLength >= 3)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGameEgg);  
        }

    }
}
