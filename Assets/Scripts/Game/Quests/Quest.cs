using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{

    //TODO: bikin qest slotnya kayainven manager
    public GameObject questPrefab;
    public QuestData[] questDatas;
    public Color completeColor = new Color(0, 255, 0);
    public Color activeColor = new Color(128, 128, 128);

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
                return;
            }
       }
    }

    public void ResetQuests()
    {
        
    }
}
