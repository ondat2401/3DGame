using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //we don't need these public variables anymore. 
    //We already know the values that we want to use, we'll make them private.
    //That way whatever we change inside of the Inspector doesn't have a different value inside of our Script here.
    private float speed = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward
        // transform.Translate(0,0,1);
        //change from updating every frame to updating over time every second.
        // we're using Time to keep track of our time,
        // and we use "deltaTime" to get the change in time between all of our different frames.

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); //s*v*t
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); //s*v*t
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); //turning the vehicle
    }
}
