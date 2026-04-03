using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    //panel
    public GameObject how;
    void Start()
    {
        how.SetActive(false);
    }
    public void onclick() //pour ouvrir le panel
    {
        how.SetActive(!how.activeSelf);
    }
}
