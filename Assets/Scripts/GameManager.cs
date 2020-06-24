using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{

    public GameObject playerScoreText;
    public GameObject restartBtn;
    public GameObject HelpCanvas;


    int score;
    public bool scoreEnableBool = false;


    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (scoreEnableBool)
        {
            AddScoreValue();
        }
    }

    private void AddScoreValue()
    {
        score += 50;
        playerScoreText.GetComponent<TextMeshProUGUI>().text = ("score:" + score.ToString());
        if (playerScoreText)
        {
            playerScoreText.GetComponent<TextMeshProUGUI>().text = ("score:" + score.ToString());
        }
        else
        {
            Debug.LogError("UI object is not properly refrenced");
        }
        scoreEnableBool = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        restartBtn.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        restartBtn.SetActive(false);
        SceneManager.LoadScene("main");
        Time.timeScale = 1;
    }

    public void OnClickOnHelpButton()
    {
        HelpCanvas.SetActive(true);
        Time.timeScale = 0;

    }


    public void CloseHelpCanvasWithOkayButton()
    {
        HelpCanvas.SetActive(false);
        Time.timeScale = 1;

    }




}
