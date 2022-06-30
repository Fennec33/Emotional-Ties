using System.Collections;
using DialogueSystem;
using UnityEngine;
using UnityEngine.Analytics;

namespace Chapters
{
    public abstract class Chapter : MonoBehaviour, IConversationTrigger
    {
        [SerializeField] protected int chapterNumber;

        [SerializeField] protected Conversation preEncounterConversation;
        [SerializeField] protected Encounter encounter;
        [SerializeField] protected Connection connection;
        [SerializeField] protected Conversation postEncounterConversation;
        [SerializeField] protected int chapterTitleWaitTime = 4;
        [SerializeField] private AudioManager audioManager;

        public int GetChapterNumber()
        {
            return chapterNumber;
        }

        public Encounter GetEncounter()
        {
            return encounter;
        }
    
        public void PlayChapter()
        {
            audioManager.StartChapterMusic(chapterNumber);
            StartCoroutine(PlayChapterCoroutine());
        }

        IEnumerator PlayChapterCoroutine()
        {
            yield return new WaitForSeconds(1);

            ChapterTitle.PlayChapterTitle(chapterNumber);
     
            yield return new WaitForSeconds(chapterTitleWaitTime);

            connection.encounter = encounter;
     
            DialogueManager.StartDialogue(this, preEncounterConversation);
        }
    
        public void EndChapter()
        {
            AnalyticsResult analyticsResult = Analytics.CustomEvent("Finished Chapter " + chapterNumber);
            Debug.Log(analyticsResult);
            encounter.EndEncounter();
            DialogueManager.StartDialogue(this, postEncounterConversation);
        }

        public virtual void ConversationFinished(Conversation finishedConversation)
        {
            //nothing
        }

        private void AddStartingActions()
        {
            //nothing
        }
    }
}
