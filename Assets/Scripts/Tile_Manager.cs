using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    public GameObject gameObject1, gameObject2;
    private Transform transform1, transform2;
    public float zSpawn = 20.875f;
    public float tileLength = 36.0f;
    private Vector3 temp;
    public GameObject gameObjectRand;
    private Random_Object random_Object;
    void Start()
    {
        random_Object = gameObjectRand.GetComponent<Random_Object>();
        transform1 = gameObject1.transform;
        transform2 = gameObject2.transform;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 temp = new Vector3(0f, 0f, tileLength);
        if (other.tag == "First")
        {
            transform2.position = transform1.position + temp;
            random_Object.CallAfter(transform2.transform.position.z);
        }
        if (other.tag == "Second")
        {
            transform1.position = transform2.position + temp;
            random_Object.CallAfter(transform1.transform.position.z);
        }
    }
}
