using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    [SerializeField]
    private TMP_Text dialog; // refers to the Dialog text (uses TMP_Text becouse the GameOject is from TMP)

    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.GetPlayerJump())
        {
            dialog.text = "I'm 10 years old.";
        }
    }
}
