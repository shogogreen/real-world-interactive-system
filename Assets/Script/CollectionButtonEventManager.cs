using UnityEngine;
using UnityEngine.UI;

public class CollectionButtonEventManager : MonoBehaviour
{
    public Button targetButton; 
    private ButtonTransition buttonTransition; 

    private void Start()
    {
        // ButtonTransition �X�N���v�g�̎擾
        buttonTransition = FindObjectOfType<ButtonTransition>();

        if (buttonTransition == null)
        {
            Debug.LogError("ButtonTransition �X�N���v�g��������܂���I");
            return;
        }

        UpdateButtonEventBasedOnCollectionLength();  
    }


    /// �R���N�V�������X�g�̒����ɉ����ă{�^���C�x���g��ύX����
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
