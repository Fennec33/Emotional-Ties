using System;
using System.Collections;
using System.Collections.Generic;
using Chapters;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _current;

    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas DialogueCanvas;
    [SerializeField] private Canvas actionMenuCanvas;
    [SerializeField] private Chapter[] chapters;


    private static Chapter _currentChapter;

    private void Awake()
    {
        _current = this;
    }

    public static Chapter GetCurrentChapter()
    {
        return _currentChapter;
    }

    public static void StartChapter(int chapter)
    {
        _current.menuCanvas.enabled = false;
        _current.DialogueCanvas.enabled = true;
        _current.actionMenuCanvas.enabled = true;

        _currentChapter = _current.chapters[chapter - 1];

        _currentChapter.PlayChapter();
    }

    public static void GoToMainMenu()
    {
        //TODO
    }
}
