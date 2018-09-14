using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class cameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;


    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = player.transform.position + offset;


        //Get rid of this crap as soon as possible, worst camera I ever made LOLOLOLOLOLLOLOLLOLOLOLOLOLOLOLOL
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }

    }
}
