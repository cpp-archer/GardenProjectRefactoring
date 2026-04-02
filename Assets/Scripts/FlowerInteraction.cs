using UnityEngine;

public class FlowerInteraction : MonoBehaviour
{
    [HideInInspector] public GameObject flowerReady;
    public AudioSource harvestSound;

    private Renderer flowerRenderer; //render qu'on va modifier quand on veut recolter une fleur ready
    private Material originMaterial; //save du material/render de base de la fleur

    public Material green;

    public void SetFlowerReady(GameObject flower)
    {
        flowerReady = flower;
        flowerRenderer = flower.GetComponent<Renderer>();

        originMaterial = flowerRenderer.material;
        flowerRenderer.material = green;
    }

    public void clearFlowerReady()
    {
        if (flowerRenderer != null)
        {
            flowerRenderer.material = originMaterial;
        }
        flowerRenderer = null;
        flowerReady = null;
    }
    public void HarvestFlower()
    {
        if (flowerReady == null)
        {
            return;
        }

        Score.score += 10;
        harvestSound.Play();
        Destroy(flowerReady);
        flowerReady = null;
    }
}
