using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoge : MonoBehaviour
{

    private InputManager inputManager;

    [SerializeField]
    private TMP_Text NPC_dialoge;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.GetPlayerJump())
        {
            OnNext();
        }
    }

    public void OnNext()
    {
        NPC_dialoge.text = "Ich bin 10 Jahre jung."; 
    }
}
