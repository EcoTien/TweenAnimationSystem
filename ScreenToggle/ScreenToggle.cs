﻿using System;
using Eco.TweenAnimation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class ScreenToggle : MonoBehaviour
    {
        private TweenAnimation[] _tweenAnimations;
    
        [Button("Show All")]
        public void ShowAll()
        {
            foreach (var tweenAnimation in _tweenAnimations)
                tweenAnimation.Show();
        }
        
        [Button("Hide All")]
        public void HideAll()
        {
            foreach (var tweenAnimation in _tweenAnimations)
                tweenAnimation.Hide();
        }
    
        private void Awake()
        {
            _tweenAnimations = GetComponentsInChildren<TweenAnimation>(true);
            this.RegisterScreenToggle();
        }
    
        private void OnDestroy()
        {
            this.RemoveScreenToggle();
        }
    
        public void Toggle(bool isEnable, float durationDelta = 1f)
        {
            foreach (var tweenAnimation in _tweenAnimations)
            {
                if(!tweenAnimation.IsRegisterScreenToggle)
                    continue;
                
                if (isEnable && !tweenAnimation.IsShow)
                    tweenAnimation.Show(durationDelta);
                else if(!isEnable && tweenAnimation.IsShow)
                    tweenAnimation.Hide(durationDelta);
            }
        }
    }
}
