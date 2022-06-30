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

    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private AudioClip connectAudio;
    [SerializeField] private AudioClip rejectAudio;
    

    public void StartEncounter(Chapter chapter)
    {
        _currentChapter = chapter;
        
        foreach (AspectData aspect in aspects)
        {
            EncounterBoardManager.AddAspectToBoard(aspect);
        }
        
        
        ActionMenuManager.TurnMenuOn();
    }

    public void AddValidLink(Link newLink)
    {
        Link[] tempLinks = new Link[links.Length + 1];

        for (int i = 0; i < links.Length; i++)
        {
            tempLinks[i] = links[i];
        }
        
        tempLinks[tempLinks.Length-1] = newLink;
        links = tempLinks;
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
                audioManager.PlaySoundEffect(connectAudio);
                return true;
            }
        }
        audioManager.PlaySoundEffect(rejectAudio);
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
