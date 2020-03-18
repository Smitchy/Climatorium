using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCubeCollision : MonoBehaviour
{
    public bool collisionAllowed;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col + " collided with " + gameObject.name);
        if (!collisionAllowed)
        {
            col.GetComponent<ResetBall>().ResetGO();
        }
    }
}
