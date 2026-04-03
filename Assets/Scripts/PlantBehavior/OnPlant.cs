using UnityEngine;
using UnityEngine.InputSystem;

public class OnPlant : MonoBehaviour
{
    //reference au manager des graines
    public SeedUnlockManager seeds;

    //boutonpour planter
    public InputActionReference plantSeedActionRef;

    //soon joué quand on plante
    public AudioSource plantSound;

    private void OnEnable() 
    {
        //"abonnement" a l'evenement
        plantSeedActionRef.action.performed += OnPlantSeed;
    }

    private void OnDisable()
    {
        plantSeedActionRef.action.performed -= OnPlantSeed;
    }
   
    private void OnPlantSeed(InputAction.CallbackContext callbackContext)
    {
        //on recupere la graine actuelle selectionnee
        GameObject seedPrefab = seeds.currentSeed;

        //pour la faire spawn sous l'abeille 
        Vector3 spawnSeed = transform.position; 
        spawnSeed.y -= 1.0f;

        //instancie la graine dans la scene et applique la position
        GameObject seed = Instantiate(seedPrefab); 
        seed.transform.position = spawnSeed;
      
        seed.transform.localScale = Vector3.one * 0.01f; //taille de depart pour la croissance

        //joue le son de la plantation
        plantSound.Play();
    }
}
