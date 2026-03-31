using UnityEngine;
using System.Collections;

public class SkyboxSwitcher : MonoBehaviour
{

    //dans le menu j'hesitais entre 2 skybox donc j'ai mit les 2 toute les 5sec
    public Material skybox1;
    public Material skybox2;

    void Start()
    {
        StartCoroutine(skyboxes());
    }

    IEnumerator skyboxes()
    {

        while (true)//en boucle
        {
            //jour
            RenderSettings.skybox = skybox1;
            yield return new WaitForSeconds(5);

            //nuit
            RenderSettings.skybox = skybox2;
            yield return new WaitForSeconds(5);
        }
    }
}
