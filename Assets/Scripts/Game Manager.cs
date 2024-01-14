using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameMode
{
    COMBAT,
    TACTIC
}
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    #endregion

    [SerializeField] private GameMode currentGameMode;
    public delegate void OnGameModeChanged(GameMode newGameMode);
    public static event OnGameModeChanged GameModeChanged;
    private void Start()
    {
        currentGameMode = GameMode.TACTIC;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchGameMode();
        }
    }

    private void SwitchGameMode()
    {
        currentGameMode = (currentGameMode == GameMode.COMBAT) ? GameMode.TACTIC : GameMode.COMBAT;
        HandleGameModeSwitch();
    }

    private void HandleGameModeSwitch()
    {
        Debug.Log("Current game mode is: " +  currentGameMode);
    }
}
