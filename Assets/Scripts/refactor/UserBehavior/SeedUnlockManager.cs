using UnityEngine;

public class SeedUnlockManager : MonoBehaviour
{
    //scalabilité 
    public GameObject[] seeds; //tableau qui contient les graines (assignées dans l'inspecteur)
    public int[] unlockScore; //score necessaire pour debloquer chaque graine

    //voit la graine actuelle qui sera plantée
    [SerializeField] public GameObject currentSeed;

    private void Update()
    {
        //récupere l'index de la derniere graine debloquée selon le score
        int maxUnlocked = getMaxUnlockSeed();

        //évite que le joueur accede a une graine non debloquee (limite à la derniere graine accessible)
        if (UserSeedUI.indexSeed > maxUnlocked)
        {
            UserSeedUI.indexSeed = maxUnlocked;
        }

        currentSeed = seeds[UserSeedUI.indexSeed]; //MAJ de la graine actuelle selon le choix du joueur
    }
    public int getMaxUnlockSeed()
    {
        //on parcourt le tableau de scode de deblocage
        for (int i = unlockScore.Length - 1; i >= 0; i--)
        {
            //et on verifie le score du joueur
            if (Score.score >= unlockScore[i]) 
            {
                return i; //retourne l'index de la graine debloquee
            }
        }
        //si pas de graine debloquee, cest la rose d'office
        return 0;
    }
}

