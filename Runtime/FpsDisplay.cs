﻿using UnityEngine;

namespace HMUtilities.Runtime
{
    /// <summary>
    /// Displays the current frames per second (FPS) on the screen.
    /// </summary>
    public sealed class FpsDisplay : MonoBehaviour
    {
        #region Fields
        [Header("Fps Display Settings")]
        [SerializeField] private bool show = true;
        [SerializeField] private Rect rect = new(960, 540, 128, 64);
        [Range(0f, 1f)][SerializeField] private float updateInterval = .5f;
        private float _accum;
        private int _frames;
        private float _timeLeft;
        private float _fps;
        private readonly GUIStyle _textStyle = new();
        #endregion

        #region Core
        private void Initialize()
        {
            _timeLeft = updateInterval;

            _textStyle.fontStyle = FontStyle.Bold;
            _textStyle.normal.textColor = Color.white;
        }
        private void Start() => Initialize();
        #endregion

        #region Executes
        private void CalculateFPS()
        {
            _timeLeft -= Time.deltaTime;
            _accum += Time.timeScale / Time.deltaTime;
            _frames++;

            if (!(_timeLeft <= 0))
                return;
            
            _fps = _accum / _frames;
            _timeLeft = updateInterval;
            _accum = 0f;
            _frames = 0;
        }
        #endregion

        #region Updates
        private void Update() => CalculateFPS();
        #endregion

        #region OnGUI
        private void OnGUI()
        {
            if (!show)
                return;

            GUI.Label(rect, _fps.ToString("F2") + "FPS", _textStyle);
        }
        #endregion
    }
}