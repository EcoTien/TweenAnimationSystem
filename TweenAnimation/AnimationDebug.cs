using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    [System.Serializable]
    public class AnimationDebug
    {
        private TweenAnimation _tweenAnimation;

        public AnimationDebug(TweenAnimation tweenAnimation)
        {
            _tweenAnimation = tweenAnimation;
        }

        [Button("Show")]
        public void Show()
        {
            if (Application.isPlaying)
                _tweenAnimation.Show();
        }

        [Button("Hide")]
        public void Hide()
        {
            if (Application.isPlaying)
                _tweenAnimation.Hide();
        }
    }
}