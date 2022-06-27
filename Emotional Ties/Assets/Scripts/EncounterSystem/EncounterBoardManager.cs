using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EncounterBoardManager : MonoBehaviour
{
    private static EncounterBoardManager _current;

    public GameObject prefab;
    private static Vector3 _centerOfAspectCircle;
    [SerializeField] private float radiousOfAspectCircle;
    private static float _desiredAngleOfAspects;

    private List<GameObject> _aspects = new List<GameObject>();

    private void Awake()
    {
        _current = this;
        _centerOfAspectCircle = new Vector3(-10, 5, 0);
    }

    public static void AddAspectToBoard(AspectData newAspect)
    {
        GameObject temp = Instantiate(_current.prefab, _centerOfAspectCircle, Quaternion.identity);
        temp.GetComponent<Aspect>().SetAspect(newAspect);
        _current._aspects.Add(temp);
        
        _desiredAngleOfAspects = _current.CalculateDesiredAngleOfAspects(_current._aspects.Count);
        _current.MoveAspectsToDesiredLocations(_desiredAngleOfAspects);
    }

    private float CalculateDesiredAngleOfAspects(int numberOfAspects)
    {
        float angleOfAspects = 360f / numberOfAspects;
        return angleOfAspects;
    }

    private void MoveAspectsToDesiredLocations(float desiredAngleDistance)
    {
        int i = 1;
        foreach (var aspect in _current._aspects)
        {
            Aspect temp = aspect.GetComponent<Aspect>();
            temp.MoveToPositionAroundPoint(_centerOfAspectCircle, _current.radiousOfAspectCircle, _desiredAngleOfAspects * i);
            i++;
        }
    }

    public static void RemoveAspectFromBoard(AspectData aspectToRemove)
    {
        foreach (var aspect in _current._aspects)
        {
            Aspect temp = aspect.GetComponent<Aspect>();

            if (temp.GetAspectData() == aspectToRemove)
            {
                
                Destroy(aspect);
                _current._aspects.Remove(aspect);
                _desiredAngleOfAspects = _current.CalculateDesiredAngleOfAspects(_current._aspects.Count);
                _current.MoveAspectsToDesiredLocations(_desiredAngleOfAspects);
                return;
            }
        }
    }

    public static void RemoveAllAspects()
    {
        foreach (var aspect in _current._aspects)
        {
            Destroy(aspect);
        }
        _current._aspects.Clear();
    }
}
