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
        SceneManager.LoadScene("StickGo", LoadSceneMode.Single);
    }

    public void SwitchToGameRabbit()
    {
        SceneManager.LoadScene("StickGo_rabbit", LoadSceneMode.Single);
    }

    public void SwitchToGamePumpkin()
    {
        SceneManager.LoadScene("StickGo_pumpkin", LoadSceneMode.Single);
    }

    public void SwitchToGameEgg()
    {
        SceneManager.LoadScene("StickGo_egg", LoadSceneMode.Single);
    }

    public void SwitchToStart()
    {
        Debug.Log("ボタンが押されました。シーン遷移を開始します。");
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public void SwitchToHow()
    {
        SceneManager.LoadScene("HowToPlay1", LoadSceneMode.Single);
    }

    public void SwitchToHow2()
    {
        SceneManager.LoadScene("HowToPlay2", LoadSceneMode.Single);
    }

    public void SwitchToCol()
    {
        SceneManager.LoadScene("Collection", LoadSceneMode.Single);
    }
}
