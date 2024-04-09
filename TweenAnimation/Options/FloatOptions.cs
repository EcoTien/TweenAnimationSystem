using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    [System.Serializable]
    public class FloatOptions : BaseOptions
    {
        [FoldoutGroup("Custom Options")] public float From = 0;
        [FoldoutGroup("Custom Options"), HideInInspector] public float To = 1;
    }
}