using UnityEngine;

public class FlowerVisual : MonoBehaviour
{
    private Material highlight; //render qu'on va modifier quand on veut recolter une fleur ready
    private Material originMaterial; //save du material/render de base de la fleur
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        originMaterial = rend.material;

    }

    public void readyHighlight()
    {
        rend.material = highlight;
    }

    public void resetHighlight()
    {
        rend.material = originMaterial;
    }
}
