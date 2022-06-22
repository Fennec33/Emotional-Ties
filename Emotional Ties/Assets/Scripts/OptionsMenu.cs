using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool _optionsOn = false;

    public void ToggleOptionsPanel()
    {
        if (_optionsOn)
        {
            OptionsPanelOut();
        }
        else
        {
            OptionsPanelIn();
        }
    }

    private void OptionsPanelIn()
    {
        animator.SetTrigger("toggleOptionsPanel");
        PauseManager.PauseForOptions();
        _optionsOn = true;
    }

    private void OptionsPanelOut()
    {
        animator.SetTrigger("toggleOptionsPanel");
        PauseManager.UnpauseForOptions();
        _optionsOn = false;
    }
}
