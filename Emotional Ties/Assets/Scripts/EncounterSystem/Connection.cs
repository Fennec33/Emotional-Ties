using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Connection : MonoBehaviour
{
    private static Connection _current;
    
    public LineRenderer lineRenderer;

    public Vector3[] points = new Vector3[2];

    public string[] aspects = new string[2];

    public Encounter encounter;

    private Camera _camera;
    private bool _dragging = false;

    private Transform _startAspectTransform;
    private Transform _endAspectTransform;

    [SerializeField] private Transform hidepoint;
    
    private void Awake()
    {
        _current = this;
        
        _camera = Camera.main;
        points[0] = transform.position;
        points[0].z = 0;
    }

    public static Connection GetMainConnection()
    {
        return _current;
    }

    public void HideConnection()
    {
        points[0].x = 1000;
        points[1].x = 1000;
        
        _startAspectTransform = hidepoint;
        _endAspectTransform = _startAspectTransform;
        
        _dragging = false;

        lineRenderer.SetPositions(points);
    }

    public void StartConnection(Vector3 location, string aspectName, Transform aspect)
    {
        _startAspectTransform = aspect;
        _endAspectTransform = _startAspectTransform;
        
        aspects[0] = aspectName;
        aspects[1] = "";
        
        points[0] = location;
        points[0].z = 0;

        _dragging = true;
    }
    
    public void EndConnection(Vector3 location, string aspectName, Transform aspect)
    {
        _endAspectTransform = aspect;
        
        aspects[1] = aspectName;
        
        points[1] = location;
        points[1].z = 0;

        _dragging = false;

        if (!encounter.TestLink(aspects))
        {
            points[1] = points[0];
            _endAspectTransform = _startAspectTransform;
        }
        
        lineRenderer.SetPositions(points);
    }
    

    private void Update()
    {
        if (_dragging)
        {
            points[1] = _camera.ScreenToWorldPoint(Input.mousePosition);
            points[1].z = 0;

            if (!Input.GetMouseButton(0))
            {
                points[1] = points[0];
                _dragging = false;
            }
            
            lineRenderer.SetPositions(points);
        }
        else
        {
            points[0] = _startAspectTransform.position;
            points[1] = _endAspectTransform.position;

            lineRenderer.SetPositions(points);
        }
    }

    private void OnMouseUp()
    {
        _dragging = false;
    }
}
