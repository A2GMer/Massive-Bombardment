using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // プレイヤーの移動の速さ
    public float speed = 10f;
    Rigidbody myRigidbody;
    // Ball コンポーネントへの参照
    private static Ball ballManager;

    // タッチされている位置を保存する変数
    Vector3 touchPos;
    Vector3 stPos = new Vector3(0, -7, 0);

    // Start is called before the first frame update
    void Start()
    {
        touchPos = stPos;
        transform.position = stPos;
        // Rigidbodyにアクセスして変数に保持
        myRigidbody = GetComponent<Rigidbody>();
        ballManager = GameObject.Find("BallGenerator").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("touchPos: " + touchPos);
        if (Input.GetMouseButtonDown(0))
        {
            ballManager.SpawnBall(transform.position);
        }

        //myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, 0f);
        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        Vector2 initialPos = transform.position;

        float t = 0.25f;

        transform.position = new Vector3(Mathf.Lerp(initialPos.x, touchPos.x, t), transform.position.y, transform.position.z);

        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (playerScreenPos.x <= 0f)
            transform.position = new Vector3(-2.44f, transform.position.y, 0f);
        if (playerScreenPos.x >= Screen.width)
            transform.position = new Vector3(2.44f, transform.position.y, 0f);
    }
}
