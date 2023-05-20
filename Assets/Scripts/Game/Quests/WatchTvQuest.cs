using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTvQuest : MonoBehaviour
{
    public Quest quest;
    public QuestData questData;
    public Dialogue tvNewsDialogue;

    private void Update()
    {
        if (tvNewsDialogue.doneTalking)
        {
            quest.FinishQuest(questData);
        }
    }
}
