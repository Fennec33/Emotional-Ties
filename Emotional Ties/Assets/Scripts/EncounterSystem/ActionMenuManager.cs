using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuManager : MonoBehaviour
{
    private static ActionMenuManager _current;
    
    public Animator animator;

    [SerializeField] private Transform scrollableList;
    [SerializeField] private GameObject buttonPrefab;

    private void Awake()
    {
        _current = this;
    }

    public static void AddActionToMenu(Action act, String actionText)
    {
        GameObject newActionButton;
        newActionButton = Instantiate(_current.buttonPrefab, _current.scrollableList);

        newActionButton.name = actionText;
        newActionButton.GetComponentInChildren<TextMeshProUGUI>().text = actionText;

        newActionButton.GetComponent<Button>().onClick.AddListener(() => act());
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(_current.scrollableList.GetComponent<RectTransform>());
    }

    public static void RemoveActionFromMenu(String actionText)
    {
        Transform[] allChildren = _current.scrollableList.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == actionText)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public static void RemoveAllActionsFromMenu()
    {
        Transform[] allChildren = _current.scrollableList.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.transform != _current.scrollableList)
            {
                Destroy(child.gameObject);
            }
        }

        Debug.Log("Done removing actions");
    }

    public static void TurnMenuOn()
    {
        _current.animator.SetBool("IsOpen", true);
    }

    public static void TurnMenuOff()
    {
        _current.animator.SetBool("IsOpen", false);
    }
}
