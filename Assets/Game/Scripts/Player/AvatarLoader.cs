using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLoader : MonoBehaviour
{
    private readonly Vector3 avatarPositionOffset = new Vector3(0, -0.08f, 0);
    public RuntimeAnimatorController animatorController;
    [SerializeField]
    private GameObject previewAvatar;
    private GameObject avatar;
    public bool isLoaded = false;
    public void LoadAvatar(GameObject targetAvatar)
    {
        if(isLoaded)
            isLoaded = false;

        if (avatar != null)
        {
            Destroy(avatar);
        }
        Destroy(previewAvatar);
        avatar = Instantiate(targetAvatar);
        // Re-parent and reset transforms
        avatar.AddComponent<PlayerAnimationTrigger>();
        SetLayerRecursively(avatar, "Player");

        avatar.transform.parent = transform;
        avatar.transform.localPosition = avatarPositionOffset;
        avatar.transform.localRotation = Quaternion.Euler(0, 0, 0);
        avatar.transform.localScale = new Vector3(1, 1, 1);

        avatar.GetComponent<Animator>().runtimeAnimatorController = animatorController;

        isLoaded = true;
    }
    void SetLayerRecursively(GameObject obj, String newLayer)
    {
        obj.layer = LayerMask.NameToLayer(newLayer);
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
