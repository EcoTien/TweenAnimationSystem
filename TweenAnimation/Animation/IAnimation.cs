using DG.Tweening;

namespace Eco.TweenAnimation
{
    public interface IAnimation
    {
        public void Initialized(AnimationFactory animationFactory);
        public Tweener Show(float durationDelta = 1f);
        public Tweener Hide(float durationDelta = 1f);
    }
}