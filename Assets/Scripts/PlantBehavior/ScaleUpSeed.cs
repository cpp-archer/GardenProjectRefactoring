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
        StartCoroutine(Coroutine_ScaleUp());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Chunk") && !isGrowing)
        {
            isGrowing = true;

            //met la graine au centre du chunk
            Transform chunk = collision.transform;
            Vector3 chunkCenter = chunk.GetComponent<Renderer>().bounds.center;
            transform.position = new Vector3(chunkCenter.x, transform.position.y, chunkCenter.z);       
        }
    }

    IEnumerator Coroutine_ScaleUp()
    {
        float timer = 0f;

        //la graine pousse jusqu'a taille 4f
        while (timer < growDuration && transform.localScale.x < maxScale)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
            timer += Time.deltaTime;
        }

        //quand maxscale : fleur
        GameObject flower = Instantiate(flowerPrefab);
        flower.transform.position = transform.position; //le fleur prend la position de la graine de base    
        
        Debug.Log("graine to flower");
    }
}
