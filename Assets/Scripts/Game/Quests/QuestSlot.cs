using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSlot : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description; 

    public void DrawQuestSlot(QuestData questData) 
    {
        title.text = questData.questName;
        description.text = questData.description;
    }

    public void ClearQuestSlot()
    {
    }
}
