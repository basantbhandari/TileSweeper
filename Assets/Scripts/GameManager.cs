using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{

    public GameObject restartBtn;


    public static bool scoreRunning;

    // Start is called before the first frame update
    void Start()
    {
        scoreRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }





    private void OnTriggerEnter(Collider other)
    {
        restartBtn.SetActive(true);
        Debug.Log("Game over");
        Time.timeScale = 0;
        scoreRunning = false;

    }

    public void Restart() {
        restartBtn.SetActive(false);
        SceneManager.LoadScene("main");
        Time.timeScale = 1;

    }

}
