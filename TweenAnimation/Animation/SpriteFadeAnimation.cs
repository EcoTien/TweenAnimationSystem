using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class SpriteFadeAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private SpriteRenderer _spriteRenderer;
        private BaseOptions _options;
        private FloatOptions _customOptions;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _spriteRenderer = animationFactory.TweenAnimation.SpriteRenderer;
            _options = animationFactory.TweenAnimation.BaseOptions;
            _customOptions = animationFactory.TweenAnimation.FloatOptions;
        }

        public void SetAnimationFrom()
        {
            _spriteRenderer.color = GetSpriteA(_customOptions.From);
        }

        private Color GetSpriteA(float time)
        {
            Color color = _spriteRenderer.color;
            color.a = time;
            return color;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            SetAnimationFrom();
            return _spriteRenderer
                .DOFade(_customOptions.EndTo, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            _spriteRenderer.color = GetSpriteA(_customOptions.EndTo);
            return _spriteRenderer
                .DOFade(_customOptions.From, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}