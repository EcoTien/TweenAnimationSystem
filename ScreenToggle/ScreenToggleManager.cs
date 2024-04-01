﻿using System.Collections.Generic;

public static class ScreenToggleManager
{
    private static List<ScreenToggle> _currentScreenToggles = new();

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
        foreach (var currentScreenToggle in _currentScreenToggles)
        {
            if(currentScreenToggle.gameObject.activeInHierarchy)
                currentScreenToggle.Toggle(isEnable, durationDelta);
        }
    }
}