using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextToShow : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField]
    private TMP_Text shownText;

    public SetText[] Texts;

    

    private int PageNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
        OnNext();
    }

    public void OnNext()
    {
        PageNumber ++;
        foreach(SetText Text in Texts)
        {
            if (Text.Page.Equals(PageNumber)) shownText.text = Text.showText;
        }
    }

    public void OnBack()
    {
        PageNumber--;
        foreach (SetText Text in Texts)
        {
            if (Text.Page.Equals(PageNumber)) shownText.text = Text.showText;
        }
    }
}
