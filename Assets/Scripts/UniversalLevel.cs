using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniversalLevel : MonoBehaviour
{
    public static int universalLevel = 0;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            universalLevel++;
            SceneManager.LoadScene(2);
        }
    }
}
