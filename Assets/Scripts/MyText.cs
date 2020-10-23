using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyText : MonoBehaviour
{
    public Text myText;
    public Level_API level_API;

    private void Start()
    {
        myText.text = level_API.level.ToString();
    }

}
