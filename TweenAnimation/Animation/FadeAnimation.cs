using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class FadeAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private CanvasGroup _canvasGroup;
        private BaseOptions _options;
        private CanvasGroupOptions _customOptions;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _canvasGroup = animationFactory.TweenAnimation.CanvasGroup;
            _options = animationFactory.TweenAnimation.BaseOptions;
            _customOptions = animationFactory.TweenAnimation.CanvasGroupOptions;
            _customOptions.To = _canvasGroup.alpha;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            if (_customOptions.BlockRaycast) _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = _customOptions.From;
            
            return _canvasGroup
                .DOFade(_customOptions.To, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta)
                .OnComplete(OnShowComplete);
        }

        private void OnShowComplete()
        {
            if (_customOptions.BlockRaycast) _canvasGroup.blocksRaycasts = true;
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            if (_customOptions.BlockRaycast) _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = _customOptions.To;
            
            return _canvasGroup
                .DOFade(_customOptions.From, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}