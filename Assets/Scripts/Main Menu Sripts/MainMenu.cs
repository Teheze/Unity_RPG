using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayMusic("Theme");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayHoverSound()
    {
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.PlaySFX("Hover");
    }

    public void PlayClickSound()
    {
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.PlaySFX("Click");
    }
}
