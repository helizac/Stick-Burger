using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stick_Controller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private float secretSpeed;
    [HideInInspector]
    public bool isFirstTile = true;

    public GameObject _stick;
    public Mesh mesh0, mesh1, mesh2;
    private MeshFilter meshFilter;
    private Touch touch;
    private float speedModifier;

    private bool isRelease = false;
    public GameObject gameObject12;
    private Animator animator;

    private int point;

    public Middle _middleScript;
    public Animator anim,anim2;

    public Camera camera12;

    public Text timeText;
    public int countDownInt = 62;
    public bool takingAway = false;

    private Vector3 vect;

    private void Start()
    {

        meshFilter = _stick.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh0;
        point = 5;
        if (UniversalLevel.universalLevel < 1000)
            forwardSpeed = 7.5f + (UniversalLevel.universalLevel - 1) * 0.025f;
        else
            forwardSpeed = 20.0f;
        controller = GetComponent<CharacterController>();
        secretSpeed = forwardSpeed;
        speedModifier = 0.02f;
        animator = gameObject12.GetComponent<Animator>();

        timeText.text = "00 : " + countDownInt.ToString();
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        controller.Move(direction * Time.deltaTime);



        if((!takingAway) && (countDownInt > 0))
        {
            StartCoroutine(TimerTake());
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if ((touch.deltaPosition.x > 0.1) || (touch.deltaPosition.x < -0.1))
                    {
                        vect = transform.position;
                        vect.x = touch.deltaPosition.x;
                        transform.position = vect;
                    }
                    isRelease = false;
                    break;

                case TouchPhase.Moved:
                    if (touch.phase == TouchPhase.Moved)
                    {
                        if (forwardSpeed > 0.5f)
                        {
                            if ((touch.deltaPosition.x > 0.1) || (touch.deltaPosition.x < -0.1))
                            {
                                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * Time.fixedDeltaTime, transform.position.y, transform.position.z);
                            }
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isRelease = true;
                    PlayAnimation();
                    break;
            }

        }
        CarptiMi();

    }

    public void PlayAnimation()
    {
        forwardSpeed = 0f;
        animator.SetBool("isStart", true);
        StartCoroutine(WaitForSecs());
        StartCoroutine(WaitABit());
    }


    private IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(.3333f);
        animator.SetBool("isStart", false);
        yield return new WaitForSeconds(.3333f);
    }
    private IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(1f);
        forwardSpeed = secretSpeed;
    }

    public void CarptiMi()
    {
        if (_middleScript.carptiMi == false)
        {
            point--;
            if(point == 5)
            {
                anim2.SetBool("yirmibes", true);
                Wait25();
            }
            if (point == 4)
            {
                meshFilter.mesh = mesh1;
                _middleScript.anim.SetBool("Camera", false);
                anim2.SetBool("yirmibes", true);
                Wait25();

            }

            if (point == 3)
            {
                meshFilter.mesh = mesh2;
                _middleScript.anim.SetBool("Camera", false);
                anim2.SetBool("yirmibes", true);
                Wait25();

            }

            if (point == 2)
            {
                anim2.SetBool("yirmibes", true);
                Wait25();
                GameOver();
            }
            _middleScript.carptiMi = true;

        }
    }

    public void GameOver()
    {
        anim.SetTrigger("GameOver");
        forwardSpeed = 0f;
    }
    public void GG()
    {
        SceneManager.LoadScene(2);
    }
    private IEnumerator Wait25()
    {
        yield return new WaitForSeconds(25 / 60f);
        anim2.SetBool("yirmibes", false);
    }
    private IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f);
        countDownInt--;
        timeText.text = "00 : " + countDownInt.ToString();
        if (countDownInt == 0)
        {
            GameOver();
        }
        takingAway = false;
    }
}
