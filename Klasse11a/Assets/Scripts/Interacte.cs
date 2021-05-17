using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacte : MonoBehaviour
{
    [SerializeField]
    private bool InteractabelObject = true;

    [ConditionalHide("InteractabelObject", true)]
    [SerializeField]
    private GameObject interactPanal;  // refers to the desktop panal of the Interaction Canvas
    [SerializeField]
    [ConditionalHide("InteractabelObject", true)]
    private GameObject interactePanalMobile; // refers to the Mobile panal of the Interaction Canvas
    [SerializeField]
    [ConditionalHide("InteractabelObject", true)]
    private GameObject nextOnMobile;
    [SerializeField]
    private GameObject vcam;    // refers to the camera that should be activated
    [SerializeField]
    private GameObject Player; // refers to the player
    [SerializeField]
    private bool AudioDialoge = false;
    [SerializeField]
    private string DialogeName;


    private bool interactionPanalIsActive = false;


    #region activate InputManager
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }
    #endregion


    // Update is called once per frame
    void Update()
    {
        // if interactionPanal is active and f is pressed and camera is not active --> camera active , Player movement disabled, animation set to idle
        if(interactionPanalIsActive && inputManager.GetPlayerInteracte() && !vcam.activeSelf)
        {
            vcam.SetActive(true);

            if (AudioDialoge) 
            {
                FindObjectOfType<AudioManager>().Playe(DialogeName);
            }
            
            Player.GetComponent<ThirdPersonUserControl>().enabled = false;
            Player.GetComponent<Animator>().SetFloat("Turn", 0);
            Player.GetComponent<Animator>().SetFloat("Forward", 0);
        }
        // if camera active and f is pressed --> camera deaktivte , enable player movement
        else if (vcam.activeSelf && inputManager.GetPlayerInteracte())
        {
            vcam.SetActive(false);

            if (AudioDialoge)
            {
                FindObjectOfType<AudioManager>().Stop(DialogeName);
            }
            
            Player.GetComponent<ThirdPersonUserControl>().enabled = true;
        }
    } 

    // checks if player walks in to trigger are near the game object 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Interaction with text
            //
            if (SystemInfo.deviceType.Equals(DeviceType.Handheld))
            {
                nextOnMobile.SetActive(true);
                interactePanalMobile.SetActive(true);
                interactionPanalIsActive = true;
            }
            else
            {
                interactPanal.SetActive(true);
                interactionPanalIsActive = true;
            }

        }
    }

    // checks if player leaves the arrea of the game object
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Interaction with text
            //
            if (SystemInfo.deviceType.Equals(DeviceType.Handheld))
            {
                nextOnMobile.SetActive(false);
                interactePanalMobile.SetActive(false);
                interactionPanalIsActive = false;
            }
            else
            {
                interactPanal.SetActive(false);
                interactionPanalIsActive = false;
            }
        }
    }
}
