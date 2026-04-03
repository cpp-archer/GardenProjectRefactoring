using System.Collections;
using TMPro;
using UnityEngine;

public class Chrono : MonoBehaviour
{
    //durée du chrono
    public float duration = 30f;

    //score a atteindre
    public int targetScore = 200;

    //temps restant
    private float timeLeft;

    //panels UI de l'état (challenge reussi ou non)
    public GameObject losePanel;
    public GameObject continuePanel;

    //evite repetition du check 
    private bool challengeFinished = false;

    //compte a rebour affiché a l'ecran
    public TMP_Text timerText;

    private void Start()
    {
        //panel desactivés au début du jeu
        losePanel.SetActive(false);
        continuePanel.SetActive(false);

        //init le temps restant
        timeLeft = duration;

        //lancement de la coroutine du timer
        StartCoroutine(Timer());
    }


    private void Update()
    {
        //si challenge fini, on met plus a jour le timer
        if (challengeFinished) return;

        //décremente pour compte à rebour
        timeLeft-=Time.deltaTime;
        if(timeLeft < 0)
        {
            timeLeft = 0; //s'arrete à 0 et va pas dans les negatif
        }

        timerText.text = Mathf.Ceil(timeLeft).ToString(); //MAJ du texte de l'UI arrondi a l'entier superieur
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(duration);
       StartCoroutine(checkScore());
    }

    
    IEnumerator checkScore()
    {
        if (challengeFinished == true) //si terminé, on quitte la coroutine
        {
            yield break;
        }

        if (Score.score < targetScore) //si score insuffisant : loser
        {
            losePanel.SetActive(true);
            yield return new WaitForSeconds(3f);
        }

        else
        {
            continuePanel.SetActive(true);  //on continue la game normalement
            yield return new WaitForSeconds(3f);
            continuePanel.SetActive(false);
            timerText.text = "";
        }
        challengeFinished = true;
    }
}

