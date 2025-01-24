using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int Hp;
    private int Ac;
    private int Dex; 
    private int Int;
    private int Str;

    public InputField HpInputField;
    public Text HpText;


    // Start is called before the first frame update
    void Start()
    {
        //status初期値
        Hp = 100;
        Ac = 10;
        Str = 16;
        Int = 4;
        Dex = 24;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ヒールの決定
    public void OnAddHPButtonClicked()
    {
        // InputFieldから入力されたテキストを取得
        string input = HpInputField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int addHP))
        {
            // HPを増やす
            Hp += addHP;

            // 現在のHPを更新
            UpdateHPText();
        }
        else
        {
            Debug.LogWarning("数字を入力してください。");
        }

        // 入力フィールドをリセット
        HpInputField.text = "";
    }

    // HP表示を更新する
    void UpdateHPText()
    {
        HpText.text = "HP: " + Hp.ToString();
    }

}
