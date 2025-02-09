using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enemy;
using System.Threading.Tasks;
using System.Threading;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    //キャンバス
    public Canvas canvas;
    public Canvas canvas1;
    //テキスト
    public Text enemyDice20Text;
    public Text playerDice20Text;
    public Text TurnText;
    public Text HpText;
    public Text AcText;
    public Text ATKUPText;
    public Text EnemyATKUPText;
    public Text EnemyTurnText;
    public Text EnemyBattleDice6Text;
    public Text EnemyBattleDice20Text;
    public Text EnemyActionText;
    public Text PlayerTurnText;
    public Text PlayerActionText;
    public Text Player20DiceText;
    //入力
    public InputField EnemyNumInputField;
    public InputField PlayerDice20InputField;
    public InputField SkillInputField;
    public InputField HitCheckDiceField;
    //パネル
    public GameObject SpeedPanel1;
    public GameObject SpeedPanel2;
    public GameObject StatusPanel;
    public GameObject SkillPanel;
    public GameObject HitCheackDicePanel;
    public GameObject EnemyPanel;
    public GameObject NextPanel;
    public GameObject PlayerPanel;
    //画像
    public Image attackImage;
    public Image foodImage;
    public Image trainingImage;
    public Image fireSwordImage;
    public Image heavyAttackImage;
    //敵の番号
    int enemyNum = 0;
    //20ダイス
    int enemyDice20 = 0;
    int playerDice20 = 0;
    //6ダイス
    int enemyDice6 = 0;
    //ダイスの回数
    int enemyDice6Count = 0;
    int enemyDice20Count = 0;
    int enemyComboDice20Count = 0;
    int enemyActionCount = 0;
    //スキル番号
    int skillnum = 0;
    //ATK
    int ATK = 0;
    int plusATK = 0;
    int enemyPlusATK = 0;
    //連続攻撃用
    int combo = 12;
    //敵
    Enemy enemy;
    //プレイヤー
    Player player;
    //判定
    bool isSpeedDice20 = false;
    bool isPlayerTurn = false;
    bool isBattle = false;
    bool isNext = false;
    // Start is called before the first frame update
    void Start()
    {
        //エネミーの情報
        GameObject obj = GameObject.Find("Enemy"); //Enemyっていうオブジェクトを探す
        enemy = obj.GetComponent<Enemy>(); //付いているスクリプトを取得
        //エネミーの情報
        GameObject obj1 = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        player = obj1.GetComponent<Player>(); //付いているスクリプトを取得
        //初期のパネル設定
        SpeedPanel1.SetActive(true);
        SpeedPanel2.SetActive(false);
        StatusPanel.SetActive(false);
        SkillPanel.SetActive(false);
        HitCheackDicePanel.SetActive(false);
        EnemyPanel.SetActive(false);
        NextPanel.SetActive(false);
        PlayerPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        //バトル中
        if (isBattle)
        {
            //画像表示
            if (skillnum == 1)
            {
                attackImage.enabled = true;
                foodImage.enabled = false;
                trainingImage.enabled = false;
                fireSwordImage.enabled = false;
                heavyAttackImage.enabled = false;
            }
            else if (skillnum == 2)
            {
                attackImage.enabled = false;
                foodImage.enabled = true;
                trainingImage.enabled = false;
                fireSwordImage.enabled = false;
                heavyAttackImage.enabled = false;
            }
            else if (skillnum == 3)
            {
                attackImage.enabled = false;
                foodImage.enabled = false;
                trainingImage.enabled = true;
                fireSwordImage.enabled = false;
                heavyAttackImage.enabled = false;
            }
            else if (skillnum == 4)
            {
                attackImage.enabled = false;
                foodImage.enabled = false;
                trainingImage.enabled = false;
                fireSwordImage.enabled = true;
                heavyAttackImage.enabled = false;
            }
            else if (skillnum == 5)
            {
                attackImage.enabled = false;
                foodImage.enabled = false;
                trainingImage.enabled = false;
                fireSwordImage.enabled = false;
                heavyAttackImage.enabled = true;
            }
            else
            {
                attackImage.enabled = false;
                foodImage.enabled = false;
                trainingImage.enabled = false;
                fireSwordImage.enabled = false;
                heavyAttackImage.enabled = false;
            }
            //ATKの上昇値表示
            UpdateATKUPText();
            UpdateEnemyATKUPText();
            //敵とプレイヤーのステータス表示
            StatusPanel.SetActive(true);
            //プレイヤーのターン
            if (isPlayerTurn)
            {
                PlayerTurnText.text = "プレイヤーのターンです";

                NextPanel.SetActive(false);
                //敵のパネル無効化
                EnemyPanel.SetActive(false);
                //スキル番号が何もない場合
                if (skillnum >= 6 || skillnum <= 0)
                {
                    PlayerActionText.enabled = false;
                    Player20DiceText.enabled = false;
                    SkillPanel.SetActive(true);
                }
                //攻撃の場合の命中チェック
                if (skillnum == 1 || skillnum == 4 || skillnum == 5)
                {
                    //パネルを無効化
                    SkillPanel.SetActive(false);
                    HitCheackDicePanel.SetActive(true);
                }
                //ステータスアップ計の場合は敵のターンになる
                else if (skillnum == 2 || skillnum == 3)
                {
                    NextPanel.SetActive(true);

                    //パネルを無効化
                    SkillPanel.SetActive(false);
                    if (isNext)
                    {
                        skillnum = 0;
                        isPlayerTurn = true;
                        isNext = false;
                        //プレイヤーパネル
                        PlayerPanel.SetActive(true);
                        TurnChange();
                    }

                }

            }
            //敵のターン
            else if (!isPlayerTurn)
            {
                StartCoroutine(EnemyActionUpdate());
            }
            //敵が死んでいるかどうか
            if (enemy.Hp <= 0)
            {
                EnemyDead();
            }
        }
        //バトル外
        else if (!isBattle)
        {
            UpdateHPText();
            UpdateACText();
            UpdateDice20Text();
            UpdatePlayerDice20Text();

            //どちらが先行か
            //プレイヤーから
            if (enemyDice20 <= playerDice20)
            {
                TurnText.text = "プレイヤーのターンからスタート";
                isPlayerTurn = true;

            }
            //敵から
            else if (enemyDice20 > playerDice20)
            {
                TurnText.text = "エネミーのターンからスタート";
                isPlayerTurn = false;
            }
            //else if(enemyDice20 == playerDice20)
            //{
            //    TurnText.text = "もう一度ダイスを振る";
            //}
        }
    }
    //敵の番号を入力
    public void EnemyInputField()
    {
        // InputFieldから入力されたテキストを取得
        string input = EnemyNumInputField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int enemy))
        {
            if (enemy == 1 || enemy == 2 || enemy == 3 || enemy == 4 || enemy == 100)
            {
                enemyNum = enemy;
                isBattle = false;
                plusATK = 0;
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
        HpText.text = "HP: " + enemy.Hp.ToString();
    }
    // AC表示を更新する
    void UpdateACText()
    {
        AcText.text = "AC: " + enemy.Ac.ToString();
    }
    // ATKUP表示を更新する
    void UpdateATKUPText()
    {
        ATKUPText.text = "ATKUP: " + plusATK.ToString();
    }
    // 20面ダイスの結果表示を更新する
    void UpdateDice20Text()
    {
        enemyDice20Text.text = "敵のダイス結果: " + enemyDice20;
    }
    //プレイヤーのダイスの結果表示
    void UpdatePlayerDice20Text()
    {
        playerDice20Text.text = "自分のダイス結果: " + playerDice20;
    }
    //敵の行動表示
    void UpdateEnemyTurnText()
    {
        EnemyTurnText.text = "敵のターンです";
    }
    //敵の6ダイス結果表示
    void UpdateEnemyDice6Text()
    {
        EnemyBattleDice6Text.text = "敵のダイスは" + (enemyDice6 + 1) + "です";
    }
    //敵のATKUP表示
    void UpdateEnemyATKUPText()
    {
        EnemyATKUPText.text = "ATKUP:" + enemyPlusATK.ToString();
    }
    //20ダイスを振る
    public void EnemyDice20()
    {
        //ランダム最初のターン決め
        enemyDice20 = Random.Range(1, 21);
    }
    //プレイヤーの結果を代入
    public void PlayerDice20()
    {
        // InputFieldから入力されたテキストを取得
        string input = PlayerDice20InputField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int player))
        {
            playerDice20 = player;
        }
    }
    //パネルの切り替え
    public void SpeedPanelChange()
    {
        SpeedPanel1.SetActive(false);
        SpeedPanel2.SetActive(true);
    }
    //バトル開始
    public void BattleStart()
    {
        isBattle = true;
        SpeedPanel1.SetActive(false);
        SpeedPanel2.SetActive(false);
        if (isPlayerTurn)
        {
            //プレイヤーパネル
            PlayerPanel.SetActive(true);
        }
        else if (!isPlayerTurn)
        {
            PlayerPanel.SetActive(false);
        }
    }

    //スキル番号代入
    public void SkillNum()
    {
        // InputFieldから入力されたテキストを取得
        string input = SkillInputField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int skill))
        {

            skillnum = skill;
            //スキル毎
            if (skillnum == 1)
            {
                ATK = 7 + player.Strnum + plusATK;
            }
            else if (skillnum == 2)
            {
                player.Hp += 10;
                PlayerActionText.enabled = true;
                PlayerActionText.text = 10 + "回復";


            }
            else if (skillnum == 3)
            {
                plusATK += 2;
                PlayerActionText.enabled = true;
                PlayerActionText.text = "この戦闘中" + 2 + "ATKUP";
            }
            else if (skillnum == 4)
            {
                ATK = 10 + player.Strnum + player.Intnum + plusATK;
            }
            else if (skillnum == 5)
            {
                ATK = 15 + plusATK;
            }
        }
        else
        {
            Debug.LogWarning("数字を入力してください。");
        }

        // 入力フィールドをリセット
        SkillInputField.text = "";
    }
    //ターンチェンジ
    public void TurnChange()
    {
        if (isPlayerTurn == true)
        {
            isPlayerTurn = false;
            enemyDice6Count = 0;
            enemyActionCount = 0;
            enemyDice20Count = 0;
        }
        else if (isPlayerTurn == false)
        {
            isPlayerTurn = true;
        }
    }

    //命中チェック
    public async void HitCheckDice()
    {
        // InputFieldから入力されたテキストを取得
        string input = HitCheckDiceField.text;

        // 入力値が数字かチェック
        if (int.TryParse(input, out int Dice20))
        {
            //敵のAC値より高いかどうか
            if (enemy.Ac <= Dice20)
            {
                //高い場合敵のHPをATK文減らす
                enemy.Hp -= ATK;
                PlayerActionText.text = "ヒット";

            }
            else if (enemy.Ac > Dice20)
            {
                //低い場合ディレイを入れて敵のターンにする(最後の処理に行く)
                PlayerActionText.text = "ミス";

            }
            PlayerActionText.enabled = true;
            Player20DiceText.enabled = true;
            Player20DiceText.text = "ダイスは" + Dice20 + "です";
            HitCheackDicePanel.SetActive(false);
            SkillPanel.SetActive(false);
            await Task.Delay(3000);
            TurnChange();
            //Invoke("TurnChange", 3.0f);
            skillnum = 0;

        }
        else
        {
            Debug.LogWarning("数字を入力してください。");
        }

        // 入力フィールドをリセット
        HitCheckDiceField.text = "";
    }
    //敵の行動
    void EnemyAction()
    {
        if (!isPlayerTurn)
        {
            //表示切替
            EnemyBattleDice6Text.enabled = false;
            EnemyActionText.enabled = true;
            NextPanel.SetActive(true);
            //ターンスキップ(何もしない)
            if (enemy.action[enemyDice6] == ActionName.Skip)
            {

                if (enemyActionCount == 0)
                {
                    //表示
                    EnemyActionText.text = "ターンスキップ";

                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }
            }
            //攻撃
            else if (enemy.action[enemyDice6] == ActionName.Attack)
            {
                if (enemyActionCount == 0)
                {

                    //表示
                    EnemyActionText.text = "命中チェック";
                    if (enemyDice20Count == 0)
                    {
                        //20面ダイスを振る
                        EnemyDice20();
                    }
                    enemyDice20Count += 1;
                    //結果表示
                    EnemyBattleDice20Text.enabled = true;
                    EnemyBattleDice20Text.text = "敵のダイスは" + enemyDice20 + "です";
                    //敵の方が大きい
                    if (enemyDice20 > player.Ac)
                    {
                        //ダメージ計算
                        player.Hp -= enemy.actionValue[enemyDice6] + enemyPlusATK;
                        //表示
                        EnemyActionText.text = enemy.actionValue[enemyDice6].ToString() + "(" + enemyPlusATK.ToString() + ")" + "ダメージ";
                    }
                    //プレイヤーのほうが大きい
                    else if (enemyDice20 <= player.Ac)
                    {
                        //表示
                        EnemyActionText.text = "ミス";
                        //TurnChange();
                    }
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }
            }
            //吸収
            else if (enemy.action[enemyDice6] == ActionName.Drain)
            {
                if (enemyActionCount == 0)
                {

                    //表示
                    EnemyActionText.text = "命中チェック";
                    if (enemyDice20Count == 0)
                    {
                        //20面ダイスを振る
                        EnemyDice20();
                    }
                    enemyDice20Count += 1;

                    //結果表示
                    EnemyBattleDice20Text.enabled = true;
                    EnemyBattleDice20Text.text = "敵のダイスは" + enemyDice20.ToString() + "です";
                    //敵の方が大きい
                    if (enemyDice20 > player.Ac)
                    {
                        //ダメージ計算
                        player.Hp -= enemy.actionValue[enemyDice6] + enemyPlusATK;
                        enemy.Hp += enemy.actionValue[enemyDice6] + enemyPlusATK;
                        //表示
                        EnemyActionText.text = enemy.actionValue[enemyDice6].ToString() + "(" + enemyPlusATK.ToString() + ")" + "吸収";
                    }
                    //プレイヤーのほうが大きい
                    else if (enemyDice20 <= player.Ac)
                    {
                        //表示
                        EnemyActionText.text = "ミス";
                    }

                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }
            }
            //回比率アップ
            else if (enemy.action[enemyDice6] == ActionName.Acup)
            {
                if (enemyActionCount == 0)
                {

                    //表示
                    EnemyActionText.text = "回避率アップ";
                    enemy.Ac += enemy.actionValue[enemyDice6];
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }
            }
            //HP回復
            else if (enemy.action[enemyDice6] == ActionName.Heal)
            {
                if (enemyActionCount == 0)
                {

                    //表示
                    EnemyActionText.text = "HP回復";
                    enemy.Hp += enemy.actionValue[enemyDice6];
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }
            }
            //自傷ダメージ
            else if (enemy.action[enemyDice6] == ActionName.SelfDamage)
            {
                if (enemyActionCount == 0)
                {

                    //表示
                    EnemyActionText.text = "自傷ダメージ";
                    enemy.Hp -= enemy.actionValue[enemyDice6];
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }
            }
            //ダメージアップ
            else if (enemy.action[enemyDice6] == ActionName.DamageUp)
            {
                if (enemyActionCount == 0)
                {

                    //表示
                    EnemyActionText.text = "ダメージアップ";
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //プレイヤーパネル
                    PlayerPanel.SetActive(true);
                }

            }
        }
    }
    //敵の全体
    IEnumerator EnemyActionUpdate()
    {
        //パネル切り替え
        SkillPanel.SetActive(false);
        PlayerPanel.SetActive(false);
        HitCheackDicePanel.SetActive(false);
        EnemyPanel.SetActive(true);
        //敵のターンの表示
        UpdateEnemyTurnText();
        //6面ダイスを振る
        if (enemyDice6Count == 0)
        {
            enemyDice6 = Random.Range(0, 6);
        }
        UpdateEnemyDice6Text();
        enemyDice6Count += 1;
        //Invoke("UpdateEnemyDice6Text", 2.0f);

        if (enemyActionCount == 0)
        {
            //表示切替
            EnemyBattleDice6Text.enabled = true;
            EnemyBattleDice20Text.enabled = false;
            EnemyActionText.enabled = false;
            NextPanel.SetActive(false);
        }
        yield return new WaitForSeconds(2f);//2秒待つ
        EnemyAction();

        //結果に応じた行動を行う
        //Invoke("EnemyAction", 2.0f);
    }

    //ディレイ用テキスト関数
    void EnemyHitText()
    {
        //表示
        EnemyActionText.text = "命中チェック";
    }
    void EnemyComboText()
    {
        EnemyActionText.text = "継続チェック";
    }

    //ディレイ
    IEnumerator Count2()
    {
        yield return new WaitForSeconds(10.0f); // 2秒待つ
    }

    //ネクストボタン
    public void NextButton()
    {
        isNext = true;
        NextPanel.SetActive(false);
        if (player.Hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //判定
    public void IsSpeedDice20()
    {
        isSpeedDice20 = true;
    }

    //敵が死んだ場合
    void EnemyDead()
    {
        if (enemy.enemynum == 1)
        {
            player.Int += 3;
            player.Hp += 20;
        }
        else if (enemy.enemynum == 2)
        {
            player.MaxHp += 20;
        }
        else if (enemy.enemynum == 3)
        {
            player.Dex += 3;
        }
        else if (enemy.enemynum == 4)
        {
            player.Str += 3;
        }
        else if (enemy.enemynum == 100)
        {
            SceneManager.LoadScene("GameClearScene");
        }
        enemyNum = 0;
        plusATK = 0;
        isSpeedDice20 = false;
        isBattle = false;
        SpeedPanel1.SetActive(true);
        SpeedPanel2.SetActive(false);
        StatusPanel.SetActive(false);
        SkillPanel.SetActive(false);
        HitCheackDicePanel.SetActive(false);
        EnemyPanel.SetActive(false);
        NextPanel.SetActive(false);
        PlayerPanel.SetActive(false);
        canvas.enabled = true;
        canvas1.enabled = false;
    }
}
