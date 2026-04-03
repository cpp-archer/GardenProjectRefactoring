using UnityEngine;

public class SeedUnlockManager : MonoBehaviour
{
    //scalabilité 
    public GameObject[] seeds;
    public int[] unlockScore;

 //voit la graine actuelle qui sera plantée
    [SerializeField] public GameObject currentSeed;

    private void Update()
    {

        int maxUnlocked = getMaxUnlockSeed();

        if (UserSeedUI.indexSeed > maxUnlocked)
        {
            UserSeedUI.indexSeed = maxUnlocked;
        }

        currentSeed = seeds[UserSeedUI.indexSeed];
    }
    public int getMaxUnlockSeed()
    {
        for (int i = unlockScore.Length - 1; i >= 0; i--)
        {
            if (Score.score >= unlockScore[i])
            {
                return i;
            }
        }
        return 0;
    }
}

