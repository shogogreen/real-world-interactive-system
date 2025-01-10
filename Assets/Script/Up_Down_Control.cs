using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_Control : MonoBehaviour
{
    //public GameObject stick;
    public float moveSpeed = 1f; // 上方向の移動速度
    public float Distance = 0.95f; // 上方向の移動距離

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
                float step = moveSpeed * Time.deltaTime; // 1フレームの移動量
                Vector3 newPosition = rb.position + Vector3.up * step;
                rb.MovePosition(newPosition);  // 上方向に移動
                //targetObject.transform.Translate(Vector3.down * step); // 上方向に移動
                movedDistance += step; // 移動距離を累積
                yield return null; // 次のフレームまで待機
            }
        } else
        {
            while (movedDistance < -Distance)
            {
                float step = moveSpeed * Time.deltaTime; // 1フレームの移動量
                Vector3 newPosition = rb.position + Vector3.down * step;
                rb.MovePosition(newPosition);  // 下方向に移動
                //targetObject.transform.Translate(Vector3.up * step); // 下方向に移動
                movedDistance += step; // 移動距離を累積
                yield return null; // 次のフレームまで待機
            }
        }
        

        isMoving = false; // 移動完了
    }
}
