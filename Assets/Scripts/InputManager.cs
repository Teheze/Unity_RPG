using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ConversationManager.Instance != null && ConversationManager.Instance.IsConversationActive)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                ConversationManager.Instance.SelectNextOption();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                ConversationManager.Instance.SelectPreviousOption();

            if (Input.GetKeyDown(KeyCode.Return))
                ConversationManager.Instance.PressSelectedOption();
        }
    }
}
