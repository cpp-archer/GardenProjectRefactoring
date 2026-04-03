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
        StartCoroutine(GrowFlower());
    }
    IEnumerator GrowFlower()
    {
        while (transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
            yield return null;
        }

        gameObject.tag = "Ready"; //prete a etre recolté dans harvest

        //son fleur ready
        AudioSource.PlayClipAtPoint(readySound, transform.position);

        //ready pendant 7 secondes apres : explosion (destroy) particules et son qui vont avec 
        yield return new WaitForSeconds(7);

        Explode(); 
    }

    //si la lfeur n'est pas recoltée ) temps, elle explose (en faisant un son et emettant des particules)
    private void Explode()
    { 
        ParticleSystem exp = Instantiate(explosion, transform.position, Quaternion.identity);
        exp.Play();
        
        AudioSource.PlayClipAtPoint(explSound, transform.position); 
        
        Destroy(gameObject);
        Destroy(exp.gameObject, exp.main.duration); 
    }
}
