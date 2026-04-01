using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class DroneControl : MonoBehaviour
{
    public InputActionReference moveActionRef; //droite gauche devant derriere

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
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();

        //g d a r
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);

        controller.Move(direction * Time.deltaTime * moveSpeed);

        //si on bouge : son
        if (!bee.isPlaying && stickDirection != Vector2.zero)
        {
            //Debug.Log(stickDirection);
            bee.Play();
        }
        
        else if (stickDirection == Vector2.zero && bee.isPlaying)
        {
            bee.Stop();
        }
    } 

    
}
