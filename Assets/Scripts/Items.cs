using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Items : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform myTransform;

    // Item オブジェクトのプレハブ
    public GameObject itemPrefab;
    // Block を破壊したときに Item を生成する確率
    public float spawnProbability = 0.3f;
    private Ball ballManager;

    private void Start()
    {
        ballManager = GameObject.Find("BallGenerator").GetComponent<Ball>();
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = itemPrefab.gameObject.GetComponent<Rigidbody>();
        myRigidbody.velocity = new Vector3(0f, -5f, 0f);
        myTransform = transform;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ballの数を倍にする
            ballManager.BallCount += 1;

            // 破壊された Block の位置に Item を生成する
            ballManager.SpawnBall(transform.position);

            // ゲームオブジェクトを削除するメソッド
            Destroy(gameObject);
        }
    }

    // Item オブジェクトを生成する関数
    public void SpawnItem(Vector3 position)
    {
        // Item オブジェクトを生成する
        GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
    }
}
