using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    private int currentFunctionIndex = 0; // ���݂̊֐��C���f�b�N�X
    private List<System.Action> functions; // �֐��̃��X�g
    public GameObject roulette;
    private Roulette rouletteScript;
    public GameObject updown;
    private Up_Down upDownScript;

    void Start()
    {
        rouletteScript = roulette.GetComponent<Roulette>();
        upDownScript = updown.GetComponent<Up_Down>();
        // �֐����X�g�̏�����
        functions = new List<System.Action>
        {
            rouletteScript.StopLighting,
            upDownScript.StopLighting,
            rouletteScript.ResumeLighting
        };
    }

    public void OnButtonClick()
    {
        // ���݂̊֐����Ăяo��
        if (functions != null && functions.Count > 0)
        {
            functions[currentFunctionIndex]?.Invoke();

            // ���̊֐��ɐi�ށi�Ō�Ȃ�ŏ��ɖ߂�j
            currentFunctionIndex = (currentFunctionIndex + 1) % functions.Count;
        }
    }
}
