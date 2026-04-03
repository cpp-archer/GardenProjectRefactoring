using System.Collections;
using TMPro;
using UnityEngine;

public class Chrono : MonoBehaviour
{
    public float duration = 30f;
    public int targetScore = 200;

    public GameObject losePanel;
    public GameObject continuePanel;

    private bool challengeFinished = false;


    public TMP_Text timerText;
    private float timeLeft;

 

    private void Start()
    {
        losePanel.SetActive(false);
        continuePanel.SetActive(false);
        timeLeft = duration;
        StartCoroutine(Timer());

    }


    private void Update()
    {
        if (challengeFinished) return;
        timeLeft-=Time.deltaTime;
        if(timeLeft < 0)
        {
            timeLeft = 0;
        }

        timerText.text = Mathf.Ceil(timeLeft).ToString();
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(duration);
       StartCoroutine(checkScore());
    }

    IEnumerator checkScore()
    {
        if (challengeFinished == true)
        {
            yield break;
        }

        if (Score.score < targetScore)
        {
            losePanel.SetActive(true);
            yield return new WaitForSeconds(3f);
        }

        else
        {
            continuePanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            losePanel.SetActive(false);
            timerText.text = "";

        }

        challengeFinished = true;
    }

}

