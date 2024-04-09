using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public enum EAnimation { Move, MoveLocal, MoveArchors, Scale, Rotation, Fade }
    public enum EShow { None, Awake, Enable }
    
    [HideMonoScript]
    public class TweenAnimation : MonoBehaviour
    { 
        /// <summary>
        /// Animation Setting Group
        /// </summary>
        [SerializeField, LabelText("Select Animation"), TabGroup("Animation Setting")] 
        private EAnimation _animation;
        [SerializeField, LabelText("Show On Action"), TabGroup("Animation Setting")] 
        private EShow _showOn = EShow.Awake;
        
        [SerializeField, LabelText("Canvas Group"), TabGroup("Animation Setting"), ShowIf("@IsFadeAnimation()")]
        private CanvasGroup _canvasGroup;
        
        [SerializeField, HideLabel, TabGroup("Animation Setting"), ShowIf("@IsVector3Animation()")] 
        private Vector3Options _vector3Options;
        [SerializeField, HideLabel, TabGroup("Animation Setting"), ShowIf("@IsFadeAnimation()")] 
        private CanvasGroupOptions _canvasGroupOptions;
        
        /// <summary>
        /// Animation Setting Group
        /// </summary>
        [SerializeField, HideLabel, TabGroup("Animation Debug")] 
        internal AnimationDebug _animationDebug;
        private AnimationFactory _factory;
        private IAnimation _ianimation;
        
        public EAnimation Animation { get => _animation; }
        public CanvasGroup CanvasGroup { get => _canvasGroup; }
        public Vector3Options Vector3Options { get => _vector3Options; }
        public CanvasGroupOptions CanvasGroupOptions { get => _canvasGroupOptions; }

        [OnInspectorInit]
        private void InitializedDebug()
        {
            _animationDebug = new AnimationDebug(this);
        }
        
        private void Awake()
        {
            _ianimation = GetFactory().CreateAnimation();
            if(_showOn == EShow.Awake) 
                Show();
        }

        private void OnEnable()
        {
            if(_showOn == EShow.Enable) 
                Show();
        }

        public void Show(float durationDelta = 1f)
        {
            _ianimation.Show(durationDelta);
        }

        public void Hide(float durationDelta = 1f)
        {
            _ianimation.Hide(durationDelta);
        }

        private AnimationFactory GetFactory()
        {
            _factory ??= new AnimationFactory(this);
            return _factory;
        }

        private bool IsFadeAnimation()
        {
            return _animation == EAnimation.Fade;
        }
        
        private bool IsVector3Animation()
        {
            return _animation != EAnimation.Fade;
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            if (IsFadeAnimation() && _canvasGroup == null)
            {
                if (!TryGetComponent(out _canvasGroup))
                    _canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
#endif
    }   
}
