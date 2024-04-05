using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class FadeAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private CanvasGroup _canvasGroup;
        private CanvasGroupOptions _options;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _canvasGroup = animationFactory.TweenAnimation.CanvasGroup;
            _options = animationFactory.TweenAnimation.CanvasGroupOptions;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            if (_options.BlockRaycast) _canvasGroup.blocksRaycasts = false;
            //_canvasGroup.alpha = _options.From;
            
            return _canvasGroup
                .DOFade(_options.To, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta).OnComplete(OnShowComplete);
        }

        private void OnShowComplete()
        {
            if (_options.BlockRaycast) _canvasGroup.blocksRaycasts = true;
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            if (_options.BlockRaycast) _canvasGroup.blocksRaycasts = false;
            //_canvasGroup.alpha = _options.To;
            
            return _canvasGroup
                .DOFade(_options.From, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}