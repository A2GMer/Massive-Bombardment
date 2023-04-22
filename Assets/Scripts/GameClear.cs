using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public Text gameClearMessage;
    Transform myTransform;
    bool isGameClear = false;

    void Start()
    {
        // Transformコンポーネントを保持しておく
        myTransform = transform;
    }

    void Update()
    {
        // 子供がいなくなったらゲームを停止する
        if (myTransform.childCount == 0)
        {
            gameClearMessage.text = "Game Clear";
            Time.timeScale = 0f;
            isGameClear = true;
        }

        // ゲームクリアしている、かつ、ボタン入力でシーンを再ロード
        if (isGameClear && Input.GetMouseButtonDown(0))
        {
            // timeScaleを1に戻しておく
            Time.timeScale = 1f;
            // シーンのロード
            SceneManager.LoadScene("Play");
        }
    }
}
