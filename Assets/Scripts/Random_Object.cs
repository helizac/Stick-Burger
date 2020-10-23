using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Object : MonoBehaviour
{
    public List<GameObject> objectsToBeCreate;

    public GameObject gameObject1,gameObject2;


    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis;
    private Vector3 _randomPosition;
    private Burger_Manager burger_Manager;

    private void Start()
    {
        burger_Manager = gameObject1.GetComponent<Burger_Manager>();

        for (int i = 0; i < burger_Manager.chosenMaterials.Count; i++)
        {
            objectsToBeCreate.Add(burger_Manager.chosenMaterials[i]);
        }

        CallMaterials(0f);

    }

    private void Update()
    {
    }
    private void SetRanges()
    {
        Min = new Vector3(1.5f, 0.25f, .0099f);
        Max = new Vector3(6.5f, .5f, .001f);
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
    }

    public void CallMaterials(float z)
    {

        for (int i = 1;i<33;i++)
        {
            SetRanges();
            _randomPosition.x -= 4f;
            _randomPosition.y += .25f;
            _randomPosition.z += z;
            _randomPosition.z += 2.25f*i;

            int a = Random.Range(0, 4);
            {
                if(a == 0)
                {
                    gameObject2 = objectsToBeCreate[0];
                }
                else
                {
                    int x = Random.Range(0, burger_Manager.chosenMaterials.Count);
                    for (int k = 0; k < burger_Manager.chosenMaterials.Count; k++)
                    {
                        if (k == x)
                        {
                            gameObject2 = objectsToBeCreate[k];
                        }
                    }
                }
            }

            Quaternion temp = gameObject2.transform.rotation;
            if (gameObject2.tag == "Pickle")
            {
                temp = Quaternion.Euler(0, 0, 90);
            }
            else if (gameObject2.tag == "Bun-Top")
            {
                temp = Quaternion.Euler(180, 0, 180);
            }
            else
            {
                temp = Quaternion.Euler(-90, 0, 0);
            }
            Instantiate(gameObject2, _randomPosition, temp);

        }
    }

        public void CallAfter(float z)
    {

        for (int i = 1;i<17;i++)
        {
            SetRanges();
            _randomPosition.x -= 4f;
            _randomPosition.y += .25f;
            _randomPosition.z += z;
            _randomPosition.z += 2.25f*i;
            
            int x = Random.Range(0, burger_Manager.chosenMaterials.Count);
            for (int k = 0; k < burger_Manager.chosenMaterials.Count; k++)
            {
                if (k == x)
                {
                    gameObject2 = objectsToBeCreate[k];
                }
            }

            Quaternion temp = gameObject2.transform.rotation;
            if (gameObject2.tag == "Pickle")
            {
                temp = Quaternion.Euler(0, 0, 90);
            }
            else if (gameObject2.tag == "Bun-Top")
            {
                temp = Quaternion.Euler(180, 0, 180);
            }
            else
            {
                temp = Quaternion.Euler(-90, 0, 0);
            }
            Instantiate(gameObject2, _randomPosition, temp);

        }
    }

}