using UnityEngine;

public class DiffSeeds : MonoBehaviour
{
    //scalabilité 
    public GameObject[] seeds;
    public int[] unlockScore;

 //voit la graine actuelle qui sera plantée
    [SerializeField] public GameObject currentSeed;

    private void Update()
    {

        int maxUnlocked = getMaxUnlockSeed();

        if (UserSeed.indexSeed > maxUnlocked)
        {
            UserSeed.indexSeed = maxUnlocked;
        }

        currentSeed = seeds[UserSeed.indexSeed];
    }
    private int getMaxUnlockSeed()
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

