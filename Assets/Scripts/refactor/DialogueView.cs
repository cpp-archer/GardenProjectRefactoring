using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    public GameObject pressX;
    public GameObject dialoguePanel;

    public TMP_Text dialogueText;

    private string fullText;
    private bool isTalking = false;


    private void Start()
    {  
        dialoguePanel.SetActive(false);
        pressX.SetActive(false);

        fullText = dialogueText.text; //svgr
        dialogueText.text = ""; //mettre à 0
    }

    public void showPressX()
    {
        if (!isTalking)
        {
            pressX.SetActive(true);
            dialoguePanel.SetActive(false);
        }

    }
    public void HideX()
    {
        pressX.SetActive(false);
    }

    public void StartDialogue()
    {
        if(isTalking) 
            return;

        pressX.SetActive(false);
        dialoguePanel.SetActive(true);
        
        StopAllCoroutines();
        StartCoroutine(capyText());
    }

    IEnumerator capyText()
    {
        isTalking = true; dialogueText.text = ""; //on recommence a chaque interaction
        foreach (char letter in fullText)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        isTalking = false;
    }
}
