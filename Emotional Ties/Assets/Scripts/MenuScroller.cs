using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScroller : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void GoToChapterSelect()
    {
        animator.SetTrigger("goToChapterSelect");
    }

    public void GoToMainMenu()
    {
        animator.SetTrigger("goToMainMenu");
    }
}
