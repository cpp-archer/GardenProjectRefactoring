using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public  bool inRange = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inRange = false;
        }
    }
}
