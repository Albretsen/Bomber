using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;
    public Slider mainSlider;


    float volume1;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        //AUDIO
        mainSlider.value = PlayerPrefs.GetFloat("Volume");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        //AUDIO

	}

    public void SetVolume (float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume"));
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat("Volume", 0);
        PlayerPrefs.Save();
        mainSlider.value = PlayerPrefs.GetFloat("Volume");
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume"));
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
