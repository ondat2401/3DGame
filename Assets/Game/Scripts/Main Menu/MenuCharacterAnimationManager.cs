using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacterAnimationManager : MonoBehaviour
{
    private Animator anim;
    private AvatarLoader avatarLoader;

    private bool isTyping = true;
    private void Start()
    {
        avatarLoader = GetComponent<AvatarLoader>();
        if(avatarLoader.isLoaded)
            anim = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        AnimatorController();
    }
    public void SetTypingFalse()
    {
        isTyping = false;
    }
    public void SetTypingTrue()
    {
        isTyping = true;
    }
    private void AnimatorController()
    {
        if (anim != null)
        {
            anim.SetBool("Typing", isTyping);
        }
        else
        {
            Debug.Log("cant find animator");
            anim = GetComponentInChildren<Animator>();
        }
    }
}
