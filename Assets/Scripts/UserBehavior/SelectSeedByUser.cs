
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectSeedByUser : MonoBehaviour
{
    // img + pos
    public GameObject select;
    Vector3 posInit;

    public InputActionReference selectActionRef;
    public AudioSource choseSound;

    //par defaut index sur la rose 
    private static int indexSelect=0;

    private void Start()
    {
        posInit = select.transform.localPosition; //svg de la pos initiale dans la scene
    }

    private void OnEnable()
    {
        selectActionRef.action.performed += moveCursor;
    }

    private void OnDisable()
    {
        selectActionRef.action.performed -= moveCursor;
    }

    private void moveCursor(InputAction.CallbackContext context)
    {
        choseSound.Play();

        //deplace et incrémente le curseur de selection dans l'UI
        indexSelect++;
        if (indexSelect <= 4)
        {
            select.transform.position += new Vector3(120f, 0f, 0f); //deplace
        }

        else if (indexSelect == 5) //reset initial
        {
            select.transform.localPosition = posInit;
            indexSelect = 0;
        }
       UserSeed.indexSeed = indexSelect; //POUR SYNCHRO avec le choix du player dans userseed
    }

}
