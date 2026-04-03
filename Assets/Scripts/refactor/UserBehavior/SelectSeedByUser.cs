
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectSeedByUser : MonoBehaviour
{
    // img + pos du curseur
    public GameObject select;
    Vector3 posInit;

    //bouton (alt)
    public InputActionReference selectActionRef;

    //son joué a la selection
    public AudioSource choseSound;

    //par defaut index sur la rose 
    private static int indexSelect=0;

    //ref au manager des graines
    public SeedUnlockManager diffSeeds;

    private void Start()
    {
        posInit = select.transform.localPosition; //svgrd de la pos initiale dans la scene
    }

    private void OnEnable()
    {
        //abonnement a l'evenement
        selectActionRef.action.performed += moveCursor;
    }

    private void OnDisable()
    {
        selectActionRef.action.performed -= moveCursor;
    }

    private void moveCursor(InputAction.CallbackContext context)
    {
        choseSound.Play();

        //calcul le prochain index
        int nextIndex = indexSelect + 1;

        //recupere la derniere graine debloquee
        int maxUnlocked = diffSeeds.getMaxUnlockSeed();

        //on reset au debut si on depasse par rapport au nb de graine debloque
        if(nextIndex > maxUnlocked)
        {
            nextIndex = 0;
            select.transform.localPosition = posInit;
        }

        else
        {
            select.transform.position += new Vector3(120f, 0f, 0f); //deplace le curseur vers la droite
        }

        //MAJ de l'index
        indexSelect = nextIndex;

       UserSeedUI.indexSeed = indexSelect; //POUR SYNCHRO avec le choix du player dans UserseedUI
    }

}
