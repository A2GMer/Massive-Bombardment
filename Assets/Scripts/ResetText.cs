using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetText : MonoBehaviour
{
    void Start()
    {
        // アクセスは1回きりなので、フィールド変数を用意しなくてもいい
        Text myText = GetComponent<Text>();
        // textに空の文字列を設定する
        myText.text = "";
    }
}
