using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Aspect", menuName = "Aspect Data")]
public class AspectData : ScriptableObject
{
    public Sprite icon;
    public Color color;
    public new string name;
    public string description;
}
