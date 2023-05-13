using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialouge : MonoBehaviour
{
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public TextMeshProUGUI NpcName;

    

    //make dictionary character:dialouge, ganti data ui tiap dialog
    //harus urut

    public NPCDialogueData npcDialogueData;

    private int index=0;

    public GameObject continueButton;
    public float wordSpeed=0.06f;
    public bool playerIsClose;

    private void Awake()
    {
        dialogueText.text = "";        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            Debug.Log("Key E Pressed");
            if (dialoguePanel.activeInHierarchy)
            {
                RemoveText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }
        if (dialogueText.text == npcDialogueData.dialogue[index])
        {
            Debug.Log(dialogueText.text);
            Debug.Log("npc dialogue in panel is same with data");
            continueButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index= 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in npcDialogueData.dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }



    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < npcDialogueData.dialogue.Length - 1)
        {
            index++;

            UpdateUI(index);

            dialogueText.text = ""; 
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void UpdateUI(int idx)
    {
        NpcName.text = npcDialogueData.npcData[idx].npcName + " :";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        }
    }


}
