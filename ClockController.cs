using System;
using Enumerators;
using Events;
using Sounds;
using TMPro;
using Unity.Netcode;
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

        public bool isMultiplayer = false;

        void Start()
        {
            isMultiplayer = GetComponent<ScriptableObjDefaults>().isMultiplayer;
            StartButtonUI.onClick.AddListener(StartClockCheck);
            TapButtonUI.onClick.AddListener(ChangePlayerOnClockCheck);
            ResetButtonUI.onClick.AddListener(ResetClockCheck);
            
            ClockNetworkEvents.NetworkClockReset.AddListener(ResetClock);
            ClockNetworkEvents.NetworkClockTap.AddListener(ChangePlayerOnClock);
            ClockNetworkEvents.NetworkClockStart.AddListener(StartClock);
            SetClockData();
        }
        
        public ClockController()
        {
            ClockEvents.ClockTimeEndedEvent.AddListener(arg =>
            {
                if(currentPlayerOnClock == PlayerPiece.White)
                    Debug.Log("Game has ended! White lost on time!");
                else
                    Debug.Log("Game has ended! Black lost on time!");
                });
        }
        public void ChangePlayerOnClock()
        {
            currentPlayerOnClock = currentPlayerOnClock == PlayerPiece.White
                ? PlayerPiece.Black
                : PlayerPiece.White;

            ClockEvents.ChangePlayerEvent.Invoke(currentPlayerOnClock);
        }

        public void ResetClock()
        {
            currentClockState = ClockState.Pause;
            currentPlayerOnClock = PlayerPiece.White;

            SetClockData();
            ClockEvents.PauseClockEvent.Invoke();
            ClockEvents.ChangeClockStateEvent.Invoke(currentClockState);
            StartButton.SetActive(true);
            TapButton.SetActive(false);
            // Missing button switches?
        }
        
        public void StartClock()
        {
            SetClockData();
            ClockEvents.ChangePlayerEvent.Invoke(currentPlayerOnClock);
            ClockEvents.ChangeClockStateEvent.Invoke(currentClockState);
            StartButton.SetActive(false);
            TapButton.SetActive(true);
            // Missing button switches again?
        }

        public void SetClockData()
        {
            int clockTime = ClockTime;
            int extraSeconds = ClockExtraTime;
            
            ClockEvents.ConfigureClockEvent.Invoke(new ConfigureClockEventData(clockTime, extraSeconds));
        }
        
        public void StartClockCheck()
        {
            if (isMultiplayer)
            {
                GetComponent<ScriptableNetworkBridge>().StartOverNetworkServerRpc();
            }
            else
            {
                StartClock();
            }
        }

        public void ChangePlayerOnClockCheck()
        {
            if (isMultiplayer)
            {
                GetComponent<ScriptableNetworkBridge>().TapOverNetworkServerRpc();
            }
            else
            {
                ChangePlayerOnClock();
            }
        }
        public void ResetClockCheck()
        {
            if (isMultiplayer)
            {
                GetComponent<ScriptableNetworkBridge>().ResetOverNetworkServerRpc();
            }
            else
            {
                ResetClock();
            }
        }
        
    }