using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public bool GetPlayerSneak;
    public bool GetPlayerCrouch;


    InputActionManager inputActions;

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

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
    
    public bool GetPlayerJump()
    {
        return inputActions.Player.Jump.triggered;
    }

    private void Update()
    {
        inputActions.Player.Sneak.performed += _ => GetPlayerSneak = true;
        inputActions.Player.Sneak.canceled += _ => GetPlayerSneak = false;

        inputActions.Player.Crouch.performed += _ => GetPlayerCrouch = true;
        inputActions.Player.Crouch.canceled += _ => GetPlayerCrouch = false;
    }


}
