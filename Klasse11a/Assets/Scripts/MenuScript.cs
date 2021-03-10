using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanal; // the panal where the menu buttons are attached to
    [SerializeField]
    GameObject optionPanal;
    [SerializeField]
    Slider masterVolumeSlider;
    [SerializeField]
    Slider dialogeVolumeSlider;
    [SerializeField]
    Slider soundEffectsVolumeSlider;

    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
        masterVolumeSlider.value = FindObjectOfType<AudioManager>().masterVolume;
        dialogeVolumeSlider.value = FindObjectOfType<AudioManager>().dialogeVolume;
        soundEffectsVolumeSlider.value = FindObjectOfType<AudioManager>().SoundeEffectsVolume;
        optionPanal.SetActive(false);
        menuPanal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if pressed ESC and menuPanal not acitve active Menu gets opend
        if (inputManager.GetOpenMenu() && !menuPanal.activeSelf)
        {
            
            menuPanal.SetActive(true);
        }
        // if pressed ESC and menuPanal is acitve active Menu gets closed
        else if (inputManager.GetOpenMenu() && menuPanal.activeSelf)
        {
            menuPanal.SetActive(false);
        }

        Debug.Log(FindObjectOfType<AudioManager>().masterVolume);
        
    }
    // loads Home scene
    public void OnHome()
    {
        SceneManager.LoadScene("Home");
    }
    // closes game
    public void OnLeaveGame()
    {
        Application.Quit();
    }
}
