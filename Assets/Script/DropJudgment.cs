using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropJudgment : MonoBehaviour
{
    public Image targetImage;
    private ButtonTransition buttonTransition;

    void Start()
    {
        if (targetImage != null)
        {
            targetImage.gameObject.SetActive(false);  // �C���[�W���A�N�e�B�u�ɂ���
        }
        else
        {
            Debug.LogError("�^�[�Q�b�g�C���[�W���ݒ肳��Ă��܂���I");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DropJudgment")
        {
            CollectionManager collectionManager = FindObjectOfType<CollectionManager>();
            Debug.Log("Get!!");
            targetImage.gameObject.SetActive(true);
            collectionManager.AddToCollection("Bear", "Cute stuffed teddy bear!");
        }
        if (other.gameObject.name == "NextStage")
        {
            buttonTransition = GetComponent<ButtonTransition>();
            buttonTransition.SwitchToGameRabbit();
        }
    }
}
