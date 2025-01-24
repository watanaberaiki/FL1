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
    //Encounter�{�^���������ꂽ�ꍇ
    public void EncounterPop()
    {
       
        //���Ƀ|�b�v���o�Ă��邩
        if(IsPop())
        {
            Debug.Log("Pop");
        }
        //�o�Ă��Ȃ��Ȃ�true�ɂ���
        else
        {
            isEncounterpop = true;
            Encounterpanel.SetActive(true);
        }
    }
    //Encounter�����ꍇ
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
    //Event�{�^��
    public void EventPop()
    {

        //���Ƀ|�b�v���o�Ă��邩
        if (IsPop())
        {
            Debug.Log("Pop");
        }
        //�o�Ă��Ȃ��Ȃ�true�ɂ���
        else
        {
            isEventpop = true;
            Eventpanel.SetActive(true);
        }
    }
    //Event�����ꍇ
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
    //Heal�{�^��
    public void HealPop()
    {

        //���Ƀ|�b�v���o�Ă��邩
        if (IsPop())
        {
            Debug.Log("Pop");
        }
        //�o�Ă��Ȃ��Ȃ�true�ɂ���
        else
        {
            isHealpop = true;
            Healpanel.SetActive(true);
        }
    }
    //Heal�����ꍇ
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

        //���Ƀ|�b�v���o�Ă��邩
        if (IsPop())
        {
            Debug.Log("Pop");
        }
        //�o�Ă��Ȃ��Ȃ�true�ɂ���
        else
        {
           isStatuspop = true;
           Statuspanel.SetActive(true);
        }
    }
    //Status�����ꍇ
    public void StatusPopShutdown()
    {
        isStatuspop = false;
        Statuspanel.SetActive(false);
    }

    //��������̃|�b�v�����邩
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
