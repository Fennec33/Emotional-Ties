using System.Collections;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public abstract class Chapter : MonoBehaviour, IConversationTrigger
    {
        [SerializeField] protected int champterNumber;
    
        [SerializeField] protected Conversation preEncounterConversation;
        [SerializeField] protected Encounter encounter;
        [SerializeField] protected Conversation postEncounterConversation;
        [SerializeField] protected int chapterTitleWaitTime = 4;

        public int GetChapterNumber()
        {
            return champterNumber;
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
            yield return new WaitForSeconds(1);

            ChapterTitle.PlayChapterTitle(champterNumber);
     
            yield return new WaitForSeconds(chapterTitleWaitTime);
     
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
