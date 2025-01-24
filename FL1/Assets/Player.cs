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
    public Text AcText;
    public Text StrText;
    public Text IntText;
    public Text DexText;

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
        //ステータス表示の更新
        UpdateHPText();
        UpdateACText();
        UpdateSTRText();
        UpdateIntText();
        UpdateDexText();
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
            //100より増えない
            if (Hp > 100)
            {
                Hp = 100;
            }
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
    //Ac表示の更新
    void UpdateACText()
    {
        AcText.text = "AC: " + Ac.ToString();
    }
    //Str表示の更新
    void UpdateSTRText()
    {
        StrText.text = "STR: " + Str.ToString();
    }
    //Int表示の更新
    void UpdateIntText()
    {
        IntText.text = "Int: " + Int.ToString();
    }
    //Dex表示の更新
    void UpdateDexText()
    {
        DexText.text = "Dex: " + Dex.ToString();
    }
}
