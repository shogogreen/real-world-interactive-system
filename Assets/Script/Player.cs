using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotationSpeed = 0.01f; // ��]���x
    private Vector3 rotationCenter = new Vector3(0f, 20f, -7.5f); // ��]�̒��S
    private bool isDragging = false; // �h���b�O�����ǂ���
    private Vector3 previousMousePosition; // �h���b�O�J�n���̃}�E�X�ʒu
    private float currentAngle = 0f; // ��]�p�x

    void Update()
    {
        // �}�E�X�������ꂽ��h���b�O�J�n
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            previousMousePosition = Input.mousePosition; // �������̃}�E�X�ʒu���L�^
        }

        // �}�E�X�������ꂽ��h���b�O�I��
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            currentAngle = 0f;
        }

        // �h���b�O����Player�I�u�W�F�N�g����]
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition; // ���݂̃}�E�X�ʒu���擾
            Vector3 deltaMousePosition = currentMousePosition - previousMousePosition; // �}�E�X�̈ړ���

            // �h���b�O�̏���t���[���ł͈ړ��ʂ𖳎�����
            if (deltaMousePosition.magnitude > Mathf.Epsilon)
            {
                // X�����̃h���b�O�ʂɉ����ĉ�]�p�x���v�Z
                float rotationAmount = deltaMousePosition.x * rotationSpeed;
                currentAngle = rotationAmount; // �ݐς̉�]�ʂ��X�V

                // Player�I�u�W�F�N�g����]
                RotatePlayer();
            }

            // �}�E�X�ʒu���X�V
            previousMousePosition = currentMousePosition;
        }
    }

    void RotatePlayer()
    {
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
    }
}
