using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter4 : Chapter
    {
        [Header("Aspects")]
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData caution;
        [SerializeField] private AspectData desire;
        [SerializeField] private AspectData confidence;
        [SerializeField] private AspectData playfulness;
        [SerializeField] private AspectData talkative;
        [SerializeField] private AspectData flirtatiousness;
        [SerializeField] private AspectData pleasant;

        [Header("Conversations")]
        [SerializeField] private Conversation doNotAccuseHer;
        [SerializeField] private Conversation howDidYouKnowMrBaker;
        [SerializeField] private Conversation safeWayHome;
        [SerializeField] private Conversation psychicRealization;
        [SerializeField] private Conversation removeCaution;
        [SerializeField] private Conversation removeDesire;
        [SerializeField] private Conversation professionalRespect;
        [SerializeField] private Conversation michaelInMob;
        [SerializeField] private Conversation whatWasTheConnection;
        [SerializeField] private Conversation conversations;
        [SerializeField] private Conversation drugConversations;
        [SerializeField] private Conversation noAffair;
        [SerializeField] private Conversation typeOfVolunteering;
        [SerializeField] private Conversation iWasSocializing;
        [SerializeField] private Conversation nothingSuspicious;
        [SerializeField] private Conversation dressingRoomMeeting;
        [SerializeField] private Conversation dressingRoomMeetingDrugs;
        [SerializeField] private Conversation opinionOfArthur;
        [SerializeField] private Conversation opinionOfArthurMob;
        [SerializeField] private Conversation whoIsDavid;
        [SerializeField] private Conversation justADetective;
        [SerializeField] private Conversation iWorkOnBikes;
        [SerializeField] private Conversation iRestoreOldBikes;
        [SerializeField] private Conversation iRideBikesToo;
        [SerializeField] private Conversation dinnerAtParents;
        [SerializeField] private Conversation myFamily;
        [SerializeField] private Conversation hillInterruption;
        [SerializeField] private Conversation psychicManipulation;
        [SerializeField] private Conversation inflamedTraumaticMemories;
        [SerializeField] private Conversation howAmISupposedToKnow;
        [SerializeField] private Conversation youHadMeetingsWithHim;
        [SerializeField] private Conversation willNotTalk;
        [SerializeField] private Conversation madeTalkative;
        [SerializeField] private Conversation lotsOfCompetitionWithDrug;
        [SerializeField] private Conversation drugCompetition;
        [SerializeField] private Conversation drugMoney;
        [SerializeField] private Conversation iKnowThings;
        [SerializeField] private Conversation realizeWhoHerFamilyIs;
        [SerializeField] private Conversation theMobHasNothingToDoWithIt;
        [SerializeField] private Conversation theMobHasNothingToDoWithItAlibi;
        [SerializeField] private Conversation drugFailing;
        [SerializeField] private Conversation drugFailingDebt;
        [SerializeField] private Conversation theDebt;
        [SerializeField] private Conversation theDebtFailing;
        
        private int _initialQuestionsAskedMax = 3;
        private int _initialQuestionsAsked = 0;
        private bool _removedCaution = false;
        private bool _removedDesire = false;
        private bool _onDetour = false;

        private int _connectionConversationQuestionsMax = 3;
        private int _connectionConversationQuestions = 0;

        private int _alibiQuestionsAnsweredMax = 2;
        private int _alibiQuestionsAnswered = 0;

        private int _talkingAboutYourselfMax = 2;
        private int _talkingAboutYourself = 0;

        private int _drugInfoQuestionsMax = 2;
        private int _drugInfoQuestions = 0;

        private int _mobInfoQuestionsMax = 2;
        private int _mobInfoQuestions = 0;
        
        private bool _mobKnowledge = false;
        private bool _drugFailing = false;
        private bool _meetings = false;
        private bool _debt = false;
        private bool _talkative = false;

        private bool _askedAboutConnection = false;
        private bool _askedAboutAlibi = false;
        private bool _askedAboutWhoWantedMichaelDead = false;

        private bool _conversationKey1 = false;
        private bool _conversationKey2 = false;
        private bool _conversationKey3 = false;
        
        private void AddStartingActionsAndAspects()
        {
            EncounterBoardManager.AddAspectToBoard(focus);
            EncounterBoardManager.AddAspectToBoard(traumaticMemories);
            
            ActionMenuManager.AddActionToMenu(DidYouKillMrBaker, "Did you kill Mr. Baker");
            ActionMenuManager.AddActionToMenu(HowDidYouKnowMrBaker, "How did you know Mr. Baker");
            ActionMenuManager.AddActionToMenu(DoYouHaveASafeWayHome, "Do you have a safe way home");
        }

        public void DidYouKillMrBaker()
        {
            DialogueManager.StartDialogue(this, doNotAccuseHer);
        }

        public void HowDidYouKnowMrBaker()
        {
            DialogueManager.StartDialogue(this, howDidYouKnowMrBaker);
        }

        public void DoYouHaveASafeWayHome()
        {
            DialogueManager.StartDialogue(this, safeWayHome);
        }

        private void CheckIfFinishedWithInitialQuestions()
        {
            if (_initialQuestionsAsked >= _initialQuestionsAskedMax)
            {
                DialogueManager.StartDialogue(this, psychicRealization);
            }
        }

        public void RemoveCaution()
        {
            DialogueManager.StartDialogue(this, removeCaution);
        }

        public void RemoveDesire()
        {
            DialogueManager.StartDialogue(this, removeDesire);
        }

        private void IfRemovedBothCautionAndDesire()
        {
            if (_removedCaution && _removedDesire)
            {
                DialogueManager.StartDialogue(this, professionalRespect);
            }
        }

        private void AddMainQuestions()
        {
            if (!_askedAboutConnection)
            {
                ActionMenuManager.AddActionToMenu(WhatIsYourConnectionToMichael, "What was your connection with Mr. Baker");
            }

            if (!_askedAboutAlibi)
            {
                ActionMenuManager.AddActionToMenu(DoYouHaveAnAlibi, "Do you have an alibi");
            }

            if (!_askedAboutWhoWantedMichaelDead)
            {
                ActionMenuManager.AddActionToMenu(WhoWantedMichaelDead, "Who wanted Mr. Baker dead");
            }
        }

        public void WhatIsYourConnectionToMichael()
        {
            if (_mobKnowledge)
            {
                DialogueManager.StartDialogue(this, michaelInMob);
            }
            else
            {
                DialogueManager.StartDialogue(this, whatWasTheConnection);
            }
        }

        public void WhatDidYourConversationsInvolve()
        {
            if (_drugFailing)
            {
                DialogueManager.StartDialogue(this, drugConversations);
            }
            else
            {
                DialogueManager.StartDialogue(this, conversations);
            }
        }

        public void DidYouHaveAnAfar()
        {
            DialogueManager.StartDialogue(this, noAffair);
        }

        public void WhatTypeOfVolunteerWork()
        {
            DialogueManager.StartDialogue(this, typeOfVolunteering);
        }

        private void IfAllConnectionQuestionsAsked()
        {
            if (_connectionConversationQuestions >= _initialQuestionsAskedMax)
            {
                _meetings = true;
                _conversationKey1 = true;
                AddMainQuestions();
                TestIfAllKeys();
            }
        }

        public void DoYouHaveAnAlibi()
        {
            DialogueManager.StartDialogue(this, iWasSocializing);
        }

        public void WhenDidYouLastSeeMichael()
        {
            if (_drugFailing)
            {
                DialogueManager.StartDialogue(this, dressingRoomMeetingDrugs);
            }
            else
            {
                DialogueManager.StartDialogue(this, dressingRoomMeeting);
            }
        }

        public void HowDoYouKnowArthur()
        {
            if (_debt)
            {
                DialogueManager.StartDialogue(this, opinionOfArthurMob);
            }
            else
            {
                DialogueManager.StartDialogue(this, opinionOfArthur);
            }
        }
        
        public void DidYouSeeAnythingSuspicious()
        {
            DialogueManager.StartDialogue(this, nothingSuspicious);
        }

        private void CheckIfAllAlibiQuestionsAnswered()
        {
            if (_alibiQuestionsAnswered >= _alibiQuestionsAnsweredMax)
            {
                DialogueManager.StartDialogue(this, whoIsDavid);
            }
        }

        public void AmJustADetective()
        {
            DialogueManager.StartDialogue(this, justADetective);
        }

        public void WorkOnBikes()
        {
            DialogueManager.StartDialogue(this, iWorkOnBikes);
        }

        public void RestoreOldBikes()
        {
            DialogueManager.StartDialogue(this, iRestoreOldBikes);
        }
        
        public void RideBikesToo()
        {
            DialogueManager.StartDialogue(this, iRideBikesToo);
        }

        public void TomorrowIHaveDinner()
        {
            DialogueManager.StartDialogue(this, dinnerAtParents);
        }
        
        public void TellAboutMyFamily()
        {
            DialogueManager.StartDialogue(this, myFamily);
        }

        public void ContinueChatting()
        {
            DialogueManager.StartDialogue(this, hillInterruption);
        }

        public void RealisePsychicManipulation()
        {
            ActionMenuManager.RemoveAllActionsFromMenu();
            DialogueManager.StartDialogue(this, psychicManipulation);
        }

        private void CheckIfFinishedTalkingAboutYourself()
        {
            if (_talkingAboutYourself >= _talkingAboutYourselfMax)
            {
                ActionMenuManager.AddActionToMenu(ContinueChatting, "Continue chatting");
            }
        }
        
        public void WhoWantedMichaelDead()
        {
            if (_meetings)
            {
                DialogueManager.StartDialogue(this, youHadMeetingsWithHim);
            }
            else
            {
                DialogueManager.StartDialogue(this, howAmISupposedToKnow);
            }
        }

        public void KnowYouHaveMoreInformation()
        {
            if (_talkative)
            {
                DialogueManager.StartDialogue(this, lotsOfCompetitionWithDrug);
            }
            else
            {
                DialogueManager.StartDialogue(this, willNotTalk);
            }
        }

        public void MakeTalkative()
        {
            DialogueManager.StartDialogue(this, madeTalkative);
        }

        public void WouldDrugCauseViolence()
        {
            DialogueManager.StartDialogue(this, drugCompetition);
        }

        public void WasDrugGoingToMakeThemRich()
        {
            DialogueManager.StartDialogue(this, drugMoney);
        }
        
        public void HowDoYouKNowSoMuch()
        {
            DialogueManager.StartDialogue(this, iKnowThings);
        }

        public void DidYouKillMichael()
        {
            if (_conversationKey2)
            {
                DialogueManager.StartDialogue(this, theMobHasNothingToDoWithIt);
            }
            else
            {
                DialogueManager.StartDialogue(this, theMobHasNothingToDoWithItAlibi);
            }
        }

        public void HowDoYouKnowAboutDrug()
        {
            if (_debt)
            {
                DialogueManager.StartDialogue(this, drugFailingDebt);
            }
            else
            {
                DialogueManager.StartDialogue(this, drugFailing);
            }
        }

        public void WhatAboutDebts()
        {
            if (_drugFailing)
            {
                DialogueManager.StartDialogue(this, theDebtFailing);
            }
            else
            {
                DialogueManager.StartDialogue(this, theDebt);
            }
        }

        private void TestIfAllKeys()
        {
            if (_conversationKey1 && _conversationKey2 && _conversationKey3)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                EndChapter();
            }
        }
        
        public override void ConversationFinished(Conversation finishedConversation)
        {
            if (finishedConversation == preEncounterConversation)
            {
                AddStartingActionsAndAspects();
                encounter.StartEncounter(this);
            }
            else if (finishedConversation == doNotAccuseHer)
            {
                ActionMenuManager.RemoveActionFromMenu("Did you kill Mr. Baker");
                _initialQuestionsAsked++;
                CheckIfFinishedWithInitialQuestions();
            }
            else if (finishedConversation == howDidYouKnowMrBaker)
            {
                ActionMenuManager.RemoveActionFromMenu("How did you know Mr. Baker");
                _initialQuestionsAsked++;
                CheckIfFinishedWithInitialQuestions();
            }
            else if (finishedConversation == safeWayHome)
            {
                ActionMenuManager.RemoveActionFromMenu("Do you have a safe way home");
                _initialQuestionsAsked++;
                CheckIfFinishedWithInitialQuestions();
            }
            else if (finishedConversation == psychicRealization)
            {
                EncounterBoardManager.AddAspectToBoard(caution);
                EncounterBoardManager.AddAspectToBoard(desire);
            }
            else if (finishedConversation == removeCaution)
            {
                EncounterBoardManager.RemoveAspectFromBoard(caution);
                _removedCaution = true;
                IfRemovedBothCautionAndDesire();
            }
            else if (finishedConversation == removeDesire)
            {
                EncounterBoardManager.RemoveAspectFromBoard(desire);
                _removedDesire = true;
                IfRemovedBothCautionAndDesire();
            }
            else if (finishedConversation == professionalRespect)
            {
                EncounterBoardManager.AddAspectToBoard(confidence);
                ActionMenuManager.AddActionToMenu(WhatIsYourConnectionToMichael, "What was your connection with Mr. Baker");
                ActionMenuManager.AddActionToMenu(DoYouHaveAnAlibi, "Do you have an alibi");
                ActionMenuManager.AddActionToMenu(WhoWantedMichaelDead, "Who wanted Mr. Baker dead");
            }
            else if (finishedConversation == michaelInMob)
            {
                _askedAboutConnection = true;
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(WhatDidYourConversationsInvolve, "What did your conversations involve");
                ActionMenuManager.AddActionToMenu(DidYouHaveAnAfar, "Did you have an afar with Mr. Baker");
                ActionMenuManager.AddActionToMenu(WhatTypeOfVolunteerWork, "What type of volunteer work did you do");
            }
            else if (finishedConversation == whatWasTheConnection)
            {
                _askedAboutConnection = true;
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(WhatDidYourConversationsInvolve, "What did your conversations involve");
                ActionMenuManager.AddActionToMenu(DidYouHaveAnAfar, "Did you have an afar with Mr. Baker");
                ActionMenuManager.AddActionToMenu(WhatTypeOfVolunteerWork, "What type of volunteer work did you do");
            }
            else if (finishedConversation == conversations)
            {
                _connectionConversationQuestions++;
                ActionMenuManager.RemoveActionFromMenu("What did your conversations involve");
                IfAllConnectionQuestionsAsked();
            }
            else if (finishedConversation == drugConversations)
            {
                _connectionConversationQuestions++;
                ActionMenuManager.RemoveActionFromMenu("What did your conversations involve");
                IfAllConnectionQuestionsAsked();
            }
            else if (finishedConversation == noAffair)
            {
                _connectionConversationQuestions++;
                ActionMenuManager.RemoveActionFromMenu("Did you have an afar with Mr. Baker");
                IfAllConnectionQuestionsAsked();
            }
            else if (finishedConversation == typeOfVolunteering)
            {
                _connectionConversationQuestions++;
                ActionMenuManager.RemoveActionFromMenu("What type of volunteer work did you do");
                IfAllConnectionQuestionsAsked();
            }
            else if (finishedConversation == iWasSocializing)
            {
                _askedAboutAlibi = true;
                ActionMenuManager.RemoveAllActionsFromMenu();
                ActionMenuManager.AddActionToMenu(WhenDidYouLastSeeMichael, "When did you last see Mr. Baker");
                ActionMenuManager.AddActionToMenu(DidYouSeeAnythingSuspicious, "Did you see anything suspicious tonight");
            }
            else if (finishedConversation == nothingSuspicious)
            {
                _alibiQuestionsAnswered++;
                ActionMenuManager.RemoveActionFromMenu("Did you see anything suspicious tonight");
                CheckIfAllAlibiQuestionsAnswered();
            }
            else if (finishedConversation == dressingRoomMeeting)
            {
                ActionMenuManager.RemoveActionFromMenu("When did you last see Mr. Baker");
                ActionMenuManager.AddActionToMenu(HowDoYouKnowArthur, "How do you know Mr. Adams");
            }
            else if (finishedConversation == dressingRoomMeetingDrugs)
            {
                ActionMenuManager.RemoveActionFromMenu("When did you last see Mr. Baker");
                ActionMenuManager.AddActionToMenu(HowDoYouKnowArthur, "How do you know Mr. Adams");
            }
            else if (finishedConversation == opinionOfArthur)
            {
                _alibiQuestionsAnswered++;
                ActionMenuManager.RemoveActionFromMenu("How do you know Mr. Adams");
                CheckIfAllAlibiQuestionsAnswered();
            }
            else if (finishedConversation == opinionOfArthurMob)
            {
                _alibiQuestionsAnswered++;
                ActionMenuManager.RemoveActionFromMenu("How do you know Mr. Adams");
                CheckIfAllAlibiQuestionsAnswered();
            }
            else if (finishedConversation == whoIsDavid)
            {
                EncounterBoardManager.AddAspectToBoard(flirtatiousness);
                ActionMenuManager.AddActionToMenu(AmJustADetective, "I am just a detective");
                ActionMenuManager.AddActionToMenu(WorkOnBikes, "I work on bikes");
            }
            else if (finishedConversation == justADetective)
            {
                ActionMenuManager.RemoveActionFromMenu("I am just a detective");
            }
            else if (finishedConversation == iWorkOnBikes)
            {
                ActionMenuManager.RemoveActionFromMenu("I work on bikes");
                EncounterBoardManager.AddAspectToBoard(pleasant);
                ActionMenuManager.AddActionToMenu(RestoreOldBikes, "I restore old bikes");
                ActionMenuManager.AddActionToMenu(TomorrowIHaveDinner, "Tomorrow I have dinner at my parents");
            }
            else if (finishedConversation == iRestoreOldBikes)
            {
                ActionMenuManager.RemoveActionFromMenu("I restore old bikes");
                ActionMenuManager.AddActionToMenu(RideBikesToo, "I ride bikes too");
            }
            else if (finishedConversation == iRideBikesToo)
            {
                ActionMenuManager.RemoveActionFromMenu("I ride bikes too");
                _talkingAboutYourself++;
                CheckIfFinishedTalkingAboutYourself();
            }
            else if (finishedConversation == dinnerAtParents)
            {
                ActionMenuManager.RemoveActionFromMenu("Tomorrow I have dinner at my parents");
                ActionMenuManager.AddActionToMenu(TellAboutMyFamily, "Tell her more about your family");
            }
            else if (finishedConversation == myFamily)
            {
                ActionMenuManager.RemoveActionFromMenu("Tell her more about your family");
                _talkingAboutYourself++;
                CheckIfFinishedTalkingAboutYourself();
            }
            else if (finishedConversation == hillInterruption)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                DialogueManager.StartDialogue(this, inflamedTraumaticMemories);
            }
            else if (finishedConversation == psychicManipulation)
            {
                DialogueManager.StartDialogue(this, inflamedTraumaticMemories);
            }
            else if (finishedConversation == inflamedTraumaticMemories)
            {
                EncounterBoardManager.RemoveAspectFromBoard(flirtatiousness);
                EncounterBoardManager.RemoveAspectFromBoard(pleasant);
                _conversationKey2 = true;

                if (_onDetour)
                {
                    _onDetour = false;
                    
                    if (!_drugFailing)
                    {
                        ActionMenuManager.AddActionToMenu(HowDoYouKnowAboutDrug, "How do you know the drug is failing");
                    }

                    if (!_debt)
                    {
                        ActionMenuManager.AddActionToMenu(WhatAboutDebts, "What about their debt");
                    }
                }
                else
                {
                    AddMainQuestions();
                }
                
                TestIfAllKeys();
            }
            else if (finishedConversation == howAmISupposedToKnow)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                _askedAboutWhoWantedMichaelDead = true;
                EncounterBoardManager.AddAspectToBoard(playfulness);
                ActionMenuManager.AddActionToMenu(KnowYouHaveMoreInformation, "I know you have more information");
            }
            else if (finishedConversation == youHadMeetingsWithHim)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                _askedAboutWhoWantedMichaelDead = true;
                EncounterBoardManager.AddAspectToBoard(playfulness);
                ActionMenuManager.AddActionToMenu(KnowYouHaveMoreInformation, "I know you have more information");
            }
            else if (finishedConversation == willNotTalk)
            {
                //nothing
            }
            else if (finishedConversation == madeTalkative)
            {
                EncounterBoardManager.AddAspectToBoard(talkative);
                EncounterBoardManager.RemoveAspectFromBoard(playfulness);
                _talkative = true;
            }
            else if (finishedConversation == lotsOfCompetitionWithDrug)
            {
                ActionMenuManager.RemoveActionFromMenu("I know you have more information");
                ActionMenuManager.AddActionToMenu(WouldDrugCauseViolence, "Would thr drug really cause violence");
                ActionMenuManager.AddActionToMenu(WasDrugGoingToMakeThemRich, "Was the drug really going to make them rich");
            }
            else if (finishedConversation == drugCompetition)
            {
                ActionMenuManager.RemoveActionFromMenu("Would thr drug really cause violence");
                _drugInfoQuestions++;

                if (_drugInfoQuestions >= _drugInfoQuestionsMax)
                {
                    ActionMenuManager.AddActionToMenu(HowDoYouKNowSoMuch, "How do you know so much");
                }
            }
            else if (finishedConversation == drugMoney)
            {
                ActionMenuManager.RemoveActionFromMenu("Was the drug really going to make them rich");
                _drugInfoQuestions++;

                if (_drugInfoQuestions >= _drugInfoQuestionsMax)
                {
                    ActionMenuManager.AddActionToMenu(HowDoYouKNowSoMuch, "How do you know so much");
                }
            }
            else if (finishedConversation == iKnowThings)
            {
                EncounterBoardManager.RemoveAspectFromBoard(talkative);
                _talkative = false;
                DialogueManager.StartDialogue(this, realizeWhoHerFamilyIs);
            }
            else if (finishedConversation == realizeWhoHerFamilyIs)
            {
                _mobKnowledge = true;
                ActionMenuManager.AddActionToMenu(DidYouKillMichael, "Did you kill Mr. Baker");
                ActionMenuManager.AddActionToMenu(HowDoYouKnowAboutDrug, "How do you know the drug is failing");
                ActionMenuManager.AddActionToMenu(WhatAboutDebts, "What about their debt");
                
            }
            else if (finishedConversation == theMobHasNothingToDoWithIt)
            {
                ActionMenuManager.RemoveActionFromMenu("Did you kill Mr. Baker");
            }
            else if (finishedConversation == theMobHasNothingToDoWithItAlibi)
            {
                ActionMenuManager.RemoveAllActionsFromMenu();
                _onDetour = true;
                _askedAboutAlibi = true;
                ActionMenuManager.AddActionToMenu(WhenDidYouLastSeeMichael, "When did you last see Mr. Baker");
                ActionMenuManager.AddActionToMenu(DidYouSeeAnythingSuspicious, "Did you see anything suspicious tonight");
            }
            else if (finishedConversation == drugFailing)
            {
                ActionMenuManager.RemoveActionFromMenu("How do you know the drug is failing");
                _drugFailing = true;
                _mobInfoQuestions++;

                if (_mobInfoQuestions >= _mobInfoQuestionsMax)
                {
                    ActionMenuManager.RemoveAllActionsFromMenu();
                    _conversationKey3 = true;
                    AddMainQuestions();
                    TestIfAllKeys();
                }
            }
            else if (finishedConversation == drugFailingDebt)
            {
                ActionMenuManager.RemoveActionFromMenu("How do you know the drug is failing");
                _drugFailing = true;
                _mobInfoQuestions++;

                if (_mobInfoQuestions >= _mobInfoQuestionsMax)
                {
                    ActionMenuManager.RemoveAllActionsFromMenu();
                    _conversationKey3 = true;
                    AddMainQuestions();
                    TestIfAllKeys();
                }
            }
            else if (finishedConversation == theDebt)
            {
                ActionMenuManager.RemoveActionFromMenu("What about their debt");
                _debt = true;
                _mobInfoQuestions++;

                if (_mobInfoQuestions >= _mobInfoQuestionsMax)
                {
                    ActionMenuManager.RemoveAllActionsFromMenu();
                    _conversationKey3 = true;
                    AddMainQuestions();
                    TestIfAllKeys();
                }
            }
            else if (finishedConversation == theDebtFailing)
            {
                ActionMenuManager.RemoveActionFromMenu("What about their debt");
                _debt = true;
                _mobInfoQuestions++;

                if (_mobInfoQuestions >= _mobInfoQuestionsMax)
                {
                    ActionMenuManager.RemoveAllActionsFromMenu();
                    _conversationKey3 = true;
                    AddMainQuestions();
                    TestIfAllKeys();
                }
            }
            else if (finishedConversation == postEncounterConversation)
            {
                GameManager.StartChapter(chapterNumber + 1);
            }
        }
    }
}