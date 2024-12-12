using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_Control : MonoBehaviour
{
    //public GameObject stick;
    public float moveSpeed = 1f; // 上方向の移動速度
    public float moveDistance = 10f; // 上方向の移動距離

    private Vector3 startPosition;
    private bool isMoving = false;

    void Start()
    {
        startPosition = transform.position; // 初期位置を保存
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
            float step = moveSpeed * Time.deltaTime; // 1フレームの移動量
            transform.Translate(Vector3.down * step); // 上方向に移動
            movedDistance += step; // 移動距離を累積
            yield return null; // 次のフレームまで待機
        }

        isMoving = false; // 移動完了
    }
}
