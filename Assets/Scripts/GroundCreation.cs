
using UnityEngine;
public class GroundCreation : MonoBehaviour
{
    public GameObject grassPrefab;

    //parametres du terrain
    public int width = 15;
    public int height = 10;
    private float space = 0f;

    public static float ChunkSize;//pour recuperer dan scaleupseed

    void Start()
    {
        float size = grassPrefab.GetComponent<Renderer>().bounds.size.x;
        ChunkSize = size + space;

        //creation du terrain en grille avec les param et le prefab du sol
        for (int i = 0; i < width; i++)
        {
             for(int j=0; j < height; j++) 
             {
                Vector3 positionChunk = new Vector3(i * (size + space), 0, j * (size + space));
                GameObject terrain = Instantiate(grassPrefab);

                terrain.transform.position = positionChunk;

                terrain.tag = "Chunk";
            }
      
        }
    }
}
 