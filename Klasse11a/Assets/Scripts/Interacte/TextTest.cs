using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTest : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField]
    private TMP_Text text;

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
        text.text = "sdoi jfsoxjflsdkjsdlökjsdlkjsdlkjsdlkjsdlksdjlf";
    }
}
