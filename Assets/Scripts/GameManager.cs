using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab; // ブロックのPrefab
    public int rows = 5; // ブロックの行数
    public int cols = 10; // ブロックの列数
    public Transform blockMap; // ブロックの親オブジェクト

    void Start()
    {
        // ブロックを自動生成する
        GenerateBlocks();
    }

    public void OnClickToPlaySceneButton()
    {
        SceneManager.LoadScene("Play");
    }

    // ブロックを自動生成するメソッド
    void GenerateBlocks()
    {
        // ブロックの間隔を設定する
        float spacingX = 1f;
        float spacingY = 0.5f;

        // ブロックを生成する
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // ブロックの位置を計算する
                float posX = j * spacingX - ((cols - 1) * spacingX) / 2;
                float posY = i * spacingY + 3f;

                // ブロックを生成する
                GameObject block = Instantiate(blockPrefab, new Vector3(posX, posY, 0f), Quaternion.identity);
                block.transform.parent = transform;
            }
        }
    }
}
