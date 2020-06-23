using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnSwipe : MonoBehaviour {




   
    [SerializeField] AudioSource hitSound;

    [SerializeField] float maxTime = 0.5f;
    [SerializeField] float minSwipeDist = 50f;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDistances;
    float swipeTime;
    bool swiped = false;




    private void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            } 
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;
                swipeDistances = (endPos - startPos).magnitude;
                swipeTime = (endTime - startTime);
                if (swipeTime < maxTime && swipeDistances > minSwipeDist)
                {
                    swiped = true;
                }
            }
        }

    }
  


    //when mouse click
    void OnMouseDown()
    {

        if (swiped)
        {
            Vector2 distance = endPos - startPos;
            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                // for black card
                if (distance.x > 0)
                {
                    //right swipe(clubs) 
                    if (gameObject.CompareTag("clubs"))
                    {
                        Debug.Log("right swipe");
                        EventsOnSwipe();
                    }

                }
                if (distance.x < 0)
                {
                    // left swipe (spades)
                    if (gameObject.CompareTag("spades"))
                    {
                        Debug.Log("left swipe");
                        EventsOnSwipe();
                    }
                }
            }
            else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
            {
                // for red cards
                if (distance.y > 0)
                {
                    //up swipe(diamonds)
                    if (gameObject.CompareTag("diamonds"))
                    {
                        Debug.Log("up swipe");
                        EventsOnSwipe();

                    }
                }
                if (distance.y < 0)
                {
                    // down swipe (hearts)
                    if (gameObject.CompareTag("hearts"))
                    {
                        Debug.Log("down swipe");
                        EventsOnSwipe();
                      
                    }
                }
            }

        }
    }







    private void EventsOnSwipe()
    {
        // for hitting on tile
        GameManager myGameManager = FindObjectOfType<GameManager>();
        if (myGameManager)
        {
            myGameManager.scoreEnableBool = true;
        }
        gameObject.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = false;
        hitSound.Play();
        MonoBehaviour mainCamera = Camera.main.GetComponent<MonoBehaviour>();
        mainCamera.StartCoroutine(ReAppearObjectAfter2Sec());
    }



    public IEnumerator ReAppearObjectAfter2Sec() 
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = true;
    }

  











}
