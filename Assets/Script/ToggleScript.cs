using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject targetObject;
    public Button targetButton;     // �w�i�摜��؂�ւ���{�^��
    public Sprite[] images;
    private MonoBehaviour playerViewScript;
    private MonoBehaviour playerViewGyroScript;
    private bool isScriptEnabled = true;  // �������
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

    // �{�^�����������Ƃ��̏���
    public void ToggleScriptState()
    {
        isScriptEnabled = !isScriptEnabled;  // ��Ԃ𔽓]
        playerViewScript.enabled = isScriptEnabled;  // �X�N���v�g�̗L��/������؂�ւ�
        playerViewGyroScript.enabled = !isScriptEnabled;
        currentIndex = (currentIndex + 1) % images.Length;  // �z��͈͓̔��Ń��[�v
        targetButton.image.sprite = images[currentIndex];  // �V�����摜��ݒ�
    }
}
