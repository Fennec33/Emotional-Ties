using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Chapters;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _current;
    
        public TMP_Text nameText;
        public TMP_Text dialogueText;

        public Animator animator;

        public float typingSpeed = 0.02f;

        [SerializeField] private GameObject pauseObject;
        

        private Queue<LineOfDialogue> _sentences;

        private Chapter _currentChapter;

        private static IConversationTrigger _trigger;

        private Conversation curentConversation;
    
        void Start()
        {
            _sentences = new Queue<LineOfDialogue>();
        }

        private void Awake()
        {
            _current = this;
        }

        public static void StartDialogue( IConversationTrigger trigger, Conversation conversation)
        {
            _current.curentConversation = conversation;
            
            _current.pauseObject.SetActive(true);
            
            _trigger = trigger;
            
            _current.animator.SetBool("IsOpen", true);

            _current._sentences.Clear();

            foreach (LineOfDialogue sentence in conversation.lines)
            {
                _current._sentences.Enqueue(sentence);
            }
        
            _current.DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            LineOfDialogue sentence = _sentences.Dequeue();
        
            _current.nameText.text = sentence.GetName();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence.GetSentence()));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = sentence;
            dialogueText.ForceMeshUpdate();
            
            int charCount = dialogueText.textInfo.characterCount;
            
            for (int i = 0; i < charCount + 1; i++)
            {
                dialogueText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        private void EndDialogue()
        {
            _current.pauseObject.SetActive(false);
            animator.SetBool("IsOpen", false);
            _trigger.ConversationFinished(_current.curentConversation);
        }
    }
}
