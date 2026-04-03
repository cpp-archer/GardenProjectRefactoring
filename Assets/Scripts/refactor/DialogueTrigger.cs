using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //indique si le joueur est dans la zone de dialogue
    public  bool inRange = false;

    //si dans la zone alors true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inRange = true;
        }
    }

    //sinon false
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inRange = false;
        }
    }
}
