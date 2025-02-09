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
    //�L�����o�X
    public Canvas canvas;
    public Canvas canvas1;
    //�e�L�X�g
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
    //����
    public InputField EnemyNumInputField;
    public InputField PlayerDice20InputField;
    public InputField SkillInputField;
    public InputField HitCheckDiceField;
    //�p�l��
    public GameObject SpeedPanel1;
    public GameObject SpeedPanel2;
    public GameObject StatusPanel;
    public GameObject SkillPanel;
    public GameObject HitCheackDicePanel;
    public GameObject EnemyPanel;
    public GameObject NextPanel;
    public GameObject PlayerPanel;
    //�摜
    public Image attackImage;
    public Image foodImage;
    public Image trainingImage;
    public Image fireSwordImage;
    public Image heavyAttackImage;
    //�G�̔ԍ�
    int enemyNum = 0;
    //20�_�C�X
    int enemyDice20 = 0;
    int playerDice20 = 0;
    //6�_�C�X
    int enemyDice6 = 0;
    //�_�C�X�̉�
    int enemyDice6Count = 0;
    int enemyDice20Count = 0;
    int enemyComboDice20Count = 0;
    int enemyActionCount = 0;
    //�X�L���ԍ�
    int skillnum = 0;
    //ATK
    int ATK = 0;
    int plusATK = 0;
    int enemyPlusATK = 0;
    //�A���U���p
    int combo = 12;
    //�G
    Enemy enemy;
    //�v���C���[
    Player player;
    //����
    bool isSpeedDice20 = false;
    bool isPlayerTurn = false;
    bool isBattle = false;
    bool isNext = false;
    // Start is called before the first frame update
    void Start()
    {
        //�G�l�~�[�̏��
        GameObject obj = GameObject.Find("Enemy"); //Enemy���Ă����I�u�W�F�N�g��T��
        enemy = obj.GetComponent<Enemy>(); //�t���Ă���X�N���v�g���擾
        //�G�l�~�[�̏��
        GameObject obj1 = GameObject.Find("Player"); //Player���Ă����I�u�W�F�N�g��T��
        player = obj1.GetComponent<Player>(); //�t���Ă���X�N���v�g���擾
        //�����̃p�l���ݒ�
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
        //�o�g����
        if (isBattle)
        {
            //�摜�\��
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
            //ATK�̏㏸�l�\��
            UpdateATKUPText();
            UpdateEnemyATKUPText();
            //�G�ƃv���C���[�̃X�e�[�^�X�\��
            StatusPanel.SetActive(true);
            //�v���C���[�̃^�[��
            if (isPlayerTurn)
            {
                PlayerTurnText.text = "�v���C���[�̃^�[���ł�";

                NextPanel.SetActive(false);
                //�G�̃p�l��������
                EnemyPanel.SetActive(false);
                //�X�L���ԍ��������Ȃ��ꍇ
                if (skillnum >= 6 || skillnum <= 0)
                {
                    PlayerActionText.enabled = false;
                    Player20DiceText.enabled = false;
                    SkillPanel.SetActive(true);
                }
                //�U���̏ꍇ�̖����`�F�b�N
                if (skillnum == 1 || skillnum == 4 || skillnum == 5)
                {
                    //�p�l���𖳌���
                    SkillPanel.SetActive(false);
                    HitCheackDicePanel.SetActive(true);
                }
                //�X�e�[�^�X�A�b�v�v�̏ꍇ�͓G�̃^�[���ɂȂ�
                else if (skillnum == 2 || skillnum == 3)
                {
                    NextPanel.SetActive(true);

                    //�p�l���𖳌���
                    SkillPanel.SetActive(false);
                    if (isNext)
                    {
                        skillnum = 0;
                        isPlayerTurn = true;
                        isNext = false;
                        //�v���C���[�p�l��
                        PlayerPanel.SetActive(true);
                        TurnChange();
                    }

                }

            }
            //�G�̃^�[��
            else if (!isPlayerTurn)
            {
                StartCoroutine(EnemyActionUpdate());
            }
            //�G������ł��邩�ǂ���
            if (enemy.Hp <= 0)
            {
                EnemyDead();
            }
        }
        //�o�g���O
        else if (!isBattle)
        {
            UpdateHPText();
            UpdateACText();
            UpdateDice20Text();
            UpdatePlayerDice20Text();

            //�ǂ��炪��s��
            //�v���C���[����
            if (enemyDice20 <= playerDice20)
            {
                TurnText.text = "�v���C���[�̃^�[������X�^�[�g";
                isPlayerTurn = true;

            }
            //�G����
            else if (enemyDice20 > playerDice20)
            {
                TurnText.text = "�G�l�~�[�̃^�[������X�^�[�g";
                isPlayerTurn = false;
            }
            //else if(enemyDice20 == playerDice20)
            //{
            //    TurnText.text = "������x�_�C�X��U��";
            //}
        }
    }
    //�G�̔ԍ������
    public void EnemyInputField()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = EnemyNumInputField.text;

        // ���͒l���������`�F�b�N
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
            Debug.LogWarning("��������͂��Ă��������B");
        }

        // ���̓t�B�[���h�����Z�b�g
        EnemyNumInputField.text = "";
    }
    // HP�\�����X�V����
    void UpdateHPText()
    {
        HpText.text = "HP: " + enemy.Hp.ToString();
    }
    // AC�\�����X�V����
    void UpdateACText()
    {
        AcText.text = "AC: " + enemy.Ac.ToString();
    }
    // ATKUP�\�����X�V����
    void UpdateATKUPText()
    {
        ATKUPText.text = "ATKUP: " + plusATK.ToString();
    }
    // 20�ʃ_�C�X�̌��ʕ\�����X�V����
    void UpdateDice20Text()
    {
        enemyDice20Text.text = "�G�̃_�C�X����: " + enemyDice20;
    }
    //�v���C���[�̃_�C�X�̌��ʕ\��
    void UpdatePlayerDice20Text()
    {
        playerDice20Text.text = "�����̃_�C�X����: " + playerDice20;
    }
    //�G�̍s���\��
    void UpdateEnemyTurnText()
    {
        EnemyTurnText.text = "�G�̃^�[���ł�";
    }
    //�G��6�_�C�X���ʕ\��
    void UpdateEnemyDice6Text()
    {
        EnemyBattleDice6Text.text = "�G�̃_�C�X��" + (enemyDice6 + 1) + "�ł�";
    }
    //�G��ATKUP�\��
    void UpdateEnemyATKUPText()
    {
        EnemyATKUPText.text = "ATKUP:" + enemyPlusATK.ToString();
    }
    //20�_�C�X��U��
    public void EnemyDice20()
    {
        //�����_���ŏ��̃^�[������
        enemyDice20 = Random.Range(1, 21);
    }
    //�v���C���[�̌��ʂ���
    public void PlayerDice20()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = PlayerDice20InputField.text;

        // ���͒l���������`�F�b�N
        if (int.TryParse(input, out int player))
        {
            playerDice20 = player;
        }
    }
    //�p�l���̐؂�ւ�
    public void SpeedPanelChange()
    {
        SpeedPanel1.SetActive(false);
        SpeedPanel2.SetActive(true);
    }
    //�o�g���J�n
    public void BattleStart()
    {
        isBattle = true;
        SpeedPanel1.SetActive(false);
        SpeedPanel2.SetActive(false);
        if (isPlayerTurn)
        {
            //�v���C���[�p�l��
            PlayerPanel.SetActive(true);
        }
        else if (!isPlayerTurn)
        {
            PlayerPanel.SetActive(false);
        }
    }

    //�X�L���ԍ����
    public void SkillNum()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = SkillInputField.text;

        // ���͒l���������`�F�b�N
        if (int.TryParse(input, out int skill))
        {

            skillnum = skill;
            //�X�L����
            if (skillnum == 1)
            {
                ATK = 7 + player.Strnum + plusATK;
            }
            else if (skillnum == 2)
            {
                player.Hp += 10;
                PlayerActionText.enabled = true;
                PlayerActionText.text = 10 + "��";


            }
            else if (skillnum == 3)
            {
                plusATK += 2;
                PlayerActionText.enabled = true;
                PlayerActionText.text = "���̐퓬��" + 2 + "ATKUP";
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
            Debug.LogWarning("��������͂��Ă��������B");
        }

        // ���̓t�B�[���h�����Z�b�g
        SkillInputField.text = "";
    }
    //�^�[���`�F���W
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

    //�����`�F�b�N
    public async void HitCheckDice()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = HitCheckDiceField.text;

        // ���͒l���������`�F�b�N
        if (int.TryParse(input, out int Dice20))
        {
            //�G��AC�l��荂�����ǂ���
            if (enemy.Ac <= Dice20)
            {
                //�����ꍇ�G��HP��ATK�����炷
                enemy.Hp -= ATK;
                PlayerActionText.text = "�q�b�g";

            }
            else if (enemy.Ac > Dice20)
            {
                //�Ⴂ�ꍇ�f�B���C�����ēG�̃^�[���ɂ���(�Ō�̏����ɍs��)
                PlayerActionText.text = "�~�X";

            }
            PlayerActionText.enabled = true;
            Player20DiceText.enabled = true;
            Player20DiceText.text = "�_�C�X��" + Dice20 + "�ł�";
            HitCheackDicePanel.SetActive(false);
            SkillPanel.SetActive(false);
            await Task.Delay(3000);
            TurnChange();
            //Invoke("TurnChange", 3.0f);
            skillnum = 0;

        }
        else
        {
            Debug.LogWarning("��������͂��Ă��������B");
        }

        // ���̓t�B�[���h�����Z�b�g
        HitCheckDiceField.text = "";
    }
    //�G�̍s��
    void EnemyAction()
    {
        if (!isPlayerTurn)
        {
            //�\���ؑ�
            EnemyBattleDice6Text.enabled = false;
            EnemyActionText.enabled = true;
            NextPanel.SetActive(true);
            //�^�[���X�L�b�v(�������Ȃ�)
            if (enemy.action[enemyDice6] == ActionName.Skip)
            {

                if (enemyActionCount == 0)
                {
                    //�\��
                    EnemyActionText.text = "�^�[���X�L�b�v";

                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }
            }
            //�U��
            else if (enemy.action[enemyDice6] == ActionName.Attack)
            {
                if (enemyActionCount == 0)
                {

                    //�\��
                    EnemyActionText.text = "�����`�F�b�N";
                    if (enemyDice20Count == 0)
                    {
                        //20�ʃ_�C�X��U��
                        EnemyDice20();
                    }
                    enemyDice20Count += 1;
                    //���ʕ\��
                    EnemyBattleDice20Text.enabled = true;
                    EnemyBattleDice20Text.text = "�G�̃_�C�X��" + enemyDice20 + "�ł�";
                    //�G�̕����傫��
                    if (enemyDice20 > player.Ac)
                    {
                        //�_���[�W�v�Z
                        player.Hp -= enemy.actionValue[enemyDice6] + enemyPlusATK;
                        //�\��
                        EnemyActionText.text = enemy.actionValue[enemyDice6].ToString() + "(" + enemyPlusATK.ToString() + ")" + "�_���[�W";
                    }
                    //�v���C���[�̂ق����傫��
                    else if (enemyDice20 <= player.Ac)
                    {
                        //�\��
                        EnemyActionText.text = "�~�X";
                        //TurnChange();
                    }
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }
            }
            //�z��
            else if (enemy.action[enemyDice6] == ActionName.Drain)
            {
                if (enemyActionCount == 0)
                {

                    //�\��
                    EnemyActionText.text = "�����`�F�b�N";
                    if (enemyDice20Count == 0)
                    {
                        //20�ʃ_�C�X��U��
                        EnemyDice20();
                    }
                    enemyDice20Count += 1;

                    //���ʕ\��
                    EnemyBattleDice20Text.enabled = true;
                    EnemyBattleDice20Text.text = "�G�̃_�C�X��" + enemyDice20.ToString() + "�ł�";
                    //�G�̕����傫��
                    if (enemyDice20 > player.Ac)
                    {
                        //�_���[�W�v�Z
                        player.Hp -= enemy.actionValue[enemyDice6] + enemyPlusATK;
                        enemy.Hp += enemy.actionValue[enemyDice6] + enemyPlusATK;
                        //�\��
                        EnemyActionText.text = enemy.actionValue[enemyDice6].ToString() + "(" + enemyPlusATK.ToString() + ")" + "�z��";
                    }
                    //�v���C���[�̂ق����傫��
                    else if (enemyDice20 <= player.Ac)
                    {
                        //�\��
                        EnemyActionText.text = "�~�X";
                    }

                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }
            }
            //��䗦�A�b�v
            else if (enemy.action[enemyDice6] == ActionName.Acup)
            {
                if (enemyActionCount == 0)
                {

                    //�\��
                    EnemyActionText.text = "��𗦃A�b�v";
                    enemy.Ac += enemy.actionValue[enemyDice6];
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }
            }
            //HP��
            else if (enemy.action[enemyDice6] == ActionName.Heal)
            {
                if (enemyActionCount == 0)
                {

                    //�\��
                    EnemyActionText.text = "HP��";
                    enemy.Hp += enemy.actionValue[enemyDice6];
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }
            }
            //�����_���[�W
            else if (enemy.action[enemyDice6] == ActionName.SelfDamage)
            {
                if (enemyActionCount == 0)
                {

                    //�\��
                    EnemyActionText.text = "�����_���[�W";
                    enemy.Hp -= enemy.actionValue[enemyDice6];
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }
            }
            //�_���[�W�A�b�v
            else if (enemy.action[enemyDice6] == ActionName.DamageUp)
            {
                if (enemyActionCount == 0)
                {

                    //�\��
                    EnemyActionText.text = "�_���[�W�A�b�v";
                }
                enemyActionCount = 1;
                if (isNext)
                {
                    isPlayerTurn = true;
                    isNext = false;
                    //�v���C���[�p�l��
                    PlayerPanel.SetActive(true);
                }

            }
        }
    }
    //�G�̑S��
    IEnumerator EnemyActionUpdate()
    {
        //�p�l���؂�ւ�
        SkillPanel.SetActive(false);
        PlayerPanel.SetActive(false);
        HitCheackDicePanel.SetActive(false);
        EnemyPanel.SetActive(true);
        //�G�̃^�[���̕\��
        UpdateEnemyTurnText();
        //6�ʃ_�C�X��U��
        if (enemyDice6Count == 0)
        {
            enemyDice6 = Random.Range(0, 6);
        }
        UpdateEnemyDice6Text();
        enemyDice6Count += 1;
        //Invoke("UpdateEnemyDice6Text", 2.0f);

        if (enemyActionCount == 0)
        {
            //�\���ؑ�
            EnemyBattleDice6Text.enabled = true;
            EnemyBattleDice20Text.enabled = false;
            EnemyActionText.enabled = false;
            NextPanel.SetActive(false);
        }
        yield return new WaitForSeconds(2f);//2�b�҂�
        EnemyAction();

        //���ʂɉ������s�����s��
        //Invoke("EnemyAction", 2.0f);
    }

    //�f�B���C�p�e�L�X�g�֐�
    void EnemyHitText()
    {
        //�\��
        EnemyActionText.text = "�����`�F�b�N";
    }
    void EnemyComboText()
    {
        EnemyActionText.text = "�p���`�F�b�N";
    }

    //�f�B���C
    IEnumerator Count2()
    {
        yield return new WaitForSeconds(10.0f); // 2�b�҂�
    }

    //�l�N�X�g�{�^��
    public void NextButton()
    {
        isNext = true;
        NextPanel.SetActive(false);
        if (player.Hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //����
    public void IsSpeedDice20()
    {
        isSpeedDice20 = true;
    }

    //�G�����񂾏ꍇ
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
