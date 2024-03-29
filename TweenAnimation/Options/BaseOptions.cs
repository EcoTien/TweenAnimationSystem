using DG.Tweening;
using Sirenix.OdinInspector;

namespace Eco.TweenAnimation
{
    public abstract class BaseOptions
    {
        [FoldoutGroup("Base Options")] public Ease ShowEase = Ease.Linear;
        [FoldoutGroup("Base Options")] public Ease HideEase = Ease.Linear;
        [FoldoutGroup("Base Options")] public float Duration = 0.1925f;
        [FoldoutGroup("Base Options")] public float StartDelay = 0f;
        [FoldoutGroup("Base Options")] public bool IgnoreTimeScale = false;
    }
}