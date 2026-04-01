using UnityEngine;

public class DiffSeeds : MonoBehaviour
{
    //graines 
    public GameObject hyacinthSeed;
    public GameObject dandelionSeed;
    public GameObject roseSeed;
    public GameObject margueriteSeed;
    public GameObject blackRoseSeed;

    //voit la graine actuelle qui sera plantée
    [SerializeField] public GameObject currentSeed;

    private void Update()
    {

        int maxIndex = 0;
        if (Score.score >= 80) maxIndex = 1;
        if (Score.score >= 180) maxIndex = 2;
        if (Score.score >= 280) maxIndex = 3;
        if (Score.score >= 400) maxIndex = 4;

        if (UserSeed.indexSeed > maxIndex)
        {
            UserSeed.indexSeed = maxIndex;
        }

        switch (UserSeed.indexSeed)
        {
            case 0:
                currentSeed = roseSeed;
                break;

            case 1:
                currentSeed = dandelionSeed;
                break;

            case 2:
                currentSeed = hyacinthSeed;
                break;

            case 3:
                currentSeed = margueriteSeed;
                break;

            case 4:
                currentSeed = blackRoseSeed;
                break;

        }
    }
}
