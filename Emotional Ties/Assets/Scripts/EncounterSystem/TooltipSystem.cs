using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem _current;

    [SerializeField] Tooltip tooltip;

    public void Awake()
    {
        _current = this;
    }

    public static void Show(string header, string content)
    {
        _current.tooltip.SetText(header, content);
        _current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        _current.tooltip.gameObject.SetActive(false);
    }
}
