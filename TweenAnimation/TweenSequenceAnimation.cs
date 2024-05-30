using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class TweenSequenceAnimation : MonoBehaviour, ITweenAnimation
    {
        [TabGroup("Settings Sequence"), SerializeField] 
        private GameObject Base;
        [TabGroup("Settings Sequence"), SerializeField] 
        private EShow _showOnAction;
        [TabGroup("Settings Sequence"), SerializeField] 
        private float _startDelay;
        [TabGroup("Settings Sequence"), SerializeField] 
        private bool _ignoreTimeScale;
        [TabGroup("Settings Sequence"), SerializeField] 
        private bool _deActivateOnShowComplete;
        [TabGroup("Settings Sequence"), SerializeField] 
        private SequenceOption _showOption;
        [TabGroup("Settings Sequence"), SerializeField] 
        private SequenceOption _hideOption;
        
        [TabGroup("Sequence Debug"), HideLabel, SerializeField]
        private AnimationDebug _sequenceDebugOption;
        
        private void Awake()
        {
            _sequenceDebugOption = new AnimationDebug(this);
            ResetAnimation();
            if (_showOnAction == EShow.Awake) Show();
        }
        
        private void OnEnable()
        {
            ResetAnimation();
            if (_showOnAction == EShow.Enable) Show();
        }

        private void ResetAnimation()
        {
            Base.gameObject.SetActive(false);
            for (var i = 0; i < _showOption.Sequences.Length; i++)
                _showOption.Sequences[i].TweenAnimation.gameObject.SetActive(false);
            for (var i = 0; i < _hideOption.Sequences.Length; i++)
                _hideOption.Sequences[i].TweenAnimation.gameObject.SetActive(false);
        }

        public void Show(float durationDelta = 1f, TweenCallback onComplete = null)
        {
            gameObject.SetActive(true);
            StartCoroutine(IEDelaySequence(() =>
                StartCoroutine(IERunSequence(_showOption, durationDelta, onComplete))));
        }
        
        public void Hide(float durationDelta = 1f)
        {
            gameObject.SetActive(true);
            StartCoroutine(IEDelaySequence(() =>
                StartCoroutine(IERunSequence(_hideOption))));
        }
        
        
        IEnumerator IEDelaySequence(Action onComplete)
        {
            if (_ignoreTimeScale)
                yield return new WaitForSecondsRealtime(_startDelay);
            else
                yield return new WaitForSeconds(_startDelay);
            onComplete.Invoke();
        }
        
        IEnumerator IERunSequence(SequenceOption sequenceOption, float durationDelta = 1f, TweenCallback onComplete = null)
        {
            bool complete = false;
            for (int i = 0; i < sequenceOption.Sequences.Length; i++)
            {
                AnimationSequenceSetting animationSequenceSetting = sequenceOption.Sequences[i];
                animationSequenceSetting.TweenAnimation.Show(durationDelta, () => complete = true);
                yield return new WaitUntil(() => complete);
                if(_deActivateOnShowComplete) animationSequenceSetting.TweenAnimation.gameObject.SetActive(false);
                if (animationSequenceSetting.IsShowBase) ToggleBase(true);
                if(animationSequenceSetting.IsHideBase) ToggleBase(false);
                complete = false;
            }
            onComplete?.Invoke();
        }

        private void ToggleBase(bool isEnable)
        {
            TweenAnimation animation = Base.GetComponent<TweenAnimation>();
            if (animation != null && isEnable)
                animation.Show();
            else if (animation == null && isEnable)
                Base?.SetActive(true);
            if (animation != null && !isEnable)
                animation.Hide();
            else if (animation == null && !isEnable)
                Base?.SetActive(false);
        }
    }

    [System.Serializable, HideReferenceObjectPicker]
    public class SequenceOption
    {
        public AnimationSequenceSetting[] Sequences;
    }

    [System.Serializable]
    public class AnimationSequenceSetting
    {
        public TweenAnimation TweenAnimation;
        public bool IsShowBase;
        public bool IsHideBase;
    }
}