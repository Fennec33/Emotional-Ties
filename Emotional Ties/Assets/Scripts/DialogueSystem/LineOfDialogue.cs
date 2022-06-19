using UnityEngine;

namespace DialogueSystem
{
    [System.Serializable]
    public struct LineOfDialogue
    {
        [SerializeField] string _name; 
    
        [TextArea(4, 10)]
        [SerializeField] string _sentence;

        public string GetName()
        {
            return _name;
        }
    
        public string GetSentence()
        {
            return _sentence;
        }
    }
}
