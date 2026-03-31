using UnityEngine;


//idee de base: quand 2 graines se collident ou qu'une graine collide une fleur, ca se destroy mais ca detectait pas la fleur puis ça destroyait tout meme le chunk bref
public class SeedChunkManager : MonoBehaviour
{
    GameObject seedOnChunk;
    GameObject flowerOnChunk;

    private void OnTriggerEnter(Collider other)
    {
        //si une seed a collide le chunk
        if (other.gameObject.CompareTag("Seed"))
        {
            if (seedOnChunk == null && flowerOnChunk == null)
            {
                //on svg la seed en memoire
                seedOnChunk = other.gameObject;

                //on enlève la gravité de la graine
                seedOnChunk.GetComponent<Rigidbody>().isKinematic = true;

                //return;
            }

            //si c'est pas la seed gardée en memoire qui collide le chunk alors bye
            if (seedOnChunk != other.gameObject)
            {
                Destroy(other.gameObject);
                //Debug.Log(other.gameObject.name + " detruit par " + seedOnChunk.name);
            }
        }


        //pareil mais quand la fleur pousse deja sur le chunk
        if (other.gameObject.CompareTag("Flower"))
        {  
            flowerOnChunk = other.gameObject;
            Debug.Log("flower on chunk");

            Destroy(seedOnChunk); //detruit la graine si ya une fleur
        }
    }
}
