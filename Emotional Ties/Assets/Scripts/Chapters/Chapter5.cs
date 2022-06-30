using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem;
using UnityEditor;
using UnityEngine;

namespace Chapters
{
    public class Chapter5 : Chapter
    {
        [Header("Aspects")]
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData onEdge;

        [Header("Conversations")]
        [SerializeField] private Conversation atGunpoint;
        [SerializeField] private Conversation doNotTellMeWhatToDo;
        [SerializeField] private Conversation nothingToTalkAbout;
        [SerializeField] private Conversation heLeftMeNoChoice;
        [SerializeField] private Conversation heWasRuiningEverything;
        [SerializeField] private Conversation badIdea;
        [SerializeField] private Conversation inflictTrauma;
        [SerializeField] private Conversation shootArthur;

        [Header("Links")]
        [SerializeField] private Link tramaLink;

        private bool _inflictedTrama = false;
        
        private void AddStartingActionsAndAspects()
        {
            EncounterBoardManager.AddAspectToBoard(focus);
            EncounterBoardManager.AddAspectToBoard(traumaticMemories);
            EncounterBoardManager.AddAspectToBoard(onEdge);
            
            DialogueManager.StartDialogue(this, atGunpoint);
        }

        public void YouHaveNoWayOut()
        {
            DialogueManager.StartDialogue(this, doNotTellMeWhatToDo);
        }

        public void WeCanTalk()
        {
            DialogueManager.StartDialogue(this, nothingToTalkAbout);
        }

        public void YouMurderedYourFriend()
        {
            DialogueManager.StartDialogue(this, heLeftMeNoChoice);
        }
        
        public void MichaelWasSinkingTheBusiness()
        {
            DialogueManager.StartDialogue(this, heWasRuiningEverything);
        }

        public void GrabGun()
        {
            if (_inflictedTrama)
            {
                DialogueManager.StartDialogue(this, shootArthur);
            }
            else
            {
                DialogueManager.StartDialogue(this, badIdea);
            }
        }

        public void PsychicBlast()
        {
            DialogueManager.StartDialogue(this, inflictTrauma);
        }
        
        public override void ConversationFinished(Conversation finishedConversation)
        {
            if (finishedConversation == preEncounterConversation)
            {
                AddStartingActionsAndAspects();
                encounter.StartEncounter(this);
            }
            else if (finishedConversation == atGunpoint)
            {
                ActionMenuManager.AddActionToMenu(YouHaveNoWayOut, "You have no way out");
                ActionMenuManager.AddActionToMenu(WeCanTalk, "We can talk about this");
            }
            else if (finishedConversation == doNotTellMeWhatToDo)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(YouMurderedYourFriend, "You murdered your friend over money");
                ActionMenuManager.AddActionToMenu(MichaelWasSinkingTheBusiness, "Michael was going to sink the business");
            }
            else if (finishedConversation == nothingToTalkAbout)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(YouMurderedYourFriend, "You murdered your friend over money");
                ActionMenuManager.AddActionToMenu(MichaelWasSinkingTheBusiness, "Michael was going to sink the business");
            }
            else if (finishedConversation == heLeftMeNoChoice)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(GrabGun, "Grab your gun");
                encounter.AddValidLink(tramaLink);
            }
            else if (finishedConversation == heWasRuiningEverything)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(GrabGun, "Grab your gun");
                encounter.AddValidLink(tramaLink);
            }
            else if (finishedConversation == badIdea)
            {
                //nothing
            }
            else if (finishedConversation == inflictTrauma)
            {
                EncounterBoardManager.RemoveAspectFromBoard(onEdge);
                _inflictedTrama = true;
            }
            else if (finishedConversation == shootArthur)
            {
                EndChapter();
            }
            else if (finishedConversation == postEncounterConversation)
            {
                StartCoroutine(PlayEndCoroutine());
            }
        }
        
        IEnumerator PlayEndCoroutine()
        {
            yield return new WaitForSeconds(1);

            ChapterTitle.PlayGameEnd();
     
            yield return new WaitForSeconds(chapterTitleWaitTime);

            GameManager.GoToMainMenu();
        }
    }
}