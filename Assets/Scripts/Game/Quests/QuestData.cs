using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "Scriptable Objects/QuestData")]
public class QuestData : ScriptableObject
{
    public string questName;
    public string description;
}
