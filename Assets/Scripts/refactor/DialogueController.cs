using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour
{
    public InputActionReference interactionActionRef;

    private DialogueTrigger trigger;
    private DialogueView view;

    private void Awake()
    {
        trigger = GetComponent<DialogueTrigger>();
        view = GetComponent<DialogueView>();
    }

    private void OnEnable()
    {
        interactionActionRef.action.performed += interagir;
    }

    private void OnDisable()
    {
        interactionActionRef.action.performed -= interagir;
    }

    private void interagir(InputAction.CallbackContext callbackContext)
    {
        if (trigger.inRange)
        {
            view.StartDialogue();
        }
        
    }
}
