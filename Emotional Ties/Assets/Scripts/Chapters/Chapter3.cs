using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter3 : Chapter
    {
        [Header("Aspects")]
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData emotionallyDrained;
        [SerializeField] private AspectData panic;
        [SerializeField] private AspectData overwhelmed;

        [Header("Conversations")]
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

        private bool _paniced = false;
        private bool _overwhelmed = false;
        private bool _alreadyAskedSawMichael = false;
        private int _allQuestionsAskedMax = 4;
        private int _allQuestionsAsked = 0;
        
        private void AddStartingActionsAndAspects()
        {
            EncounterBoardManager.AddAspectToBoard(focus);
            EncounterBoardManager.AddAspectToBoard(traumaticMemories);
            EncounterBoardManager.AddAspectToBoard(emotionallyDrained);
            
            ActionMenuManager.AddActionToMenu(BigFightLastWeek, "I heard you and Mr. Baker had a fight");
            ActionMenuManager.AddActionToMenu(RememberAnythingElse, "Remember any information");
            ActionMenuManager.AddActionToMenu(WitnessSawYou, "I know you saw Mr. Baker today");
        }

        public void BigFightLastWeek()
        {
            if (_overwhelmed)
            {
                DialogueManager.StartDialogue(this, overwhelmedIDidNotDoIt);
            }
            else if (_paniced)
            {
                DialogueManager.StartDialogue(this, iDidNotDoIt);
            }
            else
            {
                DialogueManager.StartDialogue(this, nothingToWorryAbout);
            }
        }

        public void RememberAnythingElse()
        {
            if (_overwhelmed)
            {
                DialogueManager.StartDialogue(this, overwhelmedIDidNotDoIt);
            }
            else if (_paniced)
            {
                DialogueManager.StartDialogue(this, iDidNotDoIt);
            }
            else
            {
                DialogueManager.StartDialogue(this, nothingNew);
            }
        }

        public void WitnessSawYou()
        {
            if (_overwhelmed)
            {
                DialogueManager.StartDialogue(this, pushingOnWitness);
            }
            else
            {
                if (_alreadyAskedSawMichael)
                {
                    DialogueManager.StartDialogue(this, theyAreLyingRepeat);
                }
                else
                {
                    DialogueManager.StartDialogue(this, theyAreLying);
                }
            }
        }

        private void PleaseTalkWithUs()
        {
            DialogueManager.StartDialogue(this, somethingIDidNotTellYou);
        }

        private void OverwhelmHer()
        {
            DialogueManager.StartDialogue(this, breakingDown);
        }

        private void CleanUpForSecondHalfOfChapter()
        {
            ActionMenuManager.RemoveAllActionsFromMenu();
            ActionMenuManager.AddActionToMenu(WhenYouReallySawMichael, "When was the last time you saw Mr. Baker");
        }

        private void WhenYouReallySawMichael()
        {
            DialogueManager.StartDialogue(this, theRealLastConversation);
        }

        public void UpsetWithWork()
        {
            DialogueManager.StartDialogue(this, upsetWithWork);
        }

        public void GrowingDistant()
        {
            DialogueManager.StartDialogue(this, growingDistant);
        }

        public void AfraidOfAffair()
        {
            DialogueManager.StartDialogue(this, afraidOfAffair);
        }

        public void MysteriousWoman()
        {
            DialogueManager.StartDialogue(this, mysteriousWoman);
        }

        private void CheckIfAllQuestionsAsked()
        {
            if (_allQuestionsAsked >= _allQuestionsAskedMax)
            {
                DialogueManager.StartDialogue(this, questioningEnd);
            }
        }
        
        public override void ConversationFinished(Conversation finishedConversation)
        {
            if (finishedConversation == preEncounterConversation)
            {
                AddStartingActionsAndAspects();
                encounter.StartEncounter(this);
            }
            else if (finishedConversation == theyAreLying)
            {
                EncounterBoardManager.AddAspectToBoard(panic);
                _alreadyAskedSawMichael = true;
            }
            else if (finishedConversation == theyAreLyingRepeat)
            {
                //nothing
            }
            else if (finishedConversation == breakingDown)
            {
                EncounterBoardManager.RemoveAspectFromBoard(emotionallyDrained);
                EncounterBoardManager.RemoveAspectFromBoard(panic);
                EncounterBoardManager.AddAspectToBoard(overwhelmed);
                _overwhelmed = true;
                _paniced = false;
                ActionMenuManager.RemoveActionFromMenu("Please talk with us");
            }
            else if (finishedConversation == pushingOnWitness)
            {
                EncounterBoardManager.RemoveAspectFromBoard(overwhelmed);
                _overwhelmed = false;
                EncounterBoardManager.AddAspectToBoard(emotionallyDrained);
                CleanUpForSecondHalfOfChapter();
            }
            else if (finishedConversation == nothingNew)
            {
                //nothing
            }
            else if (finishedConversation == nothingToWorryAbout)
            {
                ActionMenuManager.RemoveActionFromMenu("I heard you and Mr. Baker had a fight");
                ActionMenuManager.AddActionToMenu(PleaseTalkWithUs, "Please talk with us");
            }
            else if (finishedConversation == somethingIDidNotTellYou)
            {
                CleanUpForSecondHalfOfChapter();
            }
            else if (finishedConversation == iDidNotDoIt)
            {
                //nothing
            }
            else if (finishedConversation == overwhelmedIDidNotDoIt)
            {
                //nothing
            }
            else if (finishedConversation == theRealLastConversation)
            {
                ActionMenuManager.AddActionToMenu(UpsetWithWork, "Why was he upset");
                ActionMenuManager.AddActionToMenu(GrowingDistant, "Why where you growing distant");
                ActionMenuManager.AddActionToMenu(AfraidOfAffair, "Was there an affair");
                ActionMenuManager.AddActionToMenu(MysteriousWoman, "Who was the woman");
            }
            else if (finishedConversation == upsetWithWork)
            {
                ActionMenuManager.RemoveActionFromMenu("Why was he upset");
                _allQuestionsAsked++;
                CheckIfAllQuestionsAsked();
            }
            else if (finishedConversation == growingDistant)
            {
                ActionMenuManager.RemoveActionFromMenu("Why where you growing distant");
                _allQuestionsAsked++;
                CheckIfAllQuestionsAsked();
            }
            else if (finishedConversation == afraidOfAffair)
            {
                ActionMenuManager.RemoveActionFromMenu("Was there an affair");
                _allQuestionsAsked++;
                CheckIfAllQuestionsAsked();
            }
            else if (finishedConversation == mysteriousWoman)
            {
                ActionMenuManager.RemoveActionFromMenu("Who was the woman");
                _allQuestionsAsked++;
                CheckIfAllQuestionsAsked();
            }
            else if (finishedConversation == questioningEnd)
            {
                EndChapter();
            }
            else if (finishedConversation == postEncounterConversation)
            {
                GameManager.StartChapter(chapterNumber + 1);
            }
        }
    }
}