using DG.Tweening;

namespace Eco.TweenAnimation
{
    public interface ITweenAnimation
    {
        public void Show(float durationDelta = 1f, TweenCallback onComplete = null);
        public void Hide(float durationDelta = 1f, TweenCallback onComplete = null);
    }
}