using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody _rb;

    //[SerializeField]
    public float walkingSpeed = 2f;

    //[SerializeField]
    public float currentSpeed;
    
    //[SerializeField]
    public float sprintSpeed = 900f;





    // Use this for initialization
    void Start()
    {

       _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

     
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 8f;
 

        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * 8f;


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);



        if ((Input.GetKeyDown(KeyCode.LeftShift) == true))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }

        _rb.AddForce(movement * currentSpeed);

    }
}