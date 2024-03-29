using Sirenix.OdinInspector;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public enum EAnimation { Move, MoveLocal, MoveArchors, Scale, Rotation }
    public enum EShow { None, Awake, Enable }
    
    [HideMonoScript]
    public class TweenAnimation : MonoBehaviour
    { 
        /// <summary>
        /// Animation Setting Group
        /// </summary>
        [SerializeField, LabelText("Select Animation"), TabGroup("Animation Setting")] 
        private EAnimation _animation;
        [SerializeField, LabelText("Show On Action"),TabGroup("Animation Setting")] 
        private EShow _showOn = EShow.Awake;
        [SerializeField, HideLabel, TabGroup("Animation Setting")] 
        private Vector3Options _vector3Options;
        
        /// <summary>
        /// Animation Setting Group
        /// </summary>
        [SerializeField, HideLabel, TabGroup("Animation Debug")] 
        private AnimationDebug _animationDebug;

        private AnimationFactory _factory;
        
        public EAnimation Animation { get => _animation; }
        public Vector3Options Vector3Options { get => _vector3Options; }

        [OnInspectorInit]
        private void InitializedDebug()
        {
            _animationDebug = new AnimationDebug(this);
        }
        
        private void Awake()
        {
            if(_showOn == EShow.Awake) Show();
        }

        private void OnEnable()
        {
            if(_showOn == EShow.Enable) Show();
        }

        public void Show()
        {
            IAnimation animation = GetFactory().CreateAnimation();
            animation.Show();
        }

        public void Hide()
        {
            IAnimation animation = GetFactory().CreateAnimation();
            animation.Hide();
        }

        private AnimationFactory GetFactory()
        {
            _factory ??= new AnimationFactory(this);
            return _factory;
        }
    }   
}
