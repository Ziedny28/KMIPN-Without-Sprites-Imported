using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed=0.02f;

    public GameObject ContinueButton;
    public Animator textDisplayAnim;

    public bool doneTalking;

    private void OnEnable()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            ContinueButton.SetActive(true);
        }
        if (index == sentences.Length - 1)
        {
            doneTalking = true;
        }

    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter; 
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        textDisplayAnim.SetTrigger("Continue");
        ContinueButton.SetActive(false);
        if(index< sentences.Length-1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }

}
