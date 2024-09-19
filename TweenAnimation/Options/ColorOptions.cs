using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Eco.TweenAnimation
{
    [System.Serializable]
    public class ColorOptions
    {
        [FoldoutGroup("Custom Options")] public Color From = Color.white;
        [FoldoutGroup("Custom Options")] public Color EndTo = Color.black;
    }
}