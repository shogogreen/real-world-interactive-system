using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotationSpeed = 0.01f; // 回転速度
    private Vector3 rotationCenter = new Vector3(0f, 20f, -7.5f); // 回転の中心
    private bool isDragging = false; // ドラッグ中かどうか
    private Vector3 previousMousePosition; // ドラッグ開始時のマウス位置
    private float currentAngle = 0f; // 回転角度

    void Update()
    {
        // マウスが押されたらドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            previousMousePosition = Input.mousePosition; // 押下時のマウス位置を記録
        }

        // マウスが離されたらドラッグ終了
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            currentAngle = 0f;
        }

        // ドラッグ中にPlayerオブジェクトを回転
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition; // 現在のマウス位置を取得
            Vector3 deltaMousePosition = currentMousePosition - previousMousePosition; // マウスの移動量

            // ドラッグの初回フレームでは移動量を無視する
            if (deltaMousePosition.magnitude > Mathf.Epsilon)
            {
                // X方向のドラッグ量に応じて回転角度を計算
                float rotationAmount = deltaMousePosition.x * rotationSpeed;
                currentAngle = rotationAmount; // 累積の回転量を更新

                // Playerオブジェクトを回転
                RotatePlayer();
            }

            // マウス位置を更新
            previousMousePosition = currentMousePosition;
        }
    }

    void RotatePlayer()
    {
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
    }
}
