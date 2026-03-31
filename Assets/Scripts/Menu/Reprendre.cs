using UnityEngine;
using UnityEngine.UI;

public class Reprendre : MonoBehaviour
{  
    public GameObject panelOptions;
    public void reprendre()
    {
        panelOptions.SetActive(false);
    }
}
