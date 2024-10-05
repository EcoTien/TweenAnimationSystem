using System.Collections.Generic;

namespace Eco.TweenAnimation
{
    public static class ScreenToggleManager
    {
        private static List<ScreenToggle> _currentScreenToggles = new();
        private static bool _isToggle = true;
        public static bool IsToggle => _isToggle;

        public static void RegisterScreenToggle(this ScreenToggle screenToggle)
        {
            _currentScreenToggles.Add(screenToggle);
        }

        public static void RemoveScreenToggle(this ScreenToggle screenToggle)
        {
            _currentScreenToggles.Remove(screenToggle);
        }

        public static void Toggle(bool isEnable, float durationDelta = 1f)
        {
            _isToggle = isEnable;
            foreach (var currentScreenToggle in _currentScreenToggles)
            {
                if (currentScreenToggle.gameObject.activeInHierarchy)
                    currentScreenToggle.Toggle(isEnable, durationDelta);
            }
        }
    }
}