using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nbrRecolt;
    
    private int lastScore = 0;
    private int nbr = 0;
    public static int score = 0;

    public static int pitiestopletweak = 0;

    //panel win
    public GameObject win;

    private void Start()
    {
        win.SetActive(false);
    }
    private void Update()
    {
        //mise à jour du score et du nbr de fleur récoltées sur l'UI
        if (score != lastScore)
        {
            lastScore = score;
            scoreText.text = "Score : " + score;         
            nbr ++;
            nbrRecolt.text = "Recolté : " + nbr;
        }

        //gagné
        if(score >= 400)
        {
            StartCoroutine(Showin());
            pitiestopletweak = 1;
        }
    }

    private IEnumerator Showin()
    {
        if (pitiestopletweak == 0) //pour pas que la coroutine se lance en boucle et glitch
        {
            win.SetActive(true);
            yield return new WaitForSeconds(6f); //l'image de win reste 6s 
            win.SetActive(false);
        }  
    }
}
