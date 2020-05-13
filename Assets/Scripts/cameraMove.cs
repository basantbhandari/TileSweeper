using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

   
    public float cameraSpeed;


    private float sizey;
    [SerializeField]
    private Transform bg1;
    [SerializeField]
    private Transform bg2;
    [SerializeField]
    private Transform bg3;
    [SerializeField]
    private Transform bg4;
    [SerializeField]
    private Transform bg5;

    // Start is called before the first frame update
    void Start()
    {

        sizey = 30.0f;
        InvokeRepeating("increaseCameraSpeed", 2,2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //for moving camera upward
        Vector3 targetpos = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetpos, 0.5f);
        transform.position = smoothPos;

        // for background
        if (transform.position.y > bg5.position.y) {
            bg1.position = new Vector3(bg1.position.x, bg5.position.y + sizey, bg1.position.z);
            switchBackGround();
        }




    }



    private void increaseCameraSpeed() {
        cameraSpeed += 0.0001f;

    }


    private void switchBackGround() {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = bg3;
        bg3 = bg4;
        bg4 = bg5;
        bg5 = temp;
    }



}
