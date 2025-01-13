using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropJudgmentRabbit : MonoBehaviour
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
            collectionManager.AddToCollection("Rabbit", "Cute stuffed rabbit!");
        }
        if (other.gameObject.name == "NextStage")
        {
            buttonTransition = GetComponent<ButtonTransition>();
            buttonTransition.SwitchToGamePumpkin();
        }
    }
}
