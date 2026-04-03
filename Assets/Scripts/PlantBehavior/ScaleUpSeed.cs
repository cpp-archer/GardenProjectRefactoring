using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class ScaleUpSeed : MonoBehaviour
{
    public GameObject flowerPrefab;

    //parametre croissance
    private float maxScale = 4f;
    private float growDuration = 5f;
    private float growSpeed = 0.1f;

    private bool isGrowing = false;

    void Start()
    {
        StartCoroutine(GrowSeed());
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        //si la grinae touche un chunk et qu'elle ne pousse pas deja
        if (collision.gameObject.CompareTag("Chunk") && !isGrowing)
        {
            isGrowing = true;
            CenterOfChunk(collision); //place la graine au centre
        }
    }

    IEnumerator GrowSeed()
    {
        float timer = 0f;

        //la graine pousse progressivement dans le temps jusqu'a taille 4f
        while (timer < growDuration && transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }

        //appel de la fonction quand la croissance est finie
      SpawnFlower();
    }

    //met la graine au centre du chunk selon ses dimensions
    private void CenterOfChunk(Collider chunk)
    {
        Vector3 chunkCenter = chunk.GetComponent<Renderer>().bounds.center;
        transform.position = new Vector3(chunkCenter.x, transform.position.y, chunkCenter.z);
    }


    //une fois la graine grandi au max, elle se transforme en fleur
    private void SpawnFlower()
    {
        Instantiate(flowerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
