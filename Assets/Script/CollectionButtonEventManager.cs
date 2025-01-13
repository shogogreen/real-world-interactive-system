using UnityEngine;
using UnityEngine.UI;

public class CollectionButtonEventManager : MonoBehaviour
{
    public Button targetButton;  // �C�x���g��ݒ肷��{�^��
    private ButtonTransition buttonTransition;  // ButtonTransition �X�N���v�g�̎Q��

    private void Start()
    {
        // ButtonTransition �X�N���v�g�̎擾
        buttonTransition = FindObjectOfType<ButtonTransition>();

        if (buttonTransition == null)
        {
            Debug.LogError("ButtonTransition �X�N���v�g��������܂���I");
            return;
        }

        UpdateButtonEventBasedOnCollectionLength();  // �{�^���C�x���g���R���N�V�������X�g�ɉ����Đݒ�
    }

    /// <summary>
    /// �R���N�V�������X�g�̒����ɉ����ă{�^���C�x���g��ύX����
    /// </summary>
    public void UpdateButtonEventBasedOnCollectionLength()
    {
        int collectionLength = CollectionManager.Instance.GetCollectionList().Count;  // �R���N�V�������X�g�̒���

        targetButton.onClick.RemoveAllListeners();  // �Â����X�i�[���폜

        if (collectionLength == 0)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGame);  // �R���N�V������0�̂Ƃ�
        }
        else if (collectionLength == 1)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGameRabbit);  // �R���N�V������1�̂Ƃ�
        }
        else if (collectionLength == 2)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGamePumpkin);  // �R���N�V������2�̂Ƃ�
        }
        else if (collectionLength >= 3)
        {
            targetButton.onClick.AddListener(buttonTransition.SwitchToGameEgg);  // �R���N�V������3�ȏ�̂Ƃ�
        }

        Debug.Log($"�{�^���C�x���g���R���N�V�������X�g�̒��� {collectionLength} �Ɋ�Â��Đݒ肵�܂����B");
    }
}
