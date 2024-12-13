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

    public GameObject[] separateds; // 画像を順番に格納する配列
    public float lightDuration = 0.05f; // 点灯する時間
    public Color activeColor = Color.yellow; // 点灯時の色
    private Color inactiveColor; // 消灯時の色

    private Coroutine lightingCoroutine; // 現在のコルーチンを保存
    private bool isStopped = false; // 停止状態を管理

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
            // 現在の画像を点灯
            separateds[index].GetComponent<Renderer>().material.color = activeColor;

            yield return new WaitForSeconds(lightDuration);

            // 点灯状態をリセット（停止されていない場合のみ）
            if (!isStopped)
            {
                separateds[index].GetComponent<Renderer>().material.color = inactiveColor;
                index = (index + 1) % separateds.Length; // 次の画像へ
            }
        }
        /*while (true)
        {
            foreach (Image img in images)
            {
                img.color = activeColor; // 画像を点灯
                yield return new WaitForSeconds(lightDuration); // 一定時間待機
                img.color = inactiveColor; // 画像を消灯
            }
        }*/
    }

    public void StopLighting()
    {
        if (lightingCoroutine != null)
        {
            isStopped = true; // 停止状態を設定
            StopCoroutine(lightingCoroutine); // コルーチンを停止
            lightingCoroutine = null;
            upDownScript.ResumeLighting();
        }
    }

    public void ResumeLighting()
    {
        upDownScript.StopLighting();
        if (isStopped)
        {
            // 全てのマスを消灯
            ResetAllSeparateds();

            isStopped = false;
            lightingCoroutine = StartCoroutine(LightUpImages());
        }
    }

    private void ResetAllSeparateds()
    {
        foreach (GameObject separated in separateds)
        {
            separated.GetComponent<Renderer>().material.color = inactiveColor; // 消灯色に設定
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
