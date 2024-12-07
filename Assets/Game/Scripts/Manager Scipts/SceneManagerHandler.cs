using UnityEngine;
using EasyTransition;
using ReadyPlayerMe.Samples.QuickStart;

public class SceneManagerHandler : MonoBehaviour
{
    private void OnEnable()
    {
        // listen event from Manager
        Debug.Log("Listening event from Manager ");
        GameManager.OnGameSceneLoaded += HandleGameSceneLoaded;
        GameManager.OnNonGameSceneLoaded += HandleNonGameSceneLoaded;

       
    }

    private void OnDisable()
    {
        // unlisten event from Manager when SceneManagerHandler is disable
        GameManager.OnGameSceneLoaded -= HandleGameSceneLoaded;
        GameManager.OnNonGameSceneLoaded -= HandleNonGameSceneLoaded;

    }

    // After loaded
    private void HandleGameSceneLoaded()
    {
        GameManager.instance.SetupToStart();

        // Add more logic to load
        GameManager.instance.TransitionIN(false);
        GameManager.instance.TransitionOUT(false);

        AvatarLoader avatar = FindObjectOfType<AvatarLoader>();
        avatar.LoadAvatar(GameManager.instance.currentChar.characterAvatar);
    }

    private void HandleNonGameSceneLoaded()
    {
        GameManager.instance.CleanupComponents();
        GameManager.instance.isInitialized = false;
        // Add more logic to load
        Time.timeScale = 1;
        AvatarLoader avatar = FindObjectOfType<AvatarLoader>();
        avatar.LoadAvatar(GameManager.instance.currentChar.characterAvatar);
    }
}
