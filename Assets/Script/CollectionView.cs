using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionView : MonoBehaviour
{
    public List<Image> imageSlots;  // �L�����o�X���̃C���[�W�I�u�W�F�N�g�̃��X�g

    // Start is called before the first frame update
    void Start()
    {
        CollectionManager collectionManager = FindObjectOfType<CollectionManager>();
        UpdateCollectionImages();
    }

    /// <summary>
    /// �R���N�V�������X�g�̒����ɉ����ĉ摜��\������
    /// </summary>
    public void UpdateCollectionImages()
    {
        List<CollectionItem> collectionList = CollectionManager.Instance.GetCollectionList();  // �R���N�V�������X�g���擾

        // ���ׂẴC���[�W���A�N�e�B�u�ɂ���
        foreach (Image img in imageSlots)
        {
            img.gameObject.SetActive(false);
        }

        // �R���N�V�����̒����������C���[�W��\��
        for (int i = 0; i < collectionList.Count && i < imageSlots.Count; i++)
        {
            imageSlots[i].gameObject.SetActive(true);
            //imageSlots[i].sprite = GetItemSprite(collectionList[i].itemName);  // �A�C�e�����ɉ������X�v���C�g��ݒ� (�C��)
        }
    }
}
