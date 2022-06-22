using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private static PauseManager _current;
    
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject pauseObject;
    

    private bool _pausedForDialogue = false;
    private bool _pausedForOptions = false;

    private void Awake()
    {
        _current = this;
    }

    public static void PauseForDialogue()
    {
        _current._pausedForDialogue = true;
        _current.UpdatePauseState();
    }
    
    public static void UnpauseForDialogue()
    {
        _current._pausedForDialogue = false;
        _current.UpdatePauseState();
    }

    public static void PauseForOptions()
    {
        _current._pausedForOptions = true;
        _current.UpdatePauseState();
    }
    
    public static void UnpauseForOptions()
    {
        _current._pausedForOptions = false;
        _current.UpdatePauseState();
    }

    private void UpdatePauseState()
    {
        if (_pausedForOptions)
        {
            _current.canvas.sortingOrder = 3;
            pauseObject.SetActive(true);
        }
        else if (_pausedForDialogue)
        {
            _current.canvas.sortingOrder = 1;
            pauseObject.SetActive(true);
        }
        else
        {
            _current.canvas.sortingOrder = -1;
            pauseObject.SetActive(false);
        }
    }
    
}
