using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Hp;
    public int Ac;
    public int Dex;
    public int Int;
    public int Str;
    public int MaxHp;

    public int eventNum = 0;
    public InputField HpInputField;
    public InputField EventNumField;
    //戦闘外
    public Text HpText;
    public Text AcText;
    public Text StrText;
    public Text IntText;
    public Text DexText;
    //戦闘中
    public Text HpText2;
    public Text AcText2;
    public Text StrText2;
    public Text IntText2;
    public Text DexText2;
    //イベント中
    public Text HpText3;
    public Text AcText3;
    public Text StrText3;
    public Text IntText3;
    public Text DexText3;
    //補正値
    public int Strnum;
    public int Intnum;
    public int Dexnum;
    private int Eventnum;
    // Start is called before the first frame update
    void Start()
    {
        //status初期値
        Hp = 50;
        Ac = 10;
        Str = 16;
        Int = 4;
        Dex = 24;
        MaxHp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //100より増えない
        if (Hp > MaxHp)
        {
            Hp = MaxHp;
        }
        //ステータス表示の更新
        UpdateHPText();
        UpdateACText();
        UpdateSTRText();
        UpdateIntText();
        UpdateDexText();
        //ステータス補正値の計算
        UpdateStrStatus();
        UpdateIntStatus();
        UpdateDexStatus();
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
        HpText2.text = "HP: " + Hp.ToString();
        HpText3.text = "HP: " + Hp.ToString();

    }
    //Ac表示の更新
    void UpdateACText()
    {
        AcText.text = "AC: " + Ac.ToString();
        AcText2.text = "AC: " + Ac.ToString();
        AcText3.text = "AC: " + Ac.ToString();

    }
    //Str表示の更新
    void UpdateSTRText()
    {
        StrText.text = "STR: " + Str.ToString()+ "("+ Strnum.ToString()+")";
        StrText2.text = "STR: " + Str.ToString() + "(" + Strnum.ToString() + ")";
        StrText3.text = "STR: " + Str.ToString() + "(" + Strnum.ToString() + ")";
    }
    //Int表示の更新
    void UpdateIntText()
    {
        IntText.text = "Int: " + Int.ToString() + "(" + Intnum.ToString() + ")";
        IntText2.text = "Int: " + Int.ToString() + "(" + Intnum.ToString() + ")";
        IntText3.text = "Int: " + Int.ToString() + "(" + Intnum.ToString() + ")";

    }
    //Dex表示の更新
    void UpdateDexText()
    {
        DexText.text = "Dex: " + Dex.ToString() + "(" + Dexnum.ToString() + ")";
        DexText2.text = "Dex: " + Dex.ToString() + "(" + Dexnum.ToString() + ")";
        DexText3.text = "Dex: " + Dex.ToString() + "(" + Dexnum.ToString() + ")";

    }
    //イベント番号
    public void EventNum()
    {
        // InputFieldから入力されたテキストを取得
        string input = EventNumField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int eventnum))
        {
            eventNum = eventnum;
        }
    }

    //ステータス補正の計算
    void UpdateStrStatus()
    {
        if (Str == 1)
        {
            Strnum = -5;
        }
        else if (Str == 2 || Str == 3)
        {
            Strnum = -4;
        }
        else if (Str == 4 || Str == 5)
        {
            Strnum = -3;
        }
        else if (Str == 6 || Str == 7)
        {
            Strnum = -2;
        }
        else if (Str == 8 || Str == 9)
        {
            Strnum = -1;
        }
        else if (Str == 10 || Str == 11)
        {
            Strnum = 0;
        }
        else if (Str == 12 || Str == 13)
        {
            Strnum = 1;
        }
        else if (Str ==14 || Str == 15)
        {
            Strnum = 2;
        }
        else if (Str == 16 || Str == 17)
        {
            Strnum = 3;
        }
        else if (Str == 18 || Str == 19)
        {
            Strnum = 4;
        }
        else if (Str == 20)
        {
            Strnum = 5;
        }

    }
    //ステータス補正の計算
    void UpdateIntStatus()
    {
        if (Int == 1)
        {
            Intnum = -5;
        }
        else if (Int == 2 || Int == 3)
        {
            Intnum = -4;
        }
        else if (Int == 4 || Int == 5)
        {
            Intnum = -3;
        }
        else if (Int == 6 || Int == 7)
        {
            Intnum = -2;
        }
        else if (Int == 8 || Int == 9)
        {
            Intnum = -1;
        }
        else if (Int == 10 || Int == 11)
        {
            Intnum = 0;
        }
        else if (Int == 12 || Int == 13)
        {
            Intnum = 1;
        }
        else if (Int == 14 || Int == 15)
        {
            Intnum = 2;
        }
        else if (Int == 16 || Int == 17)
        {
            Intnum = 3;
        }
        else if (Int == 18 || Int == 19)
        {
            Intnum = 4;
        }
        else if (Int == 20)
        {
            Intnum = 5;
        }

    }
    //ステータス補正の計算
    void UpdateDexStatus()
    {
        if (Dex == 1)
        {
            Dexnum = -5;
        }
        else if (Dex == 2 || Dex == 3)
        {
            Dexnum = -4;
        }
        else if (Dex == 4 || Dex == 5)
        {
            Dexnum = -3;
        }
        else if (Dex == 6 || Dex == 7)
        {
            Dexnum = -2;
        }
        else if (Dex == 8 || Dex == 9)
        {
            Dexnum = -1;
        }
        else if (Dex == 10 || Dex == 11)
        {
            Dexnum = 0;
        }
        else if (Dex == 12 || Dex == 13)
        {
            Dexnum = 1;
        }
        else if (Dex == 14 || Dex == 15)
        {
            Dexnum = 2;
        }
        else if (Dex == 16 || Dex == 17)
        {
            Dexnum = 3;
        }
        else if (Dex == 18 || Dex == 19)
        {
            Dexnum = 4;
        }
        else if (Dex == 20)
        {
            Dexnum = 5;
        }

    }
}
