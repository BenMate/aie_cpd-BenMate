using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void PlayMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayerLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLevelThree()
    {
        SceneManager.LoadScene(3);
    }
}