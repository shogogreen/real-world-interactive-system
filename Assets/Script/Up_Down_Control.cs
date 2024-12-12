using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_Control : MonoBehaviour
{
    //public GameObject stick;
    public float moveSpeed = 1f; // ������̈ړ����x
    public float moveDistance = 10f; // ������̈ړ�����

    private Vector3 startPosition;
    private bool isMoving = false;

    void Start()
    {
        startPosition = transform.position; // �����ʒu��ۑ�
        StartMoving();
    }

    public void StartMoving()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveUpCoroutine());
        }
    }

    IEnumerator MoveUpCoroutine()
    {
        isMoving = true;
        float movedDistance = 0f;

        while (movedDistance < moveDistance)
        {
            float step = moveSpeed * Time.deltaTime; // 1�t���[���̈ړ���
            transform.Translate(Vector3.down * step); // ������Ɉړ�
            movedDistance += step; // �ړ�������ݐ�
            yield return null; // ���̃t���[���܂őҋ@
        }

        isMoving = false; // �ړ�����
    }
}
