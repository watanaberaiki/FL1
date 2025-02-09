using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    //�L�����o�X
    public Canvas canvas;
    public Canvas canvas1;
    //�e�L�X�g
    public Text Eventname;
    public Text EventSuccessText;
    public Text EventFailureText;
    //����
    public InputField EventDiceField;
    //�p�l��
    public GameObject EventPanel;
    public GameObject EventDicePanel;
    public GameObject EventSuccessPanel;
    public GameObject EventFailurePanel;
    int eventNum = 0;
    //�v���C���[
    Player player;
    //����
    bool EventStart = true;
    bool EventDice = false;
    bool EventSuccessFailure = false;
    bool isEventSuccess = false;
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̏��
        GameObject obj1 = GameObject.Find("Player"); //Player���Ă����I�u�W�F�N�g��T��
        player = obj1.GetComponent<Player>(); //�t���Ă���X�N���v�g���擾
        EventPanel.SetActive(true);
        EventDicePanel.SetActive(false);
        EventSuccessPanel.SetActive(false);
        EventFailurePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�ŏ�
        if (EventStart)
        {
            if (player.eventNum == 1)
            {
                Eventname.text = "��̓����";

            }
            else if (player.eventNum == 2)
            {
                Eventname.text = "�u���C�L���O�C��";

            }
            else if (player.eventNum == 3)
            {
                Eventname.text = "���[�����O�{�[�_�[����̒E�o";

            }
            else if (player.eventNum == 4)
            {
                Eventname.text = "�����X�^�[�Ƃ̍j����";

            }
            else if (player.eventNum == 5)
            {
                Eventname.text = "�}�C���h�R���g���[��";

            }
            else if (player.eventNum == 6)
            {
                Eventname.text = "���e����";

            }
            else
            {
                Eventname.text = "�G���[";
            }
            EventPanel.SetActive(true);

        }
        //�C�x���g�̃_�C�X
        else if (EventDice)
        {
            EventPanel.SetActive(false);
            EventDicePanel.SetActive(true);
        }
        else if (EventSuccessFailure)
        {
            //����
            if (isEventSuccess)
            {
                EventDicePanel.SetActive(false);
                EventSuccessPanel.SetActive(true);
                EventFailurePanel.SetActive(false);
            }
            //���s
            else
            {
                EventDicePanel.SetActive(false);
                EventSuccessPanel.SetActive(false);
                EventFailurePanel.SetActive(true);
            }
        }
    }

    //�C�x���g�_�C�X�ɐi��
    public void EventNextDice()
    {
        EventStart = false;
        EventDice = true;
    }

    //���������s��
    public void EventNextSuccessFailure()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = EventDiceField.text;
        // ���͒l���������`�F�b�N
        if (int.TryParse(input, out int eventDiceNum))
        {

            //��Ԃ̃C�x���g
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
            //��Ԃ̃C�x���g
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
            //�O�Ԃ̃C�x���g
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
            //�l�Ԃ̃C�x���g
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
            //�ܔԂ̃C�x���g
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
            //�Z�Ԃ̃C�x���g
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

    //�߂�
    public void EventBack()
    {
        //���񂾏ꍇ
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
