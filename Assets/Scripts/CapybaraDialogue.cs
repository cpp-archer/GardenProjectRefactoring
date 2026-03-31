using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class CapybaraDialogue : MonoBehaviour
{
    public InputActionReference interactionActionRef;

    //panel x
    public GameObject dialoguePanel; 
    public TMP_Text dialogueText;
  
    private bool inRange = false;
    private bool isTalking = false;

    //panel text
    public GameObject dialogueTalk;
    public TMP_Text dialogueTextTalk;

    //svgr le txt 
    private string fullText;

    void Start()
    {
        dialoguePanel.SetActive(false);
        dialogueTalk.SetActive(false);

        fullText = dialogueTextTalk.text; //svgr
        dialogueTextTalk.text = ""; //mettre à 0
    }

    private void OnEnable()
    {
        interactionActionRef.action.performed += interagir;
    }

    private void OnDisable()
    {
        interactionActionRef.action.performed -= interagir;
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("player"))
        {
            inRange = true;
            dialoguePanel.SetActive(true); //X
            dialogueTalk.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inRange = false;
            dialogueTalk.SetActive(false);
            dialoguePanel.SetActive(false);

            StopAllCoroutines();

            isTalking = false;
            dialogueText.text = "Clique sur X";  //remise à defaut de X    
        }
    }

    private void interagir(InputAction.CallbackContext callbackContext)
    {
        if(inRange && !isTalking)
        {         
            dialoguePanel.SetActive(false);
            dialogueTalk.SetActive(true); //dialogue
            StartCoroutine(InDialoque());           
        }
    }
    IEnumerator InDialoque()
    {
        isTalking = true;
        dialogueTextTalk.text = ""; //on recommence a chaque interaction
        foreach (char letter in fullText)
        {
            dialogueTextTalk.text += letter;        
            yield return new WaitForSeconds(0.03f);
        }
        isTalking = false;
    }
}
