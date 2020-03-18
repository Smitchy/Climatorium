using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                ProcessKey(vKey);
            }
        }
    }
    private void ProcessKey(KeyCode key)
    {
        float offsetSpeed = speed * Time.deltaTime;
        switch (key)
        {
            case KeyCode.A:
                Move(-gameObject.transform.right * offsetSpeed);
                break;
            case KeyCode.S:
                Move(-gameObject.transform.forward * offsetSpeed);
                break;
            case KeyCode.D:
                Move(gameObject.transform.right * offsetSpeed);
                break;
            case KeyCode.W:
                Move(gameObject.transform.forward * offsetSpeed);
                break;
        }
    }
    private void Move(Vector3 direction)
    {
        gameObject.transform.position += direction;
    }
}
