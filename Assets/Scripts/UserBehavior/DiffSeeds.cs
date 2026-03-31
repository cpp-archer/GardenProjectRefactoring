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
        //tant que le score est inferieur a 80, on plante que des roses
        if (Score.score < 80)
        {
            //si l'utilisateur alt sans avoit debloqué, il plantera la last debloquée
            if (UserSeed.indexSeed > 0)
            {
                UserSeed.indexSeed = 0;
            }
        }

        //dandelion
        else if (Score.score < 180)
        {
            if (UserSeed.indexSeed > 1)
            {
                UserSeed.indexSeed = 1;
            }
        }

        //hyacinth
        else if (Score.score < 280)
        {
            if (UserSeed.indexSeed > 2)
            {
                UserSeed.indexSeed = 2;
            }
        }

        //marguerite
        else if (Score.score < 400)
        {
            if (UserSeed.indexSeed > 3)
            {
                UserSeed.indexSeed = 3;
            }
        }

        //rose noire
        else if (Score.score > 400)
        {
            if (UserSeed.indexSeed > 4)
            {
                UserSeed.indexSeed = 4;
            }
        }

        //change la seed selon l'index du choix de l'utilisateur dans userseed
        if (UserSeed.indexSeed == 0)
            {
                currentSeed = roseSeed;
            }

            else if (UserSeed.indexSeed == 1)
            {
                currentSeed = dandelionSeed;
            }

            else if (UserSeed.indexSeed == 2)
            {
                currentSeed = hyacinthSeed;
            }

            else if (UserSeed.indexSeed == 3)
            {
                currentSeed = margueriteSeed;
            }

            else if (UserSeed.indexSeed == 4)
            {
                currentSeed = blackRoseSeed;
            }
        }     
    }

