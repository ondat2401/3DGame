using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //we're going to keep our GameObject public, because we actually gave this variable a reference in our Script in Unity.
    //If we actually turned this to private, we won't have that reference anymore and we'd actually break our camera.
    public GameObject player;
    private Vector3 offset = new Vector3(0, 10, -16); //it can only be used inside of this class
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //So sometimes the Vehicle might move first, and then the camera might move, but other times,
    //the camera might move and then the Vehicle move,and so it creates this stuttering effect.

    // update after our Update() method happens.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //follow the player - vehicle within a certain distance
    }
}
