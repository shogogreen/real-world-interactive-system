using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour
{
    private AudioSource audioSourceSE;
    public AudioClip se;

    public static SeManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // シーン遷移時に破棄されない設定
    }

    private void Start()
    {
        audioSourceSE = GetComponent<AudioSource>(); // AudioSource を取得
        if (audioSourceSE == null)
        {
            Debug.LogError("AudioSource コンポーネントがアタッチされていません！");
        }
    }

    public void SettingPlaySE()
    {
        if (audioSourceSE != null && se != null)
        {
            audioSourceSE.PlayOneShot(se); // 効果音を再生
        }
        else
        {
            Debug.LogWarning("AudioSource または AudioClip が設定されていません！");
        }
    }
}
