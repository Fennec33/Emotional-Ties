using System;
using DialogueSystem;
using UnityEngine;


public class TestingText : MonoBehaviour, IConversationTrigger
{

    [SerializeField] private Conversation text;
        
        
    public void StartTest()
    {
            DialogueManager.StartDialogue(this, text);
    }

    public void ConversationFinished(Conversation finishedConversation)
    {
        throw new NotImplementedException();
    }
}
