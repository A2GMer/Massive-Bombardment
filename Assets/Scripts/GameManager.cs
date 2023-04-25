using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab; // ブロックのPrefab
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

        int[,] stageBlocks = Const.stage_001;

        // ブロックを生成する
        for (int i = 0; i < stageBlocks.GetLongLength(0); i++)
        {
            for (int j = 0; j < stageBlocks.GetLongLength(1); j++)
            {
                if (stageBlocks[i,j] == 1)
                {
                    // ブロックの位置を計算する
                    float posX = j * spacingX - ((stageBlocks.GetLongLength(1) - 1) * spacingX) / 2;
                    float posY = i * spacingY + 3f;

                    // ブロックを生成する
                    GameObject block = Instantiate(blockPrefab, new Vector3(posX, posY, 0f), Quaternion.identity);
                    block.transform.parent = transform;
                }
            }
        }
    }
}
