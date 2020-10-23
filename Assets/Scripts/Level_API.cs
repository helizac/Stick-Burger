using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_API : MonoBehaviour
{
    public int level;
    public bool isLevelFinished;

    private void OnLevelWasLoaded()
    {
        isLevelFinished = false;
        level = UniversalLevel.universalLevel;
        print("e level bu aga : " + level.ToString());
    }

    public void NextLevel()
    {
        isLevelFinished = true;
        SceneManager.LoadScene(1);
    }
}
