using System;
using System.Collections;
using Enumerators;
using Events;
using JetBrains.Annotations;
using Settings;
using Sounds;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : ScriptableObj
    {
        public Image timerBackground;
        public TimerSettings timerSettings;
        public PlayerPiece pieceColor;

        private int extraSeconds;
        private int clockMaxSeconds;
        private bool isClockRunning;
        public TimeSpan clockTime;
        public TextMeshProUGUI timerText;
        private ClockEventsBridge clockEventsBridge;
        void Start()
        {
            ClockEvents.ConfigureClockEvent.AddListener(SetTimer);
            ClockEvents.ChangePlayerEvent.AddListener(HandleClockTime);
            ClockEvents.PauseClockEvent.AddListener(ClockPause);
            
            FindObjectOfType<ClockController>().SetClockData();
        }
        

        private void SetTimer(ConfigureClockEventData data)
        {
            extraSeconds = data.ExtraSeconds;
            clockTime = TimeSpan.FromMinutes(data.ClockTime);
            clockMaxSeconds = (int)clockTime.TotalSeconds;
            
            UpdateTimerText();
        }
        
        private void HandleClockTime(PlayerPiece playerOnClock)
        {
            if (pieceColor == playerOnClock && gameObject.activeInHierarchy)
            {
                StartCoroutine(RunTimerRoutine());
            }
            else if (isClockRunning)
            {
                AddExtraTime();
                DisableClock();
                StopAllCoroutines();
            }
        }

        private void ClockPause()
        {
            isClockRunning = false;
            // Why isnt the timer gray anymore?
            timerBackground.color = Color.gray;

            StopAllCoroutines();
        }

        private TimeSpan GetClockTime()
        {
            return clockTime.Subtract(TimeSpan.FromSeconds(timerSettings.timeStep));
        }

        private void DisableClock()
        {
            timerBackground.color = Color.gray;
        }

        private void AddExtraTime()
        {
            if (extraSeconds <= 0) return;

            clockTime = clockTime.Add(TimeSpan.FromSeconds(extraSeconds));
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            ClockTimeState timeState = clockTime.TotalMinutes >= 1
                ? ClockTimeState.Minutes
                : ClockTimeState.Seconds;

            if (clockTime.TotalHours >= 1)
                timeState = ClockTimeState.Hours;
            if (timerText == null)
            {
                timerText = GetComponentInChildren<TextMeshProUGUI>();
            }

            ClockTimerData clockTimerData = timerSettings.GetClockTimerData(timeState);
            
            timerText.text = clockTime.ToString(clockTimerData.dateFormat);
            timerText.fontSize = clockTimerData.fontSize;
        }

        private void UpdateTimerColor()
        {
            float time = (float)clockTime.TotalSeconds / clockMaxSeconds;
            Color currentColor = timerSettings.colors.Evaluate(time);
            timerBackground.color = currentColor;
        }

        private IEnumerator RunTimerRoutine()
        {
            isClockRunning = true;
            WaitForSeconds wait = new WaitForSeconds(timerSettings.timeStep);

            while (clockTime.TotalSeconds > 0)
            {
                UpdateTimerText();
                UpdateTimerColor();
                clockTime = GetClockTime();
                yield return wait;
            }

            isClockRunning = false;
            UpdateTimerText();
            UpdateTimerColor();

	    // This looks important for other parts
            ClockEvents.ClockTimeEndedEvent.Invoke(pieceColor == PlayerPiece.Black ? PlayerPiece.White : PlayerPiece.Black);
        }
    }