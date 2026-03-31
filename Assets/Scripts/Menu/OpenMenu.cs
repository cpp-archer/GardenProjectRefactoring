using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
   
    public GameObject panelMenuLautre;
    public InputActionReference openMenuActionRef;

    public AudioSource drop;
    void Start()
    {
        panelMenuLautre.SetActive(false);
    }

    public void menuClick() //pour le click souris
    {
        panelMenuLautre.SetActive(!panelMenuLautre.activeSelf);
        drop.Play();      
    }

    private void OnEnable()
    {
        openMenuActionRef.action.performed += openMenu;
    }

    private void OnDisable()
    {
        openMenuActionRef.action.performed -= openMenu;
    }

    public void openMenu(InputAction.CallbackContext context) //pour btn clavier
    {
        panelMenuLautre.SetActive(!panelMenuLautre.activeSelf);
        drop.Play();
        Debug.Log(panelMenuLautre.activeSelf);
    }

}
