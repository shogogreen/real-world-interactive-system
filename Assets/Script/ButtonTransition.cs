using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToGame()
    {
        StartCoroutine(PlaySEAndSwitchScene("StickGo"));
    }

    public void SwitchToGameRabbit()
    {
        StartCoroutine(PlaySEAndSwitchScene("StickGo_rabbit"));
    }

    public void SwitchToGamePumpkin()
    {
        StartCoroutine(PlaySEAndSwitchScene("StickGo_pumpkin"));
    }

    public void SwitchToGameEgg()
    {
        StartCoroutine(PlaySEAndSwitchScene("StickGo_egg"));
    }

    public void SwitchToStart()
    {
        StartCoroutine(PlaySEAndSwitchScene("Start"));
    }

    public void SwitchToHow()
    {
        StartCoroutine(PlaySEAndSwitchScene("HowToPlay1"));
    }

    public void SwitchToHow2()
    {
        StartCoroutine(PlaySEAndSwitchScene("HowToPlay2"));
    }

    public void SwitchToCol()
    {
        StartCoroutine(PlaySEAndSwitchScene("Collection"));
    }

    private void PlaySE()
    {
        if (SeManager.Instance != null)
        {
            SeManager.Instance.SettingPlaySE(); // 効果音を再生
        }
        else
        {
            Debug.LogError("SeManager Error");
        }
    }
    private IEnumerator PlaySEAndSwitchScene(string sceneName)
    {
        if (SeManager.Instance != null)
        {
            SeManager.Instance.SettingPlaySE(); // 効果音を再生
        }

        // 効果音の長さ分待つ (または適当に 0.5 秒程度)
        yield return new WaitForSeconds(0.5f);

        // シーンを遷移
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
