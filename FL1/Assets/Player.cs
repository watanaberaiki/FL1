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
        //status�����l
        Hp = 100;
        Ac = 10;
        Str = 16;
        Int = 4;
        Dex = 24;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�^�X�\���̍X�V
        UpdateHPText();
        UpdateACText();
        UpdateSTRText();
        UpdateIntText();
        UpdateDexText();
    }

    //�q�[���̌���
    public void OnAddHPButtonClicked()
    {
        // InputField������͂��ꂽ�e�L�X�g���擾
        string input = HpInputField.text;

        // ���͒l���������`�F�b�N
        if (int.TryParse(input, out int addHP))
        {
            // HP�𑝂₷
            Hp += addHP;
            //100��葝���Ȃ�
            if (Hp > 100)
            {
                Hp = 100;
            }
            // ���݂�HP���X�V
            UpdateHPText();
        }
        else
        {
            Debug.LogWarning("��������͂��Ă��������B");
        }

        // ���̓t�B�[���h�����Z�b�g
        HpInputField.text = "";
    }

    // HP�\�����X�V����
    void UpdateHPText()
    {
        HpText.text = "HP: " + Hp.ToString();
    }
    //Ac�\���̍X�V
    void UpdateACText()
    {
        AcText.text = "AC: " + Ac.ToString();
    }
    //Str�\���̍X�V
    void UpdateSTRText()
    {
        StrText.text = "STR: " + Str.ToString();
    }
    //Int�\���̍X�V
    void UpdateIntText()
    {
        IntText.text = "Int: " + Int.ToString();
    }
    //Dex�\���̍X�V
    void UpdateDexText()
    {
        DexText.text = "Dex: " + Dex.ToString();
    }
}
