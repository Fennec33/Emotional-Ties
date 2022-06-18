using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterTitle : MonoBehaviour
{
    private static ChapterTitle _current;
    
    private TextMeshProUGUI _chapterTitleText;
    private Animator _animator;
    private const string Title = "Chapter ";
    private static readonly int AnimateChapter = Animator.StringToHash("AnimateChapter");

    private void Awake()
    {
        _current = this;
        
        _chapterTitleText = GetComponent<TextMeshProUGUI>();
        _animator = GetComponent<Animator>();
    }

    public static void PlayChapterTitle(int chapterNumber)
    {
        _current._chapterTitleText.text = Title + chapterNumber;
        _current._animator.SetTrigger(AnimateChapter);
    }
}
