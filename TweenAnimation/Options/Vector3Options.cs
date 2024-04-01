using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    [System.Serializable]
    public class Vector3Options : BaseOptions
    {
        [FoldoutGroup("Custom Options")] public Vector3 From = Vector3.zero;
        [FoldoutGroup("Custom Options")] public Vector3 To = Vector3.one;
    }
}