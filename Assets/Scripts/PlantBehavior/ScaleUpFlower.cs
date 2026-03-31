using System.Collections;
using UnityEngine;

public class ScaleUpFlower : MonoBehaviour
{
    //scaling 
    private float maxScale = 2.5f;
    private float growSpeed = 0.15f;

    //sons
    public AudioClip readySound;
    public AudioClip explSound;

    public ParticleSystem explosion;
    void Start()
    {   
        //quand la fleur est instantiée dans la scene on lance la coroutine
        StartCoroutine(Coroutine_ScaleUp());
    }
    IEnumerator Coroutine_ScaleUp()
    {
        while (transform.localScale.x < maxScale)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }

        gameObject.tag = "Ready"; //prete a etre recolté dans harvest

        //son fleur ready
        AudioSource.PlayClipAtPoint(readySound, transform.position);
       
        //ready pendant 7 secondes apres : explosion (destroy) particules et son qui vont avec 
        yield return new WaitForSeconds(7);
       
        ParticleSystem exp = Instantiate(explosion, transform.position, Quaternion.identity);
        exp.Play();
        
        AudioSource.PlayClipAtPoint(explSound, transform.position); 
        
        Destroy(gameObject);
        Destroy(exp.gameObject, exp.main.duration); 

        Debug.Log("EXPLOSION");
    }
}
