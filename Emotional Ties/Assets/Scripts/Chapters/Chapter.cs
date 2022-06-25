using System.Collections;
using DialogueSystem;
using UnityEngine;

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
            StartCoroutine(PlayChapterCoroutine());
        }

        IEnumerator PlayChapterCoroutine()
        {
            Debug.Log("Starting Chapter: " + chapterNumber);
            yield return new WaitForSeconds(1);

            ChapterTitle.PlayChapterTitle(chapterNumber);
     
            yield return new WaitForSeconds(chapterTitleWaitTime);

            connection.encounter = encounter;
     
            DialogueManager.StartDialogue(this, preEncounterConversation);
        }
    
        public void EndChapter()
        {
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
