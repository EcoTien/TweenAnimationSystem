using System;
using Eco.TweenAnimation;
using Sirenix.OdinInspector;
using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    [SerializeField] private TweenAnimation[] _tweenAnimations;
    
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

    [Button("Get All Child Animation")]
    public void GetAllChildAnimation()
    {
        _tweenAnimations = transform.GetComponentsInChildren<TweenAnimation>();
    }

    private void Awake()
    {
        this.RegisterScreenToggle();
    }

    private void OnDestroy()
    {
        this.RemoveScreenToggle();
    }

    public void Toggle(bool isEnable)
    {
        foreach (var tweenAnimation in _tweenAnimations)
        {
            if(isEnable)
                tweenAnimation.Show();
            else
                tweenAnimation.Hide();
        }
    }
}