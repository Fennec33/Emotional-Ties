using System;
using DialogueSystem;
using UnityEngine;

namespace Chapters
{
    public class Chapter3 : Chapter
    {
        [SerializeField] private AspectData traumaticMemories;
        [SerializeField] private AspectData focus;
        [SerializeField] private AspectData emotionallyDrained;
        [SerializeField] private AspectData panic;
        [SerializeField] private AspectData overwhelmed;

        [SerializeField] private Conversation theyAreLying;
        [SerializeField] private Conversation theyAreLyingRepeat;
        [SerializeField] private Conversation breakingDown;
        [SerializeField] private Conversation pushingOnWitness;
        [SerializeField] private Conversation nothingNew;
        [SerializeField] private Conversation nothingToWorryAbout;
        [SerializeField] private Conversation somethingIDidNotTellYou;
        [SerializeField] private Conversation iDidNotDoIt;
        [SerializeField] private Conversation overwhelmedIDidNotDoIt;
        [SerializeField] private Conversation theRealLastConversation;
        [SerializeField] private Conversation upsetWithWork;
        [SerializeField] private Conversation growingDistant;
        [SerializeField] private Conversation afraidOfAffair;
        [SerializeField] private Conversation mysteriousWoman;
        [SerializeField] private Conversation questioningEnd;
    }
}