using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public InputField HealIF;
    public Text HealTxt;
    private static int HealNum;

    // Start is called before the first frame update
    void Start()
    {
        HealIF=GetComponent<InputField>();
        HealNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ÉqÅ[ÉãåvéZ
    void HealVolume()
    {
        HealNum = int.Parse(HealIF.text);
    }
}
