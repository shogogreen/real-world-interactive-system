using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_Control : MonoBehaviour
{
    //public GameObject stick;
    public float moveSpeed = 1f; // ������̈ړ����x
    public float Distance = 0.95f; // ������̈ړ�����

    private bool isMoving = false;

    void Start()
    {

    }

    public void StartMoving(GameObject targetObject, float Distance)
    {
        if (!isMoving)
        {
            StartCoroutine(MoveUpCoroutine(targetObject, Distance));
        }
    }

    IEnumerator MoveUpCoroutine(GameObject targetObject, float Distance)
    {
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();
        isMoving = true;
        float movedDistance = 0f;
        if (Distance > 0)
        {
            while (movedDistance < Distance)
            {
                float step = moveSpeed * Time.deltaTime; // 1�t���[���̈ړ���
                Vector3 newPosition = rb.position + Vector3.up * step;
                rb.MovePosition(newPosition);  // ������Ɉړ�
                //targetObject.transform.Translate(Vector3.down * step); // ������Ɉړ�
                movedDistance += step; // �ړ�������ݐ�
                yield return null; // ���̃t���[���܂őҋ@
            }
        } else
        {
            while (movedDistance < -Distance)
            {
                float step = moveSpeed * Time.deltaTime; // 1�t���[���̈ړ���
                Vector3 newPosition = rb.position + Vector3.down * step;
                rb.MovePosition(newPosition);  // �������Ɉړ�
                //targetObject.transform.Translate(Vector3.up * step); // �������Ɉړ�
                movedDistance += step; // �ړ�������ݐ�
                yield return null; // ���̃t���[���܂őҋ@
            }
        }
        

        isMoving = false; // �ړ�����
    }
}
