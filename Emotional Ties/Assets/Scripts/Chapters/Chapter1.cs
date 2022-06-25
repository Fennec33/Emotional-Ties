using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter1 : Chapter
    {
        [Header("Aspects")]
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData emotionalVortex;
        
        [Header("Conversations")]
        [SerializeField] private Conversation areYouAbleToAnswerSomeQuestionsForMe1;
        [SerializeField] private Conversation areYouAbleToAnswerSomeQuestionsForMe2;
        [SerializeField] private Conversation areYouAbleToAnswerSomeQuestionsForMeRepeat;
        [SerializeField] private Conversation calmDown;
        [SerializeField] private Conversation calmedDownAnswerSomeQuestions;
        [SerializeField] private Conversation lastSeenAlive;
        [SerializeField] private Conversation anyEnemies;
        [SerializeField] private Conversation anythingSuspicious;
        [SerializeField] private Conversation finishConversation;

        private bool _calmedDown = false;
        private bool _asked1 = false;
        private int _questionsAsked = 0;

        private void AddStartingActions()
        {
            ActionMenuManager.AddActionToMenu(AreYouAbleToAnswerSomeQuestionsForMe1, "Are you able to answer some questions for me?");
        }

        public void AreYouAbleToAnswerSomeQuestionsForMe1()
        {
            if (_calmedDown)
            {
                DialogueManager.StartDialogue(this, calmedDownAnswerSomeQuestions);
            }
            else if (!_asked1)
            {
                _asked1 = true;
                DialogueManager.StartDialogue(this, areYouAbleToAnswerSomeQuestionsForMe1);
            }
            else
            {
                DialogueManager.StartDialogue(this, areYouAbleToAnswerSomeQuestionsForMeRepeat);
            }
        }

        public void CalmDown()
        {
            DialogueManager.StartDialogue(this, calmDown);
            _calmedDown = true;
        }
        
        public void LastSeenAlive()
        {
            DialogueManager.StartDialogue(this, lastSeenAlive);
            ActionMenuManager.RemoveActionFromMenu("When did you last see Mr. Baker Alive?");
            _questionsAsked++;
        }

        public void AnyEnemies()
        {
            DialogueManager.StartDialogue(this, anyEnemies);
            ActionMenuManager.RemoveActionFromMenu("Is there anyone who might want Mr. Baker dead?");
            _questionsAsked++;
        }

        public void AnythingSuspicious()
        {
            DialogueManager.StartDialogue(this, anythingSuspicious);
            ActionMenuManager.RemoveActionFromMenu("Has Mr. Baker done anything suspicious");
            _questionsAsked++;
        }

        public void FinishConversation()
        {
            DialogueManager.StartDialogue(this, finishConversation);
        }

        public override void ConversationFinished(Conversation finishedConversation)
        {
            if (finishedConversation == preEncounterConversation)
            {
                encounter.StartEncounter(this);
                AddStartingActions();
            }
            else if (finishedConversation == areYouAbleToAnswerSomeQuestionsForMe1)
            {
                EncounterBoardManager.AddAspectToBoard(traumaticMemories);
                EncounterBoardManager.AddAspectToBoard(focus);
                EncounterBoardManager.AddAspectToBoard(emotionalVortex);
                DialogueManager.StartDialogue(this, areYouAbleToAnswerSomeQuestionsForMe2);
            }
            else if (finishedConversation == calmedDownAnswerSomeQuestions)
            {
                ActionMenuManager.RemoveActionFromMenu("Are you able to answer some questions for me?");
                ActionMenuManager.AddActionToMenu(LastSeenAlive, "When did you last see Mr. Baker Alive?");
                ActionMenuManager.AddActionToMenu(AnyEnemies, "Is there anyone who might want Mr. Baker dead?");
                ActionMenuManager.AddActionToMenu(AnythingSuspicious, "Has Mr. Baker done anything suspicious");
            }
            else if (finishedConversation == lastSeenAlive)
            {
                if (_questionsAsked >= 3)
                    FinishConversation();
            }
            else if (finishedConversation == anyEnemies)
            {
                if (_questionsAsked >= 3)
                    FinishConversation();
            }
            else if (finishedConversation == anythingSuspicious)
            {
                if (_questionsAsked >= 3)
                    FinishConversation();
            }
            else if (finishedConversation == finishConversation)
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
