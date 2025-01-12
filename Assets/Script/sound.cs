using UnityEngine;
using System.Collections;

public class MainSoundScript : MonoBehaviour {
    public bool DontDestroyEnabled = true;
    private static MainSoundScript instance; // インスタンスを保持する変数

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            // 初回の起動時
            instance = this;

            if (DontDestroyEnabled) {
                // オブジェクトをシーン間で破棄しないようにする
                DontDestroyOnLoad(this.gameObject);
            }
        } else {
            // 既にインスタンスが存在する場合、このオブジェクトを破棄
            Destroy(this.gameObject);
        }
    }
}
