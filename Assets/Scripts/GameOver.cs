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

    private Ball ballManager;

    void Start()
    {
        ballManager = GameObject.Find("BallGenerator").GetComponent<Ball>();
    }

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
            ballManager.BallCount -= 1;
            //ballManager.ballPrefabList.Remove();
            // 当たったゲームオブジェクトを削除する
            Destroy(collision.gameObject);

            Debug.Log(ballManager.BallCount);
            if (ballManager.BallCount <= 0)
            {
                // Game Overと表示する
                gameOverMessage.text = "Game Over";
                isGameOver = true;
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
