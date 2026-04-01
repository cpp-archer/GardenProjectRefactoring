using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Harvest : MonoBehaviour
{
    public InputActionReference recolteActionRef;
    public AudioSource harvestSound;
    private Flower currentFlower;

    private void OnEnable()
    {
        recolteActionRef.action.performed += Recolte;
    }
    private void OnDisable()
    {
        recolteActionRef.action.performed -= Recolte;
    }
    private void OnTriggerEnter(Collider other)
    {
        Flower flower = other.GetComponent<Flower>();
        if (flower != null)
        {
            currentFlower = flower;
            other.GetComponent<FlowerVisual>().readyHighlight();
        }

    }

    //on remet le mesh de base de la fleur quand plus de collision
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Flower>() == currentFlower)
        {
            other.GetComponent<FlowerVisual>().resetHighlight();
            currentFlower = null;
        }
    }

    private void Recolte(InputAction.CallbackContext context)
    {

        if (currentFlower == null) return;

        currentFlower.Harvest();
        harvestSound.Play(); 
    }   
}

