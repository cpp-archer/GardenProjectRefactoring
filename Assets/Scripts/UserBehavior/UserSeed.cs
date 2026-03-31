
using UnityEngine;


public class UserSeed : MonoBehaviour
{
    //UI des fleurs affichées sur la cam
    public GameObject HyacinthShowSeed;
    public GameObject RoseShowSeed;
    public GameObject DandelionShowSeed;
    public GameObject BlackRoseShowSeed;
    public GameObject MargueriteShowSeed;

    //choix qu'on lira dans diffseed, ui 
    public static int indexSeed = 0;

    void Start()
    {
        //que la rose de debloquée/d'afficher au debut
        RoseShowSeed.SetActive(true);
        HyacinthShowSeed.SetActive(false);
        DandelionShowSeed.SetActive(false);
        BlackRoseShowSeed.SetActive(false);
        MargueriteShowSeed.SetActive(false);
    }

    void Update()
    {
        //affiche la fleur debloquée selon le score
        if (Score.score >=80 && Score.score < 180)
        {
            DandelionShowSeed.SetActive(true);
        }

        else if(Score.score >= 180 && Score.score < 280)
        {
            HyacinthShowSeed.SetActive(true);
        }


        else if (Score.score >= 280 && Score.score < 400)
        {
            MargueriteShowSeed.SetActive(true);
        }

        else if (Score.score >= 400)
        {
            BlackRoseShowSeed.SetActive(true);
        }
    }
}