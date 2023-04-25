using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    // Items コンポーネントへの参照
    private Items itemManager;

    private void Start()
    {
        itemManager = FindObjectOfType<Items>();
    }
    // 何かとぶつかった時に呼ばれるビルトインメソッド
    void OnCollisionEnter(Collision collision)
    {
        // ゲームオブジェクトを削除するメソッド
        Destroy(gameObject);
        Debug.Log("Destroy");

        // 一定の確率で Item を生成する
        if (Random.value < itemManager.spawnProbability)
        {
            Debug.Log("Item Spawn");
            // 破壊された Block の位置に Item を生成する
            itemManager.SpawnItem(transform.position);
        }
        {
            Debug.Log("No Item");
        }
    }
}
