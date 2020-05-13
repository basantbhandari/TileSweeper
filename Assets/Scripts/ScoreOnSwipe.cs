using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreOnSwipe : MonoBehaviour {



    // for scoring
     int scorePlayer;
   
    public Text score_txt_player;
  


    //for hit sound

    public AudioSource hitSound;



   
  


    // Start is called before the first frame update
    void Start()
    {
        scorePlayer = 0;
     
    }


    private void Update()
    {
     
        if (!GameManager.scoreRunning)
        {
            // stop updating
            

            Debug.Log(GameManager.scoreRunning);

            Debug.Log(" not Scoring");
        }
        else {

            Debug.Log("Scoring");
            scorePlayer = scorePlayer + 5;
            score_txt_player.text = scorePlayer.ToString();

        }



    }



    //when mouse click
    private void OnMouseDown() {


       




        // for hitting on tile
        Debug.Log("tile is clicked =" + gameObject);
        gameObject.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = false;
        hitSound.Play();
      
        Debug.Log("object is deactivated");

        MonoBehaviour basant = Camera.main.GetComponent<MonoBehaviour>();
        basant.StartCoroutine(ReAppearObjectAfter2Sec());








    }






    public IEnumerator ReAppearObjectAfter2Sec() {

        
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("object is reactivated after 2 seconds");





    }

  











}
