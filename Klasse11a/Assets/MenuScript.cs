using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanal; // the panal where the menu buttons are attached to

    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
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
