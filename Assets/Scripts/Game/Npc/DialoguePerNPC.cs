using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePerNPC : MonoBehaviour
{
    public GameObject dialogueUI;
    private Dialogue dialogue;
    public GameObject continueButton;

    private void Start()
    {
        dialogue = dialogueUI.GetComponent<Dialogue>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //reseting text
            dialogueUI.SetActive(false);
            dialogue.textDisplay.text = "";
            dialogue.index = 0;
            continueButton.SetActive(false);
        }
    }
}
