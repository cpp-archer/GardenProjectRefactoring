
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

    public SeedUnlockManager diffSeeds;
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

        int nextIndex = indexSelect + 1;
        int maxUnlocked = diffSeeds.getMaxUnlockSeed();

        if(nextIndex > maxUnlocked)
        {
            nextIndex = 0;

            select.transform.localPosition = posInit;

        }
        else
        {
            select.transform.position += new Vector3(120f, 0f, 0f); //deplace

        }

        indexSelect = nextIndex;

       UserSeedUI.indexSeed = indexSelect; //POUR SYNCHRO avec le choix du player dans userseed
    }

}
