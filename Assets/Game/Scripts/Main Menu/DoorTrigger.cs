using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DoorTrigger : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false;
    [SerializeField] private GameObject flashTransition;
    [SerializeField] private GameObject flashUI;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isOpen = true;
            anim.SetBool("open", isOpen);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOpen = false;
            anim.SetBool("open", isOpen);
            flashTransition.SetActive(true);
            flashUI.SetActive(true);
        }
    }
}
