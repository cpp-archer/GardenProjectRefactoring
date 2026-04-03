using UnityEngine;

public class UserSeedUI : MonoBehaviour
{
    public GameObject[] seedUI;
    public int[] unlockScores;
    //choix qu'on lira dans diffseed, ui 
    public static int indexSeed = 0;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < seedUI.Length; i++)
        {
            seedUI[i].SetActive(Score.score >= unlockScores[i]);
        }
    }
}