using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFinishQuest : MonoBehaviour
{
    public Quest quest;
    public QuestData questData;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        quest.FinishQuest(questData);
    }
}
