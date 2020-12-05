using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject MobileInput;

    public bool GetPlayerSneak; // activates sneak
    public bool GetPlayerCrouch; // activates crouch


    InputActionManager inputActions; // reference to the InputActionManager

    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {   
        // checks if script exists or creates it
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        inputActions = new InputActionManager();
    }

    private void Start()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            MobileInput.SetActive(true);
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    // return player movement 
    public Vector2 GetPlayerMovement()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
    
    // return if button pressed
    public bool GetPlayerJump()
    {
        return inputActions.Player.Jump.triggered;
    }

    private void Update()
    {
        // sets sneak ture or false
        // get if button down
        inputActions.Player.Sneak.performed += _ => GetPlayerSneak = true;
        // get if button up
        inputActions.Player.Sneak.canceled += _ => GetPlayerSneak = false;

        // sets crouch true or false
        // get if button down
        inputActions.Player.Crouch.performed += _ => GetPlayerCrouch = true;
        // get if button up
        inputActions.Player.Crouch.canceled += _ => GetPlayerCrouch = false;
    }


}
