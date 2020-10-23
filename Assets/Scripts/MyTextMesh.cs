using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTextMesh : MonoBehaviour
{
    public TextMesh myText;
    public Level_API level_API;

    private void Start()
    {
        if(level_API.level < 10)
            myText.text = "000" + level_API.level.ToString();
        else if (level_API.level < 100)
            myText.text = "00" + level_API.level.ToString();
        else if (level_API.level < 1000)
            myText.text = "0" + level_API.level.ToString();
        else
            myText.text = level_API.level.ToString();
    }

}
