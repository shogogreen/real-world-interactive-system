using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    public GameObject blue;
    public GameObject lightblue;
    public GameObject yellow;
    public GameObject pink;
    public GameObject red;
    public GameObject green;
    public GameObject updown;
    private Up_Down upDownScript;

    public GameObject[] separateds; // �摜�����ԂɊi�[����z��
    public float lightDuration = 0.05f; // �_�����鎞��
    public Color activeColor = Color.yellow; // �_�����̐F
    private Color inactiveColor; // �������̐F

    private Coroutine lightingCoroutine; // ���݂̃R���[�`����ۑ�
    private bool isStopped = false; // ��~��Ԃ��Ǘ�

    // Start is called before the first frame update
    void Start()
    {
        upDownScript = updown.GetComponent<Up_Down>();
        separateds = new GameObject[]
        {
            blue, lightblue, yellow, pink, red, green
        };
        lightingCoroutine = StartCoroutine(LightUpImages());
        inactiveColor = green.GetComponent<Renderer>().material.color;
    }

    IEnumerator LightUpImages()
    {
        int index = 0;
        while (!isStopped)
        {
            // ���݂̉摜��_��
            separateds[index].GetComponent<Renderer>().material.color = activeColor;

            yield return new WaitForSeconds(lightDuration);

            // �_����Ԃ����Z�b�g�i��~����Ă��Ȃ��ꍇ�̂݁j
            if (!isStopped)
            {
                separateds[index].GetComponent<Renderer>().material.color = inactiveColor;
                index = (index + 1) % separateds.Length; // ���̉摜��
            }
        }
        /*while (true)
        {
            foreach (Image img in images)
            {
                img.color = activeColor; // �摜��_��
                yield return new WaitForSeconds(lightDuration); // ��莞�ԑҋ@
                img.color = inactiveColor; // �摜������
            }
        }*/
    }

    public void StopLighting()
    {
        if (lightingCoroutine != null)
        {
            isStopped = true; // ��~��Ԃ�ݒ�
            StopCoroutine(lightingCoroutine); // �R���[�`�����~
            lightingCoroutine = null;
            upDownScript.ResumeLighting();
        }
    }

    public void ResumeLighting()
    {
        upDownScript.StopLighting();
        if (isStopped)
        {
            // �S�Ẵ}�X������
            ResetAllSeparateds();

            isStopped = false;
            lightingCoroutine = StartCoroutine(LightUpImages());
        }
    }

    private void ResetAllSeparateds()
    {
        foreach (GameObject separated in separateds)
        {
            separated.GetComponent<Renderer>().material.color = inactiveColor; // �����F�ɐݒ�
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
