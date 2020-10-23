using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burger_Manager : MonoBehaviour
{

    public Level_API level;
    public GameObject bun, bunTop;
    public GameObject[] meats;
    public GameObject[] materials;
    [HideInInspector]
    public List<GameObject> chosenMaterials;

    public Transform spawnPos,spawnPos2;
    private int materialCount;

    public GameObject middle;
    private Middle _middleScript;
    private bool _isFinished;
    private bool control = true;

    public GameObject RawImage;
    public GameObject Particles, gameObject1112;
    public Camera camera2;

    public Animator animator12;
    public Camera camera;

    public GameObject panel;

    public Color _bg;

    public Material material1;

    public Image image1;

    public Stick_Controller stick_Controller;

    private int counter;


    private void Awake()
    {
        Color _bg = new Color(Random.Range(.25f, .75f), Random.Range(.25f, .75f), Random.Range(.25f, .75f), 0);
        camera2.backgroundColor = _bg;
        image1.color = _bg;
        material1.color = _bg;
        camera.backgroundColor = _bg;
        _middleScript = middle.GetComponent<Middle>();
        counter = UniversalLevel.universalLevel;
    }

    private void Update()
    {
        _isFinished = _middleScript.isFinished;
        if(_isFinished)
            isFinished();
    }
    private void OnLevelWasLoaded()
    {
        print("Counter : "+counter);
        CreateBurger();
    }

    void CreateBurger()
    {
        if(counter < 3)
        {
            materialCount = 3;

            GameObject gameObject5 = GameObject.Instantiate(bunTop, spawnPos2.position, spawnPos2.rotation);
            chosenMaterials.Add(gameObject5);

            ChooseRandomMaterial(spawnPos.position,spawnPos.rotation,4);

            ChooseRandomMeat(spawnPos.position, spawnPos.rotation, 1);

            ChooseRandomMaterial(spawnPos.position, spawnPos.rotation,2);

            GameObject gameObject1 = GameObject.Instantiate(bun, spawnPos.position, spawnPos.rotation);
            chosenMaterials.Add(gameObject1);

            Vector3 spa2 = spawnPos.transform.position;
            spa2.y += materialCount + 1;
            gameObject5.transform.position = spa2;
        }
        if((counter < 6)&&(counter >= 3))
        {
            materialCount = 4;

            GameObject gameObject5 = GameObject.Instantiate(bunTop, spawnPos2.position, spawnPos2.rotation);
            chosenMaterials.Add(gameObject5);

            ChooseRandomMaterial(spawnPos.position, spawnPos.rotation, 5);

            ChooseRandomMeat(spawnPos.position, spawnPos.rotation, 2);

            for (int i = 0; i < (materialCount - 2); i++)
            {
                ChooseRandomMaterial(spawnPos.position, spawnPos.rotation, 2 + i);
            }

            GameObject gameObject1 = GameObject.Instantiate(bun, spawnPos.position, spawnPos.rotation);
            chosenMaterials.Add(gameObject1);

            Vector3 spa2 = spawnPos.transform.position;
            spa2.y += materialCount + 1;
            gameObject5.transform.position = spa2;

        }
        if ((counter < 12) && (counter >= 6))
        {
            print("10-20");
            ChooseForLevels(5, 2);
        }
        if ((counter < 24) && (counter >= 12))
        {
            ChooseForLevels(6, 3);
        }
        if ((counter < 48) && (counter >= 24))
        {
            ChooseForLevels(7, 3);
        }
        if ((counter < 96) && (counter >= 48))
        {
            ChooseForLevels(8, 3);
        }
        if ((counter < 192) && (counter >= 96))
        {
            ChooseForLevels(9, 4);
        }
        if ((counter < 384) && (counter >= 192))
        {
            ChooseForLevels(10, 4);
        }
        if ((counter >= 384))
        {
            ChooseForLevels(11,4);
        }

    }

    public void ChooseForLevels(int MaterialCount,int moins)
    {
        materialCount = MaterialCount;

        GameObject gameObject5 = GameObject.Instantiate(bunTop, spawnPos2.position, spawnPos2.rotation);
        chosenMaterials.Add(gameObject5);

        for (int i = (MaterialCount - moins) + 1; i <= (materialCount); i++)
        {
            ChooseRandomMaterial(spawnPos.position, spawnPos.rotation, 2 + i);
        }

        ChooseRandomMeat(spawnPos.position, spawnPos.rotation, (MaterialCount-moins));

        for (int i = 0; i < (materialCount - moins); i++)
        {
            ChooseRandomMaterial(spawnPos.position, spawnPos.rotation, 2 + i);
        }

        GameObject gameObject1 = GameObject.Instantiate(bun, spawnPos.position, spawnPos.rotation);
        chosenMaterials.Add(gameObject1);

        Vector3 spa2 = spawnPos.transform.position;
        spa2.y += materialCount + 1;
        gameObject5.transform.position = spa2;

    }

    public void ChooseRandomMaterial(Vector3 position,Quaternion rotation,int which)
    {
        int x = Random.Range(0, 11);

        position.y += (which - 1);

        if(x == 6)
        {
            GameObject gameObject = GameObject.Instantiate(materials[x], position, rotation);
            gameObject.transform.Rotate(90, 0, 90);
            chosenMaterials.Add(gameObject);
        }
        else
        {
            GameObject gameObject = GameObject.Instantiate(materials[x], position, rotation);
            chosenMaterials.Add(gameObject);
        }
            


    }

    public void ChooseRandomMeat(Vector3 position, Quaternion rotation, int which)
    {
        int x = Random.Range(0, 2);

        position.y += (which +1);

        GameObject gameObject = GameObject.Instantiate(meats[x], position, rotation);

        chosenMaterials.Add(gameObject);
    }

    public void isFinished()
    {
        if (_isFinished)
        {
            if (control)
            {
                counter++;
                animator12.SetTrigger("isTrigger");
                camera.orthographic = false;
                Particles.SetActive(true);
                panel.SetActive(true);
                stick_Controller.forwardSpeed = 0;
                Went();
            }
            control = false;
        }
    }

    void Went()
    {
        for (int i = chosenMaterials.Count-1; 0 <= i; i--)
        {
            if(chosenMaterials[i].tag == "Pickle")
            {
                Quaternion rotationPos = Quaternion.Euler(0f, 90f, -90f);
                chosenMaterials[i].transform.rotation = rotationPos;
                chosenMaterials[i].GetComponent<Rigidbody>().isKinematic = false;
                chosenMaterials[i].GetComponent<BoxCollider>().isTrigger = false;
            }
            else if (chosenMaterials[i].tag == "Bun")
            {
                Quaternion rotationPos = Quaternion.Euler(-90f, 90f, -90f);
                chosenMaterials[i].transform.rotation = rotationPos;
                chosenMaterials[i].GetComponent<Rigidbody>().isKinematic = false;
                chosenMaterials[i].GetComponent<BoxCollider>().isTrigger = false;
            }
            else if (chosenMaterials[i].tag == "Bun-Top")
            {
                Quaternion rotationPos = Quaternion.Euler(180, 0f, 180f);
                chosenMaterials[i].transform.rotation = rotationPos;
                chosenMaterials[i].GetComponent<Rigidbody>().isKinematic = false;
                chosenMaterials[i].GetComponent<BoxCollider>().isTrigger = false;
            }
            else
            {
                Quaternion rotationPos = Quaternion.Euler(90f, 0f, 180f);
                chosenMaterials[i].transform.rotation = rotationPos;
                chosenMaterials[i].GetComponent<Rigidbody>().isKinematic = false;
                chosenMaterials[i].GetComponent<BoxCollider>().isTrigger = false;
            }

        }

    }
}
