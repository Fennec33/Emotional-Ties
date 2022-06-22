using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter3 : Chapter
    {
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData emotionallyDrained;
        [SerializeField] private AspectData panic;
        [SerializeField] private AspectData overwhelmed;

        [SerializeField] private Conversation theyAreLying;
        [SerializeField] private Conversation theyAreLyingRepeat;
        [SerializeField] private Conversation breakingDown;
        [SerializeField] private Conversation pushingOnWitness;
        [SerializeField] private Conversation nothingNew;
        [SerializeField] private Conversation nothingToWorryAbout;
        [SerializeField] private Conversation somethingIDidNotTellYou;
        [SerializeField] private Conversation iDidNotDoIt;
        [SerializeField] private Conversation overwhelmedIDidNotDoIt;
        [SerializeField] private Conversation theRealLastConversation;
        [SerializeField] private Conversation upsetWithWork;
        [SerializeField] private Conversation growingDistant;
        [SerializeField] private Conversation afraidOfAffair;
        [SerializeField] private Conversation mysteriousWoman;
        [SerializeField] private Conversation questioningEnd;
        
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
            else if (finishedConversation == theyAreLying)
            {
                //TODO
            }
            else if (finishedConversation == theyAreLyingRepeat)
            {
                //TODO
            }
            else if (finishedConversation == breakingDown)
            {
                //TODO
            }
            else if (finishedConversation == pushingOnWitness)
            {
                //TODO
            }
            else if (finishedConversation == nothingNew)
            {
                //TODO
            }
            else if (finishedConversation == nothingToWorryAbout)
            {
                //TODO
            }
            else if (finishedConversation == somethingIDidNotTellYou)
            {
                //TODO
            }
            else if (finishedConversation == iDidNotDoIt)
            {
                //TODO
            }
            else if (finishedConversation == overwhelmedIDidNotDoIt)
            {
                //TODO
            }
            else if (finishedConversation == theRealLastConversation)
            {
                //TODO
            }
            else if (finishedConversation == upsetWithWork)
            {
                //TODO
            }
            else if (finishedConversation == growingDistant)
            {
                //TODO
            }
            else if (finishedConversation == afraidOfAffair)
            {
                //TODO
            }
            else if (finishedConversation == mysteriousWoman)
            {
                //TODO
            }
            else if (finishedConversation == questioningEnd)
            {
                EndChapter();
            }
        }
    }
}