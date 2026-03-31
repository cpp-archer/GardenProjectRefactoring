using UnityEngine;

public class HowToPlay : MonoBehaviour
{

    public GameObject how;
    void Start()
    {
        how.SetActive(false);
    }

    // Update is called once per frame
    public void onclick()
    {
        how.SetActive(!how.activeSelf);
    }
}
