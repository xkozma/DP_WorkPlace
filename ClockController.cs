using System;
using Enumerators;
using Events;
using Sounds;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : ScriptableObj
    {
        private ClockState currentClockState;
        private PlayerPiece currentPlayerOnClock;

        public int ClockTime;
        public int ClockExtraTime;

        public GameObject StartButton;
        public GameObject TapButton;

        public Button StartButtonUI;
        public Button TapButtonUI;
        public Button ResetButtonUI;
        private ClockEventsBridge clockEventsBridge;

        void Start()
        {
            StartButtonUI.onClick.AddListener(StartClock);
            TapButtonUI.onClick.AddListener(ChangePlayerOnClock);
            ResetButtonUI.onClick.AddListener(ResetClock);
            SetClockData();
        }
        
        public ClockController()
        { //hhh




            ClockEvents.ClockTimeEndedEvent.AddListener(arg =>
            {
                if(currentPlayerOnClock == PlayerPiece.White)
                    Debug.Log("Game has ended! White lost on time!");
                else
                    Debug.Log("Game has ended! Black lost on time!");
                });
        }

        public void PlayPauseClock()
        {
            switch (currentClockState)
            {
                case ClockState.Play:
                    ClockEvents.PauseClockEvent.Invoke();
                    currentClockState = ClockState.Pause;
                    InGameSoundManager.StopLoopSound();
                    break;
                case ClockState.Pause:
                    ClockEvents.ChangePlayerEvent.Invoke(currentPlayerOnClock);
                    currentClockState = ClockState.Play;
                    InGameSoundManager.PlayLoopSound(LoopSound.ClockTick, MainAssets.I.soundSettings.clockTick);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentClockState), currentClockState,
                        "ClockState not implemented");
            }

            ClockEvents.ChangeClockStateEvent.Invoke(currentClockState);
        }

        public void ResetClock()
        {
            currentClockState = ClockState.Pause;
            currentPlayerOnClock = PlayerPiece.White;

            SetClockData();
            ClockEvents.PauseClockEvent.Invoke();
            ClockEvents.ChangeClockStateEvent.Invoke(currentClockState);

	    // Missing button switches?
        StartButton.SetActive(true);
        TapButton.SetActive(false);

        }

        public void StartClock()
        {
                SetClockData();
                ClockEvents.ChangePlayerEvent.Invoke(currentPlayerOnClock);
                ClockEvents.ChangeClockStateEvent.Invoke(currentClockState);
		// Missing button switches again?
        StartButton.SetActive(false);
        TapButton.SetActive(true);
        }

        public void SetClockData()
        {
            int clockTime = ClockTime;
            int extraSeconds = ClockExtraTime;
            
            ClockEvents.ConfigureClockEvent.Invoke(new ConfigureClockEventData(clockTime, extraSeconds));
        }

        public void ChangePlayerOnClock()
        {
            currentPlayerOnClock = currentPlayerOnClock == PlayerPiece.White
                ? PlayerPiece.Black
                : PlayerPiece.White;

            ClockEvents.ChangePlayerEvent.Invoke(currentPlayerOnClock);
        }
    }