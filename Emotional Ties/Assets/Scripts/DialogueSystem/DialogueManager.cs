using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Chapters;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _current;
    
        public TMP_Text nameText;
        public TMP_Text dialogueText;

        public Animator animator;

        [SerializeField] private AudioSource typeSound;
        [SerializeField] private int typingSoundDelay;
        private int _typingSoundTimer = 0;
        [SerializeField] private AudioClip[] typingClips;

        public float typingSpeed = 0.02f;

        private Queue<LineOfDialogue> _sentences;

        private Chapter _currentChapter;

        private static IConversationTrigger _trigger;

        private Conversation curentConversation;

        private bool _doneTyping = true;
        private Coroutine _typingCoroutine;
        private bool _muteTyping = false;
    
        void Start()
        {
            _sentences = new Queue<LineOfDialogue>();
        }

        private void Awake()
        {
            _current = this;
        }

        public void SetTypingSpeed(float value)
        {
            typingSpeed = value;
        }

        public void MuteTyping(bool mute)
        {
            _muteTyping = mute;
        }

        public static void StartDialogue( IConversationTrigger trigger, Conversation conversation)
        {
            _current.curentConversation = conversation;
            
            PauseManager.PauseForDialogue();
            
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
            if (!_doneTyping)
            {
                if (_typingCoroutine != null)
                {
                    StopCoroutine(_typingCoroutine);
                }
                _doneTyping = true;
                dialogueText.maxVisibleCharacters = dialogueText.textInfo.characterCount;
                dialogueText.ForceMeshUpdate();
                return;
            }
            
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            
            LineOfDialogue sentence = _sentences.Dequeue();
        
            _current.nameText.text = sentence.GetName();

            if (_typingCoroutine != null)
            {
                StopCoroutine(_typingCoroutine);
            }
            _typingCoroutine = StartCoroutine(TypeSentence(sentence.GetSentence()));
            
            sentence.TriggerAudioEffect();
        }

        IEnumerator TypeSentence(string sentence)
        {
            _doneTyping = false;
            dialogueText.text = sentence;
            dialogueText.ForceMeshUpdate();
            
            int charCount = dialogueText.textInfo.characterCount;
            
            for (int i = 0; i < charCount + 1; i++)
            {
                dialogueText.maxVisibleCharacters = i;
                _typingSoundTimer++;

                if (!_muteTyping)
                {
                    PlayTypingSound();
                }

                yield return new WaitForSeconds(typingSpeed);
            }

            _doneTyping = true;
        }

        private void PlayTypingSound()
        {
            if (_typingSoundTimer >= typingSoundDelay)
            {
                _typingSoundTimer = 0;

                var typeClip = typingClips[Random.Range(0, typingClips.Length - 1)];
                typeSound.clip = typeClip;
                typeSound.Play();
            }
        }

        private void EndDialogue()
        {
            PauseManager.UnpauseForDialogue();
            animator.SetBool("IsOpen", false);
            _trigger.ConversationFinished(_current.curentConversation);
        }
    }
}
