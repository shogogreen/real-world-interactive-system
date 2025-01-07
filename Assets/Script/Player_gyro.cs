using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_gyro : MonoBehaviour
{
    private Vector3 rotationCenter = new Vector3(0f, 20f, -7.5f); // 回転の中心
    private Quaternion q;
    private Quaternion newQ;
    private Vector3 eulerAngles;
    private float yAngle;
    private float currentAngle = 0f; // 回転角度
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
        // 回転の中心からの方向ベクトルを計算
        Vector3 direction = transform.position - rotationCenter;

        // Y軸周りの回転を適用
        Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);

        // 新しい位置を計算
        Vector3 newPosition = rotation * direction + rotationCenter;

        // Playerオブジェクトを新しい位置に移動
        transform.position = newPosition;

        // Playerオブジェクトの向きを常に回転中心を向くように設定
        transform.LookAt(rotationCenter);
        prevyAngle = yAngle;
    }
}
