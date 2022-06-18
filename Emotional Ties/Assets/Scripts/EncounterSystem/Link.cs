using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Link
{
    public string aspect1;
    public string aspect2;

    [SerializeField] public UnityEvent startLink;
    [SerializeField] public UnityEvent endLink;

    public bool IsEqualTo(string[] testAspects)
    {
        if (aspect1 == testAspects[0] && aspect2 == testAspects[1])
        {
            return true;
        }
        
        if (aspect1 == testAspects[1] && aspect2 == testAspects[0])
        {
            return true;
        }

        return false;
    }
}
