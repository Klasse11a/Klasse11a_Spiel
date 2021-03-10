using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Slider masterVolumeSlider;
    [SerializeField]
    Slider dialogeVolumeSlider;
    [SerializeField]
    Slider soundEffectsVolumeSlider;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Playe("MenuMusik");
        masterVolumeSlider.value = FindObjectOfType<AudioManager>().masterVolume;
        dialogeVolumeSlider.value = FindObjectOfType<AudioManager>().dialogeVolume;
        soundEffectsVolumeSlider.value = FindObjectOfType<AudioManager>().SoundeEffectsVolume;
    }


    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Pause("MenuMusik");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    
}
