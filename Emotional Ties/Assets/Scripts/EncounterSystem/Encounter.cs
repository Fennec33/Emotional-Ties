using System.Collections;
using System.Collections.Generic;
using Chapters;
using UnityEngine;

public class  Encounter : MonoBehaviour
{
    public AspectData[] aspects;
    public Link[] links;

    private Chapter _currentChapter;
    private Link _currentLink;

    public void StartEncounter(Chapter chapter)
    {
        _currentChapter = chapter;
        
        foreach (AspectData aspect in aspects)
        {
            EncounterBoardManager.AddAspectToBoard(aspect);
        }
        
        
        ActionMenuManager.TurnMenuOn();
    }

    public void EndEncounter()
    {
        ActionMenuManager.TurnMenuOff();
        EncounterBoardManager.RemoveAllAspects();
        Connection.GetMainConnection().HideConnection();
    }
    
    public bool TestLink(string[] aspects)
    {
        foreach (Link link in links)
        {
            if (link.IsEqualTo(aspects))
            {
                _currentLink = link;
                link.startLink.Invoke();
                return true;
            }
        }
        
        return false;
    }

    public void LinkIsBroken()
    {
        if (_currentLink != null)
        {
            _currentLink.endLink.Invoke();
            _currentLink = null;
        }
    }
}
