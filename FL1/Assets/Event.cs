using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    //キャンバス
    public Canvas canvas;
    public Canvas canvas1;
    //テキスト
    public Text Eventname;
    public Text EventSuccessText;
    public Text EventFailureText;
    //入力
    public InputField EventDiceField;
    //パネル
    public GameObject EventPanel;
    public GameObject EventDicePanel;
    public GameObject EventSuccessPanel;
    public GameObject EventFailurePanel;
    int eventNum = 0;
    //プレイヤー
    Player player;
    //判定
    bool EventStart = true;
    bool EventDice = false;
    bool EventSuccessFailure = false;
    bool isEventSuccess = false;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの情報
        GameObject obj1 = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        player = obj1.GetComponent<Player>(); //付いているスクリプトを取得
        EventPanel.SetActive(true);
        EventDicePanel.SetActive(false);
        EventSuccessPanel.SetActive(false);
        EventFailurePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //最初
        if (EventStart)
        {
            if (player.eventNum == 1)
            {
                Eventname.text = "謎の謎解き";

            }
            else if (player.eventNum == 2)
            {
                Eventname.text = "ブレイキングイン";

            }
            else if (player.eventNum == 3)
            {
                Eventname.text = "ローリングボーダーからの脱出";

            }
            else if (player.eventNum == 4)
            {
                Eventname.text = "モンスターとの綱引き";

            }
            else if (player.eventNum == 5)
            {
                Eventname.text = "マインドコントロール";

            }
            else if (player.eventNum == 6)
            {
                Eventname.text = "爆弾解除";

            }
            else
            {
                Eventname.text = "エラー";
            }
            EventPanel.SetActive(true);

        }
        //イベントのダイス
        else if (EventDice)
        {
            EventPanel.SetActive(false);
            EventDicePanel.SetActive(true);
        }
        else if (EventSuccessFailure)
        {
            //成功
            if (isEventSuccess)
            {
                EventDicePanel.SetActive(false);
                EventSuccessPanel.SetActive(true);
                EventFailurePanel.SetActive(false);
            }
            //失敗
            else
            {
                EventDicePanel.SetActive(false);
                EventSuccessPanel.SetActive(false);
                EventFailurePanel.SetActive(true);
            }
        }
    }

    //イベントダイスに進む
    public void EventNextDice()
    {
        EventStart = false;
        EventDice = true;
    }

    //成功か失敗か
    public void EventNextSuccessFailure()
    {
        // InputFieldから入力されたテキストを取得
        string input = EventDiceField.text;
        // 入力値が数字かチェック
        if (int.TryParse(input, out int eventDiceNum))
        {

            //一番のイベント
            if (player.eventNum == 1)
            {

                if (eventDiceNum + player.Intnum >= 5)
                {
                    player.Int += 2;
                    EventSuccessText.text = eventDiceNum + "+" + "(" + player.Intnum + ")" + "=" + (eventDiceNum + player.Intnum);
                    isEventSuccess = true;

                }
                else
                {
                    player.Hp -= 15;
                    EventFailureText.text = eventDiceNum + "+" + "(" + player.Intnum + ")" + "=" + (eventDiceNum + player.Intnum);
                    isEventSuccess = false;
                    

                }
            }
            //二番のイベント
            else if (player.eventNum == 2)
            {
                if (eventDiceNum + player.Strnum >= 5)
                {
                    isEventSuccess = true;
                    EventSuccessText.text = eventDiceNum + "+" + "(" + player.Strnum + ")" + "=" + (eventDiceNum + player.Strnum);
                    player.Hp += 25;
                }
                else
                {
                    isEventSuccess = false;
                    EventFailureText.text = eventDiceNum + "+" + "(" + player.Strnum + ")" + "=" + (eventDiceNum + player.Strnum);
                    player.Hp -= 15;
                }
            }
            //三番のイベント
            else if (player.eventNum == 3)
            {
                if (eventDiceNum + player.Strnum + player.Dexnum >= 10)
                {
                    isEventSuccess = true;
                    EventSuccessText.text = eventDiceNum + "+" + "(" + (player.Strnum + player.Dexnum) + ")" + "=" + (eventDiceNum + player.Strnum + player.Dexnum);
                    player.Dex += 4;
                    player.Str += 1;
                }
                else
                {
                    isEventSuccess = false;
                    EventFailureText.text = eventDiceNum + "+" + "(" + (player.Strnum + player.Dexnum) + ")" + "=" + (eventDiceNum + player.Strnum + player.Dexnum);
                    player.Hp -= 30;
                    player.Dex -= 1;
                }
            }
            //四番のイベント
            else if (player.eventNum == 4)
            {
                if (eventDiceNum + player.Strnum >= 10)
                {
                    isEventSuccess = true;
                    EventSuccessText.text = eventDiceNum + "+" + "(" + player.Strnum + ")" + "=" + (eventDiceNum + player.Strnum);
                    player.Str += 5;
                }
                else
                {
                    isEventSuccess = false;
                    EventFailureText.text = eventDiceNum + "+" + "(" + player.Strnum + ")" + "=" + (eventDiceNum + player.Strnum);
                    player.Ac -= 1;

                }
            }
            //五番のイベント
            else if (player.eventNum == 5)
            {
                if (eventDiceNum + player.Intnum >= 15)
                {
                    isEventSuccess = true;
                    EventSuccessText.text = eventDiceNum + "+" + "(" + player.Intnum + ")" + "=" + (eventDiceNum + player.Intnum);
                    player.Int += 7;
                }
                else
                {
                    isEventSuccess = false;
                    EventFailureText.text = eventDiceNum + "+" + "(" + player.Intnum + ")" + "=" + (eventDiceNum + player.Intnum);
                    player.Int -= 4;

                }
            }
            //六番のイベント
            else if (player.eventNum == 6)
            {
                if (eventDiceNum + player.Dexnum + player.Intnum >= 20)
                {
                    isEventSuccess = true;
                    EventSuccessText.text = eventDiceNum + "+" + "(" + (player.Dexnum + player.Intnum) + ")" + "=" + (eventDiceNum + player.Dexnum + player.Intnum);
                    player.Dex += 6;
                    player.Int += 3;
                }
                else
                {
                    isEventSuccess = false;
                    EventFailureText.text = eventDiceNum + "+" + "(" + (player.Dexnum + player.Intnum) + ")" + "=" + (eventDiceNum + player.Dexnum + player.Intnum);
                    player.Hp -= 70;
                }
            }
            EventDice = false;
            EventSuccessFailure = true;
        }
    }

    //戻る
    public void EventBack()
    {
        //死んだ場合
        if (player.Hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        canvas.enabled = true;
        canvas1.enabled = false;
        EventPanel.SetActive(true);
        EventDicePanel.SetActive(false);
        EventSuccessPanel.SetActive(false);
        EventFailurePanel.SetActive(false);
        EventStart = true;
    }
}
