using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterBotton : MonoBehaviour
{
    public GameObject EncounterBotton_;
    public Gamemanager GameManager_;
    public Canvas canvas;
    //ボタンが押された場合
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("ON");
        //他にポップが出ているか
        if (GameManager_.IsPop()) {
            Debug.Log("Canvas:" + canvas.enabled);
        }
        //出ていないならtrueにする
        else
        {
            GameManager_.EncounterPop();
            EncounterBotton_.SetActive(true);
            canvas.enabled = true;
            Debug.Log("Canvas:" + canvas.enabled);
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
