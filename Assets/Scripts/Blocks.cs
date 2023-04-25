using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    // Items コンポーネントへの参照
    private static Items itemManager;

    private void Start()
    {
        itemManager = GameObject.Find("ItemGenerator").GetComponent<Items>();
    }
    // 何かとぶつかった時に呼ばれるビルトインメソッド
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // ゲームオブジェクトを削除するメソッド
            Destroy(gameObject);

            // 一定の確率で Item を生成する
            if (Random.value < itemManager.spawnProbability)
            {
                // 破壊された Block の位置に Item を生成する
                itemManager.SpawnItem(transform.position);
            }
        }
    }
}
