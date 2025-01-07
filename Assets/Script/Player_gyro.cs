using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_gyro : MonoBehaviour
{
    private Vector3 rotationCenter = new Vector3(0f, 20f, -7.5f); // ��]�̒��S
    private Quaternion q;
    private Quaternion newQ;
    private Vector3 eulerAngles;
    private float yAngle;
    private float currentAngle = 0f; // ��]�p�x
    private float prevyAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        q = Input.gyro.attitude;
        newQ = new Quaternion(-q.x, -q.z, -q.y, q.w) * Quaternion.Euler(90f, 0f, 0f);
        eulerAngles = newQ.eulerAngles;
        prevyAngle = eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        q = Input.gyro.attitude;
        newQ = new Quaternion(-q.x, -q.z, -q.y, q.w) * Quaternion.Euler(90f, 0f, 0f);
        eulerAngles = newQ.eulerAngles;
        yAngle = eulerAngles.y;
        currentAngle = yAngle - prevyAngle;
        // ��]�̒��S����̕����x�N�g�����v�Z
        Vector3 direction = transform.position - rotationCenter;

        // Y������̉�]��K�p
        Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);

        // �V�����ʒu���v�Z
        Vector3 newPosition = rotation * direction + rotationCenter;

        // Player�I�u�W�F�N�g��V�����ʒu�Ɉړ�
        transform.position = newPosition;

        // Player�I�u�W�F�N�g�̌�������ɉ�]���S�������悤�ɐݒ�
        transform.LookAt(rotationCenter);
        prevyAngle = yAngle;
    }
}
