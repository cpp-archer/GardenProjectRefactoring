using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class DroneControl : MonoBehaviour
{
    public InputActionReference moveActionRef; //droite gauche devant derriere

    //composant de deplacement unity
    private CharacterController controller;
    public float moveSpeed = 5f; 

    private AudioSource bee;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        bee = GetComponent<AudioSource>();  
    }
    void Update()
    {
        Movements(); //gere le deplacement
        HandleAudio();
    } 

    private void Movements()
    {
        //on recupere l'input du joueur et on deplace le joueur avec charactercontroller
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);
        controller.Move(direction * Time.deltaTime * moveSpeed);
    }

    private void HandleAudio()
    {
        //on regarde si le joueur bouge ou non en recuperant l'input du joueur
        Vector2 stick = moveActionRef.action.ReadValue<Vector2>();
        bool moving = stick!= Vector2.zero;

        //si on bouge : son
        if (moving && !bee.isPlaying)
            bee.Play();

        else if (!moving && bee.isPlaying)
            bee.Stop();
    }
}

