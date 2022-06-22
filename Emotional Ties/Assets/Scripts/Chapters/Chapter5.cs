using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter5 : Chapter
    {
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData onEdge;

        [SerializeField] private Conversation atGunpoint;
        [SerializeField] private Conversation doNotTellMeWhatToDo;
        [SerializeField] private Conversation nothingToTalkAbout;
        [SerializeField] private Conversation heLeftMeNoChoice;
        [SerializeField] private Conversation heWasRuiningEverything;
        [SerializeField] private Conversation badIdea;
        [SerializeField] private Conversation inflictTrauma;
        [SerializeField] private Conversation shootArthur;
        
        private void AddStartingActions()
        {
            //TODO
        }
        
        public override void ConversationFinished(Conversation finishedConversation)
        {
            if (finishedConversation == preEncounterConversation)
            {
                //TODO
            }
            else if (finishedConversation == atGunpoint)
            {
                //TODO
            }
            else if (finishedConversation == doNotTellMeWhatToDo)
            {
                //TODO
            }
            else if (finishedConversation == nothingToTalkAbout)
            {
                //TODO
            }
            else if (finishedConversation == heLeftMeNoChoice)
            {
                //TODO
            }
            else if (finishedConversation == heWasRuiningEverything)
            {
                //TODO
            }
            else if (finishedConversation == badIdea)
            {
                //TODO
            }
            else if (finishedConversation == inflictTrauma)
            {
                //TODO
            }
            else if (finishedConversation == shootArthur)
            {
                EndChapter();
            }
        }
    }
}