using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//quitte le jeu
public class Quit : MonoBehaviour
{
    public void quitgame()
    {
        Debug.Log("bye");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
