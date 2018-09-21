using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(AudioSource))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 6.0f;
    [SerializeField]
    float runSpeed = 15.0f;

    //[SerializeField]
    //AudioClip[] footstepsArray;

    float turnSmoothTime = .2f;
    float turnSmoothVelocity;

    //AudioSource footstep;
    Transform cameraM;
    
    void Start()
    {
        //footstep = this.gameObject.GetComponent<AudioSource>();
        cameraM = Camera.main.transform;
    }
    
    void FixedUpdate()
    {
        MovePlayer();
        //PlayFootstep();
    }

    void MovePlayer()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        float speed;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraM.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed * inputDir.magnitude;
        }
        else
        {
            speed = walkSpeed * inputDir.magnitude;
        }

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    // TODO: need to change to use rigidbody

    //void PlayFootstep()
    //{
    //    if (rb.velocity.magnitude > 4.0f && !footstep.isPlaying && !isTakingStep)    // add check for on ground
    //    {
    //        // choose random clip, excluding the first one
    //        int n = Random.Range(1, footstepsArray.Length - 1);
    //        footstep.clip = footstepsArray[n];

    //        // randomizes volume and pitch for every step, increasing with walk speed
    //        footstep.volume = Mathf.Clamp(Random.Range(0.55f, 0.75f) * rb.velocity.magnitude, 0.0f, 1.0f);
    //        footstep.pitch = Random.Range(0.95f, 1.05f) * (Mathf.Clamp(rb.velocity.magnitude / 7, 1.0f, 1.5f));

    //        footstep.Play();

    //        // move clip to first index so it won't play again right away
    //        footstepsArray[n] = footstepsArray[0];
    //        footstepsArray[0] = footstep.clip;

    //        StartCoroutine(TakeStep());
    //    }
    //}

    //IEnumerator TakeStep()
    //{
    //    isTakingStep = true;

    //    // pause in between playing footstep sound, decreasing with walk speed
    //    yield return new WaitForSecondsRealtime(0.5f / (Mathf.Clamp(rb.velocity.magnitude / 7, 0.8f, 1.5f)));

    //    isTakingStep = false;
    //}
}