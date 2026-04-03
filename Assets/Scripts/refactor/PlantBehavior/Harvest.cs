using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Harvest : MonoBehaviour
{
    //action sinput du joueur
    public InputActionReference recolteActionRef;
    private FlowerInteraction interaction;

    private void Awake()
    {
       interaction = GetComponent<FlowerInteraction>();
    }
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
        //si on collide une fleur ready on la met en memoire pour la recolter elle
        if (other.CompareTag("Ready"))
        {
            interaction.SetFlowerReady(other.gameObject);
        }
    }

    //on remet le mesh de base de la fleur quand plus de collision
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interaction.flowerReady)
        {
            interaction.clearFlowerReady();
        }
    }

    //on appelle la fonction de recolte quand on clique sur le bouton pour recolter
    private void Recolte(InputAction.CallbackContext context)
    {
        interaction.HarvestFlower();
    }
}

