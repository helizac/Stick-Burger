using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    private Burger_Manager burger_Manager;
    public List<GameObject> listOfObjects,secondList;
    private int suankiObje = 0;
    public bool isFinished = false;

    [HideInInspector]
    public bool carptiMi;
    public GameObject animator;
    [HideInInspector]
    public Animator anim;
    private Level_API level;

    private Vector3 temp;

    private void Start()
    {
        carptiMi = true;
        anim = animator.GetComponent<Animator>();

        burger_Manager = GameObject.FindGameObjectWithTag("Camera").GetComponent<Burger_Manager>();

        for (int i = 0; i < burger_Manager.chosenMaterials.Count; i++)
        {
            listOfObjects.Add(burger_Manager.chosenMaterials[i]);
        }

        temp = transform.position;

        level = GetComponent<Level_API>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFinished)
        {
            if (other.gameObject.tag == listOfObjects[suankiObje].tag)
            {
                anim.SetBool("Camera", true);
                suankiObje++;
                if (suankiObje == listOfObjects.Count)
                {
                    isFinished = true;
                }
                other.gameObject.transform.parent = this.transform;
                StartCoroutine(StickToStick(other.gameObject, suankiObje));

            }
            /*if ((other.gameObject.tag == "Ground"))
            {
                objectIsGround = true;
            }
            if(suankiObje < listOfObjects.Count)
            {
                if (((other.gameObject.tag != "Ground") && (other.gameObject.tag != listOfObjects[suankiObje].tag)))
                {
                    siradakiDegil = true;
                }
            }*/

            /*for (int i = 0; i < listOfObjects.Count; i++)
            {
                secondList.Add(listOfObjects[i]);
            }
            secondList.Remove(secondList[suankiObje]);

            for (int i = 0; i < secondList.Count; i++)
            {
                if (other.gameObject.tag == secondList[i].tag)
                {
                    carptiMi = false;
                }
            }*/
        }
    }
    private IEnumerator StickToStick(GameObject other,int sayi)
    {
        temp = other.transform.position;
        yield return new WaitForSeconds(.33333f);
        temp.x = this.transform.position.x;
        temp.y = 3f - sayi;
        temp.z = this.transform.position.z;
        other.transform.position = temp;
        anim.SetBool("Camera", false);
    }

}
