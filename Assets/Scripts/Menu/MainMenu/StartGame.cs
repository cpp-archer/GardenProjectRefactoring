using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    //on lance la partie
    public void playbutton()
    {
        Debug.Log("go");
        SceneManager.LoadScene("Jardin");
    }
}
