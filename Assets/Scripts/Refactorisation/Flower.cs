using UnityEngine;

public class Flower : MonoBehaviour
{
    public int value = 10;

    public void Harvest()
    {
        Score.score += value;
        Destroy(gameObject);
    }
}
