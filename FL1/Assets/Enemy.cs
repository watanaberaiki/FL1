using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;



public class Enemy : MonoBehaviour
{
    //�G�̍s�����Ƃ̖��O
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

    //�X�e�[�^�X
    public int Hp = 0;
    public int Ac = 0;
    //�G�̔ԍ�
    public int enemynum = 0;

    //�G�̔ԍ����Ƃ̍s��
    public ActionName[] action =new ActionName[6];
    public int[] actionValue=new int[6];

    //�G�̔ԍ�����
    public InputField EnemyNumInputField;
    //�G�̃e�L�X�g
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
    //�G�l�~�[�̔ԍ�
    public void EnemyInputField()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = EnemyNumInputField.text;

        // ���͒l���������`�F�b�N
        if (int.TryParse(input, out int enemyNum))
        {
            enemynum = enemyNum;
            //�����̓G�̃X�e�[�^�X
            if (enemyNum == 1)
            {
                //�����X�e�[�^�X
                Hp = 15;
                Ac = 8;
                //�A�N�V�����̍s��
                action[0] = ActionName.Skip;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Drain;
                action[4] = ActionName.Drain;
                action[5] = ActionName.Acup;
                //�A�N�V�������Ƃ̒l
                actionValue[0] = 0;
                actionValue[1] = 7;
                actionValue[2] = 7;
                actionValue[3] = 5;
                actionValue[4] = 5;
                actionValue[5] = 1;
            }
            else if (enemyNum == 2)
            {
                //�����X�e�[�^�X
                Hp = 40;
                Ac = 5;
                //�A�N�V�����̍s��
                action[0] = ActionName.Skip;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.Heal;
                action[5] = ActionName.Heal;
                //�A�N�V�������Ƃ̒l
                actionValue[0] = 0;
                actionValue[1] = 5;
                actionValue[2] = 5;
                actionValue[3] = 5;
                actionValue[4] = 15;
                actionValue[5] = 15;
            }
            else if (enemyNum == 3)
            {
                //�����X�e�[�^�X
                Hp = 20;
                Ac = 7;
                //�A�N�V�����̍s��
                action[0] = ActionName.SelfDamage;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.Attack;
                action[5] = ActionName.Attack;
                //�A�N�V�������Ƃ̒l
                actionValue[0] = 5;
                actionValue[1] = 8;
                actionValue[2] = 8;
                actionValue[3] = 8;
                actionValue[4] = 8;
                actionValue[5] = 20;
            }
            else if (enemyNum == 4) {
                //�����X�e�[�^�X
                Hp = 30;
                Ac = 4;
                //�A�N�V�����̍s��
                action[0] = ActionName.SelfDamage;
                action[1] = ActionName.SelfDamage;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.DamageUp;
                action[5] = ActionName.DamageUp;
                //�A�N�V�������Ƃ̒l
                actionValue[0] = 10;
                actionValue[1] =10;
                actionValue[2] = 12;
                actionValue[3] = 12;
                actionValue[4] = 2;
                actionValue[5] = 2;
            }
            else if (enemyNum==100)
            {
                //�����X�e�[�^�X
                Hp = 70;
                Ac = 8;
                //�A�N�V�����̍s��
                action[0] = ActionName.SelfDamage;
                action[1] = ActionName.Attack;
                action[2] = ActionName.Attack;
                action[3] = ActionName.Attack;
                action[4] = ActionName.DamageUp;
                action[5] = ActionName.Attack;
                //�A�N�V�������Ƃ̒l
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
            Debug.LogWarning("��������͂��Ă��������B");
        }

        // ���̓t�B�[���h�����Z�b�g
        EnemyNumInputField.text = "";
    }
    // HP�\�����X�V����
    void UpdateHPText()
    {
        EnemyHpText.text = "HP: " + Hp.ToString();
    }
    //Ac�\���̍X�V
    void UpdateACText()
    {
        EnemyACText.text = "AC: " + Ac.ToString();
    }
    //Boss�{�^��
    public void BossButton()
    {
        //�����X�e�[�^�X
        Hp = 70;
        Ac = 8;
        //�A�N�V�����̍s��
        action[0] = ActionName.SelfDamage;
        action[1] = ActionName.Attack;
        action[2] = ActionName.Attack;
        action[3] = ActionName.Attack;
        action[4] = ActionName.DamageUp;
        action[5] = ActionName.Attack;
        //�A�N�V�������Ƃ̒l
        actionValue[0] = 5;
        actionValue[1] = 12;
        actionValue[2] = 12;
        actionValue[3] = 12;
        actionValue[4] = 3;
        actionValue[5] = 21;
    }
}
