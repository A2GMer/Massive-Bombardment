using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // publicにしてInspectorから設定できるようにする
    public Text gameOverMessage;
    // ゲームオーバーしたかどうかを判断するための変数
    bool isGameOver = false;

    void Update()
    {
        // ゲームオーバーになっている、かつ、Submitボタンを押したら実行する
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            // Playシーンをロードする
            SceneManager.LoadScene("Play");
        }
    }

    // 衝突時に呼ばれる
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Game Overと表示する
            gameOverMessage.text = "Game Over";
            // 当たったゲームオブジェクトを削除する
            Destroy(collision.gameObject);
            isGameOver = true;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
