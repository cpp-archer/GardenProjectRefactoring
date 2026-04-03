using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    //UI 
    public GameObject pressX;
    public GameObject dialoguePanel;

    //texts
    public TMP_Text dialogueText;
    private string fullText;

    private bool isTalking = false;

    private void Start()
    {  
        //cache les ui au lancement
        dialoguePanel.SetActive(false);
        pressX.SetActive(false);

        fullText = dialogueText.text; //svgr du txt original
        dialogueText.text = ""; //mettre à 0 l'affichage
    }

    //affiche le pnale "press x "
    public void showPressX()
    {
        if (!isTalking)
        {
            pressX.SetActive(true);
            dialoguePanel.SetActive(false);
        }
    }

    //cache le panel press x
    public void HideX()
    {
        pressX.SetActive(false);
    }

    //lance le dialogue
     public void StartDialogue()
    {
        if(isTalking) 
            return;

        pressX.SetActive(false);
        dialoguePanel.SetActive(true);
        
        StopAllCoroutines();
        StartCoroutine(capyText());//lancement des coroutines de texte 
    }

    //coroutine de texte pour un effet ecriture (lettre par lettre)
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
