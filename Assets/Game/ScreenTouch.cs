using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTouch : MonoBehaviour
{

    public delegate void onScreenTouch(bool _touching);
    public static event onScreenTouch OnScreenTouch;

    public void OnClickScreen(bool pressed)
    {
        OnScreenTouch?.Invoke(pressed);
    }
}
