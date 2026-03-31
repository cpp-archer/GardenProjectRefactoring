using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToHome : MonoBehaviour
{
   public void homeback()
    {
        Debug.Log("bye");
        SceneManager.LoadScene("Home");
    }
}
