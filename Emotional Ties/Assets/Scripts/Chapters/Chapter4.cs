using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter4 : Chapter
    {
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData caution;
        [SerializeField] private AspectData confidence;
        [SerializeField] private AspectData playfulness;
        [SerializeField] private AspectData talkative;
        [SerializeField] private AspectData flirtatiousness;
        [SerializeField] private AspectData pleasant;

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
            else if (finishedConversation == doNotAccuseHer)
            {
                //TODO
            }
            else if (finishedConversation == howDidYouKnowMrBaker)
            {
                //TODO
            }
            else if (finishedConversation == safeWayHome)
            {
                //TODO
            }
            else if (finishedConversation == psychicRealization)
            {
                //TODO
            }
            else if (finishedConversation == removeCaution)
            {
                //TODO
            }
            else if (finishedConversation == removeDesire)
            {
                //TODO
            }
            else if (finishedConversation == professionalRespect)
            {
                //TODO
            }
            else if (finishedConversation == michaelInMob)
            {
                //TODO
            }
            else if (finishedConversation == whatWasTheConnection)
            {
                //TODO
            }
            else if (finishedConversation == conversations)
            {
                //TODO
            }
            else if (finishedConversation == drugConversations)
            {
                //TODO
            }
            else if (finishedConversation == noAffair)
            {
                //TODO
            }
            else if (finishedConversation == typeOfVolunteering)
            {
                //TODO
            }
            else if (finishedConversation == iWasSocializing)
            {
                //TODO
            }
            else if (finishedConversation == nothingSuspicious)
            {
                //TODO
            }
            else if (finishedConversation == dressingRoomMeeting)
            {
                //TODO
            }
            else if (finishedConversation == dressingRoomMeetingDrugs)
            {
                //TODO
            }
            else if (finishedConversation == opinionOfArthur)
            {
                //TODO
            }
            else if (finishedConversation == opinionOfArthurMob)
            {
                //TODO
            }
            else if (finishedConversation == whoIsDavid)
            {
                //TODO
            }
            else if (finishedConversation == justADetective)
            {
                //TODO
            }
            else if (finishedConversation == iWorkOnBikes)
            {
                //TODO
            }
            else if (finishedConversation == iRestoreOldBikes)
            {
                //TODO
            }
            else if (finishedConversation == iRideBikesToo)
            {
                //TODO
            }
            else if (finishedConversation == dinnerAtParents)
            {
                //TODO
            }
            else if (finishedConversation == myFamily)
            {
                //TODO
            }
            else if (finishedConversation == hillInterruption)
            {
                //TODO
            }
            else if (finishedConversation == psychicManipulation)
            {
                //TODO
            }
            else if (finishedConversation == inflamedTraumaticMemories)
            {
                //TODO
            }
            else if (finishedConversation == howAmISupposedToKnow)
            {
                //TODO
            }
            else if (finishedConversation == youHadMeetingsWithHim)
            {
                //TODO
            }
            else if (finishedConversation == willNotTalk)
            {
                //TODO
            }
            else if (finishedConversation == madeTalkative)
            {
                //TODO
            }
            else if (finishedConversation == lotsOfCompetitionWithDrug)
            {
                //TODO
            }
            else if (finishedConversation == drugCompetition)
            {
                //TODO
            }
            else if (finishedConversation == drugMoney)
            {
                //TODO
            }
            else if (finishedConversation == iKnowThings)
            {
                //TODO
            }
            else if (finishedConversation == realizeWhoHerFamilyIs)
            {
                //TODO
            }
            else if (finishedConversation == theMobHasNothingToDoWithIt)
            {
                //TODO
            }
            else if (finishedConversation == theMobHasNothingToDoWithItAlibi)
            {
                //TODO
            }
            else if (finishedConversation == drugFailing)
            {
                //TODO
            }
            else if (finishedConversation == drugFailingDebt)
            {
                //TODO
            }
            else if (finishedConversation == theDebt)
            {
                //TODO
            }
            else if (finishedConversation == theDebtFailing)
            {
                //TODO
            }
        }
    }
}