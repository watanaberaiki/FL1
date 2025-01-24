using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{


    bool isEncounterpop = false;
    bool isEventpop = false;
    bool isHealpop = false;
    bool isStatuspop = false;
    public GameObject Encounterpanel;
    public GameObject Eventpanel;
    public GameObject Healpanel;
    public GameObject Statuspanel;
    // Start is called before the first frame update
    void Start()
    {
        Encounterpanel.SetActive(false);
        Eventpanel.SetActive(false);
        Healpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Encounter
    /// </summary>
    //Encounterボタンが押された場合
    public void EncounterPop()
    {
       
        //他にポップが出ているか
        if(IsPop())
        {
            Debug.Log("Pop");
        }
        //出ていないならtrueにする
        else
        {
            isEncounterpop = true;
            Encounterpanel.SetActive(true);
        }
    }
    //Encounterを閉じる場合
    public void EncounterPopShutdown()
    {
        isEncounterpop = false;
        Encounterpanel.SetActive(false);
    }
    /// <summary>
    /// Encounter
    /// </summary>


    /// <summary>
    /// Event
    /// </summary>
    //Eventボタン
    public void EventPop()
    {

        //他にポップが出ているか
        if (IsPop())
        {
            Debug.Log("Pop");
        }
        //出ていないならtrueにする
        else
        {
            isEventpop = true;
            Eventpanel.SetActive(true);
        }
    }
    //Eventを閉じる場合
    public void EventPopShutdown()
    {
        isEventpop = false;
        Eventpanel.SetActive(false);
    }
    /// <summary>
    /// Event
    /// </summary>


    /// <summary>
    /// Heal
    /// <summary>
    //Healボタン
    public void HealPop()
    {

        //他にポップが出ているか
        if (IsPop())
        {
            Debug.Log("Pop");
        }
        //出ていないならtrueにする
        else
        {
            isHealpop = true;
            Healpanel.SetActive(true);
        }
    }
    //Healを閉じる場合
    public void HealPopShutdown()
    {
        isHealpop = false;
        Healpanel.SetActive(false);
    }
    /// <summary>
    /// Heal
    /// <summary>

    //Status
    public void StatusPop()
    {

        //他にポップが出ているか
        if (IsPop())
        {
            Debug.Log("Pop");
        }
        //出ていないならtrueにする
        else
        {
           isStatuspop = true;
           Statuspanel.SetActive(true);
        }
    }
    //Statusを閉じる場合
    public void StatusPopShutdown()
    {
        isStatuspop = false;
        Statuspanel.SetActive(false);
    }

    //何かしらのポップがあるか
    public bool IsPop()
    {
        if (isEncounterpop)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
