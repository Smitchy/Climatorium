using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrid : MonoBehaviour
{
    public GameObject mazeCube;
    public int worldWidth, worldHeight;
    public byte[,] world;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gridParent = new GameObject();
        world = new byte[worldWidth, worldHeight];
        for(int i = 0; i < worldWidth; i++)
        {
            for(int j = 0; j < worldHeight; j++)
            {
                Vector3 position = new Vector3(i, 1, j);
                GameObject block = Instantiate(mazeCube, position, Quaternion.identity);
                block.name = "Block " + i + ":" + j;
                block.transform.SetParent(gridParent.transform);
                GridCubeCollision gcc = block.AddComponent<GridCubeCollision>();
                gcc.collisionAllowed = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
