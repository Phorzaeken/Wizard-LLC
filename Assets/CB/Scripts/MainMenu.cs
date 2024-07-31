using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource mainMenuMusic;
    public float fadeDuration = 2.0f; // Duration for the fade-out

    public void PlayGame()
    {
        StartCoroutine(FadeOutMusicAndLoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator FadeOutMusicAndLoadScene()
    {
        float startVolume = mainMenuMusic.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            mainMenuMusic.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        mainMenuMusic.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
