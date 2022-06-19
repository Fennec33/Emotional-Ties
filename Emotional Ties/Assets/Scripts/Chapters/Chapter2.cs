using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter2 : Chapter
    {
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData stress;
        [SerializeField] private AspectData impatience;
        [SerializeField] private AspectData pride;
        [SerializeField] private AspectData superiorityComplex;

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
    }
}