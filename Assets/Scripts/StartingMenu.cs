using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartingMenu : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    void Start()
    {
    }
    public void playGame() 
    {
        StartCoroutine(LevelTransition(SceneManager.GetActiveScene().buildIndex + 1));

    }



    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator LevelTransition(int levelInd)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelInd);

    }

 



}
