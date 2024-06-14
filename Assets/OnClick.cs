using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;
using UnityEngine.Events;

public class OnClick : MonoBehaviour
{
    public UnityEvent _Event;

    private void OnMouseDown()
    {
        MasterAudioManager.Play2DSfx(AudioConst.Kill);
        _Event?.Invoke();
    }
}