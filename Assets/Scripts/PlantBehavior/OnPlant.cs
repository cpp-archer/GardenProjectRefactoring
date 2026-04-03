using UnityEngine;
using UnityEngine.InputSystem;

public class OnPlant : MonoBehaviour
{
    public SeedUnlockManager seeds;
    public InputActionReference plantSeedActionRef;

    public AudioSource plantSound;

    private void OnEnable() 
    {
        plantSeedActionRef.action.performed += OnPlantSeed;
    }

    private void OnDisable()
    {
        plantSeedActionRef.action.performed -= OnPlantSeed;
    }
   
    private void OnPlantSeed(InputAction.CallbackContext callbackContext)
    {
        GameObject seedPrefab = seeds.currentSeed;
        //Debug.Log("plante");

        Vector3 spawnSeed = transform.position; //pour le faire spawn sous l'abeille mais en dessous
        spawnSeed.y -= 1.0f;

        GameObject seed = Instantiate(seedPrefab); 
        seed.transform.position = spawnSeed;
        seed.transform.localScale = Vector3.one * 0.01f; //taille de depart mais jpeux l'enlever

        plantSound.Play();
    }
}
