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
        flowerRenderer = flower.GetComponent<Renderer>(); //on recupere le renderer de la fleur

        //svgr le material original
        originMaterial = flowerRenderer.material;

        //charge le mat
        flowerRenderer.material = green;
    }

    //remet la fleur a sont etat normal en remettant le material d'origine
    public void clearFlowerReady()
    {
        if (flowerRenderer != null)
        {
            flowerRenderer.material = originMaterial;
        }
        flowerRenderer = null;
        flowerReady = null;
    }

    //recolte la fleur en verifiant si la fleur est prete ou non
    public void HarvestFlower()
    {
        if (flowerReady == null)
        {
            return;
        }

        Score.score += 10; //incremente le score
        harvestSound.Play();

        //detruit la fleur dans la scene une fois recupere
        Destroy(flowerReady);

        flowerReady = null;
    }
}
