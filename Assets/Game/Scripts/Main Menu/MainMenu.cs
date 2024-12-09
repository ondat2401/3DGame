using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject transitionIN;
    public GameObject transitionOUT;

    public GameObject touchArea;

    public TMP_Text coinDisplayText;

    private bool isTouched = false;
    private bool canPlay;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
        if (CanTouch() && !isTouched && canPlay)
        {
            isTouched = true;
            Play();
        }
    }
    public void SetCanPlay(bool _)
    {
        canPlay = _;
    }
    private void Play()
    {
        Time.timeScale = 1;
        transitionIN.gameObject.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.brush);
        Invoke("PlayGame", 1f);
    }

    public void UpdateAvatar(Character _char)
    {
        GameManager.instance.currentChar = _char;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void DisplayCoin()
    {
        coinDisplayText.text = DataManager.LoadInt("AllCoin",0).ToString();
    }
    private bool CanTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (RectTransformUtility.RectangleContainsScreenPoint(touchArea.GetComponent<RectTransform>(), touch.position, null))
                return true;
        }
        return false;
    }
}