using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropJudgmentEgg : MonoBehaviour
{
    public Image targetImage;
    private ButtonTransition buttonTransition;

    void Start()
    {
        if (targetImage != null)
        {
            targetImage.gameObject.SetActive(false);  // イメージを非アクティブにする
        }
        else
        {
            Debug.LogError("ターゲットイメージが設定されていません！");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DropJudgment")
        {
            CollectionManager collectionManager = FindObjectOfType<CollectionManager>();
            Debug.Log("Get!!");
            targetImage.gameObject.SetActive(true);
            collectionManager.AddToCollection("Egg", "Cute stuffed egg!");
        }
        if (other.gameObject.name == "NextStage")
        {
            buttonTransition = GetComponent<ButtonTransition>();
            buttonTransition.SwitchToGameEgg();
        }
    }
}
