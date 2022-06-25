using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter2 : Chapter
    {
        [Header("Aspects")]
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData stress;
        [SerializeField] private AspectData impatience;
        [SerializeField] private AspectData pride;
        [SerializeField] private AspectData superiorityComplex;

        [Header("Conversations")]
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

        private int _numberOfQuestionsMax = 5;
        private int _numberOfQuestionsAnswered = 0;
        
        private bool _getOffPhoneAlreadyAsked = false;
        private bool _callEnded = false;
        private bool _calmedDown = false;
        private bool _feelingSuperior = false;
        private bool _alreadyAskedAboutRelationship = false;
        private bool _addedAskAboutDrug = false;
        private bool _alreadyAskedAnboutBooks = false;

        private void AddStartingActionsAndAspects()
        {
            EncounterBoardManager.AddAspectToBoard(focus);
            EncounterBoardManager.AddAspectToBoard(traumaticMemories);
            ActionMenuManager.AddActionToMenu(GetOffPhone, "I need to ask you some questions");
        }

        private void QuestionAnswered()
        {
            _numberOfQuestionsAnswered++;
            if (_numberOfQuestionsAnswered >= _numberOfQuestionsMax)
            {
                DialogueManager.StartDialogue(this, endConversation);
            }
        }

        public void GetOffPhone()
        {
            if (_getOffPhoneAlreadyAsked)
            {
                DialogueManager.StartDialogue(this, stillOnPhoneRepeat);
            }
            else
            {
                DialogueManager.StartDialogue(this, stillOnPhone);
            }
        }

        public void StressArthurOut()
        {
            if (_callEnded)
            {
                DialogueManager.StartDialogue(this, getsStressedAgain);
                _calmedDown = false;
            }
            else
            {
                _callEnded = true;
                DialogueManager.StartDialogue(this, endPhoneCall);
            }
        }

        public void CalmDown()
        {
            DialogueManager.StartDialogue(this, calmsDown);
            _calmedDown = true;
        }

        public void LastSawMichael()
        {
            if (_calmedDown)
            {
                DialogueManager.StartDialogue(this, brideAndGroom);
            }
            else
            {
                DialogueManager.StartDialogue(this, stressedOut);
            }
        }

        public void RelationshipWithMichael()
        {
            if (_calmedDown)
            {
                if (_feelingSuperior)
                {
                    DialogueManager.StartDialogue(this, honestRelationship);
                }
                else
                {
                    if (_alreadyAskedAboutRelationship)
                    {
                        DialogueManager.StartDialogue(this, professionalRelationshipRepeat);
                    }
                    else
                    {
                        DialogueManager.StartDialogue(this, professionalRelationship);
                    }
                }
            }
            else
            {
                DialogueManager.StartDialogue(this, stressedOut);
            } 
        }

        public void WantMichaelDead()
        {
            if (_calmedDown)
            {
                DialogueManager.StartDialogue(this, anyoneWantMichaelDead);
            }
            else
            {
                DialogueManager.StartDialogue(this, stressedOut);
            }
        }
        
        public void StrangeBooks()
        {
            if (_calmedDown)
            {
                if (_feelingSuperior)
                {
                    DialogueManager.StartDialogue(this, bookRant);
                }
                else
                {
                    if (_alreadyAskedAnboutBooks)
                    {
                        DialogueManager.StartDialogue(this, noBooksRepeat);
                    }
                    else
                    {
                        DialogueManager.StartDialogue(this, noBooks);
                    }
                }
            }
            else
            {
                DialogueManager.StartDialogue(this, stressedOut);
            }
        }

        public void MakePrideful()
        {
            if (_calmedDown)
            {
                DialogueManager.StartDialogue(this, feelingSuperior);
                _feelingSuperior = true;
            }
        }

        public void AskAboutPsymoprofen()
        {
            DialogueManager.StartDialogue(this, drugExplanation);
        }
        
        public override void ConversationFinished(Conversation finishedConversation)
        {
            if (finishedConversation == preEncounterConversation)
            {
                AddStartingActionsAndAspects();
                encounter.StartEncounter(this);
            }
            else if (finishedConversation == stillOnPhone)
            {
                _getOffPhoneAlreadyAsked = true;
                EncounterBoardManager.AddAspectToBoard(stress);
                EncounterBoardManager.AddAspectToBoard(impatience);
            }
            else if (finishedConversation == stillOnPhoneRepeat)
            {
                //nothing
            }
            else if (finishedConversation == endPhoneCall)
            {
                ActionMenuManager.RemoveActionFromMenu("I need to ask you some questions");
                ActionMenuManager.AddActionToMenu(LastSawMichael, "When did you last see Mr. Baker");
                ActionMenuManager.AddActionToMenu(RelationshipWithMichael, "How was your relationship with Mr. Baker");
                ActionMenuManager.AddActionToMenu(WantMichaelDead, "Did anyone want Mr. Baker dead");
                ActionMenuManager.AddActionToMenu(StrangeBooks, "Do you know anything about strange books");
            }
            else if (finishedConversation == calmsDown)
            {
                //nothing
            }
            else if (finishedConversation == getsStressedAgain)
            {
                //nothing
            }
            else if (finishedConversation == stressedOut)
            {
                //nothing
            }
            else if (finishedConversation == brideAndGroom)
            {
                ActionMenuManager.RemoveActionFromMenu("When did you last see Mr. Baker");
                QuestionAnswered();
            }
            else if (finishedConversation == professionalRelationship)
            {
                _alreadyAskedAboutRelationship = true;

                if (!_addedAskAboutDrug)
                {
                    _addedAskAboutDrug = true;
                    ActionMenuManager.AddActionToMenu(AskAboutPsymoprofen, "What is Psymoprofen");
                }
            }
            else if (finishedConversation == professionalRelationshipRepeat)
            {
                //nothing
            }
            else if (finishedConversation == honestRelationship)
            {
                ActionMenuManager.RemoveActionFromMenu("How was your relationship with Mr. Baker");
                
                if (!_addedAskAboutDrug)
                {
                    _addedAskAboutDrug = true;
                    ActionMenuManager.AddActionToMenu(AskAboutPsymoprofen, "What is Psymoprofen");
                }

                QuestionAnswered();
            }
            else if (finishedConversation == drugExplanation)
            {
                EncounterBoardManager.AddAspectToBoard(pride);
                ActionMenuManager.RemoveActionFromMenu("What is Psymoprofen");
                QuestionAnswered();
            }
            else if (finishedConversation == feelingSuperior)
            {
                EncounterBoardManager.RemoveAspectFromBoard(pride);
                EncounterBoardManager.AddAspectToBoard(superiorityComplex);
            }
            else if (finishedConversation == anyoneWantMichaelDead)
            {
                ActionMenuManager.RemoveActionFromMenu("Did anyone want Mr. Baker dead");
                QuestionAnswered();
            }
            else if (finishedConversation == noBooks)
            {
                _alreadyAskedAnboutBooks = true;
            }
            else if (finishedConversation == noBooksRepeat)
            {
                //nothing
            }
            else if (finishedConversation == bookRant)
            {
                ActionMenuManager.RemoveActionFromMenu("Do you know anything about strange books");
                QuestionAnswered();
            }
            else if (finishedConversation == endConversation)
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