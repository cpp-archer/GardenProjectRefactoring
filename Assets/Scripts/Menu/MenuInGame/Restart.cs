using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Restart : MonoBehaviour
{

    //on remet a 0 les elements pour recommencer
   public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Score.score = 0;
        Score.pitiestopletweak = 0; //pour que win se relance au bon score
    }
}
