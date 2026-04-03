using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour
{
    public InputActionReference interactionActionRef;

    //references aux autres parties du systeme de dialogue
    private DialogueTrigger trigger;
    private DialogueView view;

    private void Awake()
    {
        //on recupere les autres composant 
        trigger = GetComponent<DialogueTrigger>();
        view = GetComponent<DialogueView>();
    }

    private void OnEnable()
    {
        //abonnement a l'input
        interactionActionRef.action.performed += interagir;
    }

    private void OnDisable()
    {
        //se desabonne
        interactionActionRef.action.performed -= interagir;
    }

    //si le joueur est dans la zone alor il peut lancer le dialogue
    private void interagir(InputAction.CallbackContext callbackContext)
    {
        if (trigger.inRange)
        {
            view.StartDialogue();
        }
        
    }
}
