using System;
using System.Collections;
using DG.Tweening;
using Eco.TweenAnimation;
using Sirenix.OdinInspector;
using UnityEngine;

public class TweenSequenceCustom : MonoBehaviour, ITweenAnimation
{
    [SerializeField] private EShow _showOnAction;
    [SerializeField] private AnimationCustom[] _showAnimation;
    [SerializeField] private AnimationCustom[] _hideAnimation;
    [SerializeField, HideLabel] private AnimationDebug _debug;
    
    private void Awake()
    {
        _debug = new AnimationDebug(this);
        if (_showOnAction == EShow.Awake) Show();
    }
        
    private void OnEnable()
    {
        if (_showOnAction == EShow.Enable) Show();
    }

    public void Show(float durationDelta = 1, TweenCallback onComplete = null)
    {
        gameObject.SetActive(true);
        foreach (var animationCustom in _showAnimation)
        {
            animationCustom.TweenAnimation.gameObject.SetActive(false);
            DOVirtual.DelayedCall(animationCustom.DelayShow, () =>
            {
                animationCustom.TweenAnimation.gameObject.SetActive(true);
                animationCustom.TweenAnimation.Show(durationDelta, () =>
                {
                    if(animationCustom.DeActivateOnComplete) animationCustom.TweenAnimation.gameObject.SetActive(false);
                    onComplete?.Invoke();
                });
            });
        }
    }

    public void Hide(float durationDelta = 1)
    {
        foreach (var animationCustom in _hideAnimation)
        {
            DOVirtual.DelayedCall(animationCustom.DelayShow, () =>
            {
                animationCustom.TweenAnimation.gameObject.SetActive(true);
                animationCustom.TweenAnimation.Hide();
                if (animationCustom.DeActivateOnComplete)
                {
                    DOVirtual.DelayedCall(animationCustom.TweenAnimation.BaseOptions.Duration, () =>
                    {
                        animationCustom.TweenAnimation.gameObject.SetActive(false);
                    });
                }
            });
        }
    }
    
    [System.Serializable]
    public class AnimationCustom
    {
        public TweenAnimation TweenAnimation;
        public bool DeActivateOnComplete;
        public float DelayShow;
    }
}