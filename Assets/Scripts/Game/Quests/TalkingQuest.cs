using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingQuest : MonoBehaviour
{
    public Quest quest;
    public QuestData questData;

    public Dialogue[] dialogues;

    private bool taskCompleted;
    private bool[] allTaskCompleted;

    private void Start()
    {
        taskCompleted= false;
    }


    //butuh revisi
    public void Update()
    {
        foreach (Dialogue dialogue in dialogues)
        {
            taskCompleted = dialogue.doneTalking;
        }
        if(taskCompleted)
        {
            quest.FinishQuest(questData);
        }
    }
    
}
