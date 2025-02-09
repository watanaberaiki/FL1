using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;



public class Enemy : MonoBehaviour
{
    //敵の行動ごとの名前
    public enum ActionName
    {
        Skip,       //0
        Attack,     //1
        Drain,      //2
        Acup,       //3
        Heal,       //4
        SelfDamage, //5
        DamageUp,   //6
        ComboDamage //7
     }

    //ステータス
    public int Hp = 0;
    public int Ac = 0;
    //敵の番号
    public int enemynum = 0;

    //敵の番号ごとの行動
    public ActionName[] action =new ActionName[6];
    public int[] actionValue=new int[6];

    //敵の番号入力
    public InputField EnemyNumInputField;
    //敵のテキスト
    public Text EnemyHpText;
    public Text EnemyACText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHPText();
        UpdateACText();
    }
    //エネミーの番号
    public void EnemyInputField()
    {
        // InputFieldから入力されたテキストを取得
        string input = EnemyNumInputField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int enemyNum))
        {
            enemynum = enemyNum;
            //数字の敵のステータス
            if (enemyNum == 1)
            {
                //初期ステータス
                Hp = 15;
                Ac = 8;
                //アクションの行動
                action[0] = ActionName.Skip;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Drain;
                action[4] = ActionName.Drain;
                action[5] = ActionName.Acup;
                //アクションごとの値
                actionValue[0] = 0;
                actionValue[1] = 7;
                actionValue[2] = 7;
                actionValue[3] = 5;
                actionValue[4] = 5;
                actionValue[5] = 1;
            }
            else if (enemyNum == 2)
            {
                //初期ステータス
                Hp = 40;
                Ac = 5;
                //アクションの行動
                action[0] = ActionName.Skip;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.Heal;
                action[5] = ActionName.Heal;
                //アクションごとの値
                actionValue[0] = 0;
                actionValue[1] = 5;
                actionValue[2] = 5;
                actionValue[3] = 5;
                actionValue[4] = 15;
                actionValue[5] = 15;
            }
            else if (enemyNum == 3)
            {
                //初期ステータス
                Hp = 20;
                Ac = 7;
                //アクションの行動
                action[0] = ActionName.SelfDamage;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.Attack;
                action[5] = ActionName.Attack;
                //アクションごとの値
                actionValue[0] = 5;
                actionValue[1] = 8;
                actionValue[2] = 8;
                actionValue[3] = 8;
                actionValue[4] = 8;
                actionValue[5] = 20;
            }
            else if (enemyNum == 4) {
                //初期ステータス
                Hp = 30;
                Ac = 4;
                //アクションの行動
                action[0] = ActionName.SelfDamage;
                action[1] = ActionName.SelfDamage;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.DamageUp;
                action[5] = ActionName.DamageUp;
                //アクションごとの値
                actionValue[0] = 10;
                actionValue[1] =10;
                actionValue[2] = 12;
                actionValue[3] = 12;
                actionValue[4] = 2;
                actionValue[5] = 2;
            }
            else if (enemyNum==100)
            {
                //初期ステータス
                Hp = 70;
                Ac = 8;
                //アクションの行動
                action[0] = ActionName.SelfDamage;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.DamageUp;
                action[5] = ActionName.Attack;
                //アクションごとの値
                actionValue[0] = 5;
                actionValue[1] = 12;
                actionValue[2] = 12;
                actionValue[3] = 12;
                actionValue[4] = 3;
                actionValue[5] = 21;
            }
        }
        else
        {
            Debug.LogWarning("数字を入力してください。");
        }

        // 入力フィールドをリセット
        EnemyNumInputField.text = "";
    }
    // HP表示を更新する
    void UpdateHPText()
    {
        EnemyHpText.text = "HP: " + Hp.ToString();
    }
    //Ac表示の更新
    void UpdateACText()
    {
        EnemyACText.text = "AC: " + Ac.ToString();
    }
    //Bossボタン
    public void BossButton()
    {
        //初期ステータス
        Hp = 70;
        Ac = 8;
        //アクションの行動
        action[0] = ActionName.SelfDamage;
        action[1] = ActionName.Attack;
        action[2] = ActionName.Attack;
        action[3] = ActionName.Attack;
        action[4] = ActionName.DamageUp;
        action[5] = ActionName.Attack;
        //アクションごとの値
        actionValue[0] = 5;
        actionValue[1] = 12;
        actionValue[2] = 12;
        actionValue[3] = 12;
        actionValue[4] = 3;
        actionValue[5] = 21;
    }
}
