using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Quest : MonoBehaviour
{

    //TODO: bikin qest slotnya kayainven manager
    public GameObject questPrefab;
    public QuestData[] questDatas;
    public Color completeColor = new Color(158, 254, 250, 255);
    public Color activeColor = new Color(128, 128, 128);

    public UnityEvent allTaskDone;
    private void OnEnable()
    {
        foreach(QuestData questData in questDatas)
        {
            CreateQuestSlot(questData);
        }
    }

    public void CreateQuestSlot(QuestData questData)
    {
        GameObject newQuestSlot = Instantiate(questPrefab);
        newQuestSlot.transform.SetParent(transform, false);

        QuestSlot questSlot = newQuestSlot.GetComponent<QuestSlot>();
        questSlot.DrawQuestSlot(questData);
    }

    public void FinishQuest(QuestData questData)
    {
        Debug.Log("Masuk Finish Quest");
       for(int i = 0; i < questDatas.Length; i++)
       {
            Debug.Log($"loop ke {i}");
            if(questData == questDatas[i])
            {
                Debug.Log($"masuk QuestData {questDatas[i].questName}");
                GameObject questSlot = transform.GetChild(i).gameObject;
                questSlot.GetComponent<Image>().color = completeColor;
                //mengecek apakah semua quest sudah selesai
                CheckQuestsStats();
                return;
            }
       }
    }

    public void CheckQuestsStats()
    {
        bool allDone=false;
        bool[] allStat = new bool[questDatas.Length];
        for (int i = 0; i < questDatas.Length; i++)
        {
            Debug.Log($"loop ke {i}");     
            Color questSlotColor = transform.GetChild(i).gameObject.GetComponent<Image>().color;
            //check per loop is it completed
                allStat[i] = questSlotColor == completeColor;
        }
        
        //check if allstat got false or not
         allDone = (allStat.Contains(false)) ?  false:  true;

        if (allDone)
        {
            Debug.Log("yay");

            //make enemy 

            //make random moving npcs
            //player have to run from enemy to save room 

            allTaskDone?.Invoke();
        }
        
    }

    public void ResetQuests()
    {
        
    }
}
