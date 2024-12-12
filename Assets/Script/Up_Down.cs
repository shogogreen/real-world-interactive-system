using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Up_Down : MonoBehaviour
{
    public Image up_meter_1_1;
    public Image up_meter_1_2;
    public Image up_meter_1_3;
    public Image up_meter_2;
    public Image up_meter_3;
    public Image up_meter_batsu_1;
    public Image up_meter_4;
    public Image up_meter_batsu_2;
    public Image up_meter_1_4;
    public Image up_meter_1_5;
    public Image down_meter_1_1;
    public Image down_meter_1_2;
    public Image down_meter_1_3;
    public Image down_meter_2;
    public Image down_meter_3;
    public Image down_meter_batsu_1;
    public Image down_meter_4;
    public Image down_meter_batsu_2;
    public Image down_meter_1_4;
    public Image down_meter_1_5;

    public Image[] images; // �摜�����ԂɊi�[����z��
    public float lightDuration = 0.05f; // �_�����鎞��
    public Color activeColor = Color.yellow; // �_�����̐F
    public Color inactiveColor = Color.white; // �������̐F

    private Coroutine lightingCoroutine; // ���݂̃R���[�`����ۑ�
    private bool isStopped = false; // ��~��Ԃ��Ǘ�

    // Start is called before the first frame update
    void Start()
    {
        images = new Image[]
        {
            up_meter_1_1, up_meter_1_2, up_meter_1_3, up_meter_2, up_meter_3, up_meter_batsu_1, up_meter_4, up_meter_batsu_2, up_meter_1_4, up_meter_1_5,
            up_meter_1_4, up_meter_batsu_2, up_meter_4, up_meter_batsu_1, up_meter_3, up_meter_2, up_meter_1_3, up_meter_1_2, up_meter_1_1,
            down_meter_1_1, down_meter_1_2, down_meter_1_3, down_meter_2, down_meter_3, down_meter_batsu_1, down_meter_4, down_meter_batsu_2, down_meter_1_4, down_meter_1_5,
            down_meter_1_4, down_meter_batsu_2, down_meter_4, down_meter_batsu_1, down_meter_3, down_meter_2, down_meter_1_3, down_meter_1_2, down_meter_1_1
        };
        lightingCoroutine = StartCoroutine(LightUpImages());
    }

    IEnumerator LightUpImages()
    {
        int index = 0;
        while (!isStopped)
        {
            // ���݂̉摜��_��
            images[index].color = activeColor;

            yield return new WaitForSeconds(lightDuration);

            // �_����Ԃ����Z�b�g�i��~����Ă��Ȃ��ꍇ�̂݁j
            if (!isStopped)
            {
                images[index].color = inactiveColor;
                index = (index + 1) % images.Length; // ���̉摜��
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
        }
    }

    public void ResumeLighting()
    {
        if (isStopped)
        {
            // �S�Ẵ}�X������
            ResetAllImages();

            isStopped = false;
            lightingCoroutine = StartCoroutine(LightUpImages());
        }
    }

    private void ResetAllImages()
    {
        foreach (Image img in images)
        {
            img.color = inactiveColor; // �����F�ɐݒ�
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}