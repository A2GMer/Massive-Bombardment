using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーの移動の速さ
    public float speed = 10f;
    Rigidbody myRigidbody;

    // タッチされている位置を保存する変数
    Vector2 touchPos;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 stPos = new Vector3(0, -7, 0);
        transform.position = stPos;
        // Rigidbodyにアクセスして変数に保持
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
