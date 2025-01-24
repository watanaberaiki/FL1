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

}
