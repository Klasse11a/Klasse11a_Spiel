using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Slider VolumeSlider;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Playe("MenuMusik");
        VolumeSlider.value = FindObjectOfType<AudioManager>().masterVolume;
        VolumeSlider.onValueChanged.AddListener(delegate { FindObjectOfType<AudioManager>().Volume(VolumeSlider.value); });
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
