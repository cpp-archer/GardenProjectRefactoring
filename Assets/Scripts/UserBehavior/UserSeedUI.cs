using UnityEngine;

public class UserSeedUI : MonoBehaviour
{
    public GameObject[] seedUI; //3D UI des fleurs debloquees
    public int[] unlockScores;

    //choix qu'on lira dans diffseed, ui 
    public static int indexSeed = 0;

    void Start()
    {
        UpdateUI(); //maj de l'UI
    }
    void Update()
    {
        UpdateUI(); //MAJ de l'ui en fonction du score
    }

    void UpdateUI()
    {
        for (int i = 0; i < seedUI.Length; i++) //parcourt les graines de l'UI
        {
            //activation de la fleur a l'ecran si le joueur a assez de points
            seedUI[i].SetActive(Score.score >= unlockScores[i]);
        }
    }
}