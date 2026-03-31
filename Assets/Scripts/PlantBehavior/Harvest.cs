using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Harvest : MonoBehaviour
{
    public InputActionReference recolteActionRef;
    private GameObject flowerReady;
    public AudioSource harvestSound;

    private Renderer flowerRenderer; //render qu'on va modifier quand on veut recolter une fleur ready
    private Material originMaterial; //save du material/render de base de la fleur

    public Material green;

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
            flowerReady = other.gameObject;
            
            originMaterial = flowerReady.GetComponent<MeshRenderer>().material; //save

            //on get le meshrender de la fleur pour apres changer son material
            flowerRenderer = flowerReady.GetComponent<MeshRenderer>();

            if (flowerRenderer != null)
            {
                flowerRenderer.material = green;          
            }

            Debug.Log("fleur ready");
        }
    }

    //on remet le mesh de base de la fleur quand plus de collision
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == flowerReady)
        {
            flowerRenderer.material = originMaterial;
        }
    }

    private void Recolte(InputAction.CallbackContext context)
    {
        if (flowerReady != null) //pour pas avoir le message debug a chaque clique de recolte
        {
            //score +10 a chaque recolte 
            Score.score += 10;
            Debug.Log(Score.score);

            Destroy(flowerReady);
            Debug.Log("Fleur récoltée");

            harvestSound.Play();
        }
    }
}

