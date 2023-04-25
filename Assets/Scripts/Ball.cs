using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ボールの移動の速さを指定する変数
    public float speed = 5f;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    Rigidbody myRigidbody;
    Transform myTransform;
    bool isStarted = false;

    // Ball オブジェクトのプレハブ
    public GameObject ballPrefab;

    public int BallCount { get; set; } = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = ballPrefab.GetComponent<Rigidbody>();
        //myRigidbody.velocity = new Vector3(1f, 1f, 0f);
        myRigidbody.velocity = new Vector3(0f, 0f, 0f);
        myTransform = transform;
    }

    void Update()
    {
        // Ballが動き出していなければ、タッチされたら動き出す
        if (!isStarted && Input.touchCount > 0)
        {
            myRigidbody.velocity = new Vector3(0f, 1f, 0f);
            isStarted = true;
        }

        // 現在の速度を取得
        Vector3 velocity = myRigidbody.velocity;
        // 速さを計算
        float clampedSpeed = Mathf.Clamp(velocity.magnitude, minSpeed, maxSpeed);
        // 速度を変更
        myRigidbody.velocity = velocity.normalized * clampedSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // プレイヤーに当たったときに、跳ね返る方向を変える
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーの位置を取得
            Vector3 playerPos = collision.transform.position;
            // ボールの位置を取得
            Vector3 ballPos = myTransform.position;
            // プレイヤーから見たボールの方向を計算
            Vector3 direction = (ballPos - playerPos).normalized;
            // 現在の速さを取得
            float speed = myRigidbody.velocity.magnitude;
            // 速度を変更
            myRigidbody.velocity = direction * speed;
        }
    }

    // Ball オブジェクトを生成する関数
    public void SpawnBall(Vector3 position)
    {
        // Ball オブジェクトを生成する
        GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
