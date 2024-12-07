
using UnityEngine;
using ReadyPlayerMe.Samples.QuickStart;

public class AvatarManager : MonoBehaviour
{
    public Character _char;
    public AvatarLoader avatarLoader;

    public void GetCharacter(GameObject c)
    {
        if(_char != c.GetComponent<CharacterInfo>().character)
        {
            _char = c.GetComponent<CharacterInfo>().character;
            FindObjectOfType<MainMenu>().UpdateAvatar(_char);
            Debug.Log(_char.characterName);
            LoadCharacter(_char);
        }

        
    }
    public void LoadCharacter(Character _char)
    {
        //thirdPersonLoader.LoadAvatar(_char.characterUrls);
        avatarLoader.LoadAvatar(_char.characterAvatar);
    }
}