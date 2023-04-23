using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Items : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform myTransform;

    private void Start()
    {
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.velocity = new Vector3(0f, -1, 0f);
        myTransform = transform;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ゲームオブジェクトを削除するメソッド
            Destroy(gameObject);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }
}
