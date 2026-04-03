using UnityEngine;
using UnityEngine.UI;


//Reprendre le jeu si mit en pause
public class Reprendre : MonoBehaviour
{  
    public GameObject panelOptions;
    public void reprendre()
    {
        panelOptions.SetActive(false);
    }
}
