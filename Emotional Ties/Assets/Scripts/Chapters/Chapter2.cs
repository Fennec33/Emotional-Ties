using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter2 : Chapter
    {
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData stress;
        [SerializeField] private AspectData impatience;
        [SerializeField] private AspectData pride;
        [SerializeField] private AspectData superiorityComplex;

        [SerializeField] private Conversation stillOnPhone;
        [SerializeField] private Conversation stillOnPhoneRepeat;
        [SerializeField] private Conversation endPhoneCall;
        [SerializeField] private Conversation calmsDown;
        [SerializeField] private Conversation getsStressedAgain;
        [SerializeField] private Conversation stressedOut;
        [SerializeField] private Conversation brideAndGroom;
        [SerializeField] private Conversation professionalRelationship;
        [SerializeField] private Conversation professionalRelationshipRepeat;
        [SerializeField] private Conversation honestRelationship;
        [SerializeField] private Conversation drugExplanation;
        [SerializeField] private Conversation feelingSuperior;
        [SerializeField] private Conversation anyoneWantMichaelDead;
        [SerializeField] private Conversation noBooks;
        [SerializeField] private Conversation noBooksRepeat;
        [SerializeField] private Conversation bookRant;
        [SerializeField] private Conversation endConversation;
        
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
            else if (finishedConversation == stillOnPhone)
            {
                //TODO
            }
            else if (finishedConversation == stillOnPhoneRepeat)
            {
                //TODO
            }
            else if (finishedConversation == endPhoneCall)
            {
                //TODO
            }
            else if (finishedConversation == calmsDown)
            {
                //TODO
            }
            else if (finishedConversation == getsStressedAgain)
            {
                //TODO
            }
            else if (finishedConversation == stressedOut)
            {
                //TODO
            }
            else if (finishedConversation == brideAndGroom)
            {
                //TODO
            }
            else if (finishedConversation == professionalRelationship)
            {
                //TODO
            }
            else if (finishedConversation == professionalRelationshipRepeat)
            {
                //TODO
            }
            else if (finishedConversation == honestRelationship)
            {
                //TODO
            }
            else if (finishedConversation == drugExplanation)
            {
                //TODO
            }
            else if (finishedConversation == feelingSuperior)
            {
                //TODO
            }
            else if (finishedConversation == anyoneWantMichaelDead)
            {
                //TODO
            }
            else if (finishedConversation == noBooks)
            {
                //TODO
            }
            else if (finishedConversation == noBooksRepeat)
            {
                //TODO
            }
            else if (finishedConversation == bookRant)
            {
                //TODO
            }
            else if (finishedConversation == endConversation)
            {
                EndChapter();
            }
        }
    }
}