using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;

    private Vector2 _newPivot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string header, string content)
    {
        headerField.text = header;
        contentField.text = content;
        
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled =
            (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    private void Update()
    {
        Vector2 position = Input.mousePosition;
        transform.position = position;

        if (position.x / Screen.width > 0.7)
        {
            _newPivot.x = 1;
        }
        else
        {
            _newPivot.x = 0;
        }
        
        if (position.y/ Screen.height > 0.7)
        {
            _newPivot.y = 1;
        }
        else
        {
            _newPivot.y = 0;
        }
        
        rectTransform.pivot = _newPivot;
        
    }
}
