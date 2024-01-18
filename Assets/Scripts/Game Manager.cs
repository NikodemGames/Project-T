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
        currentGameMode = GameMode.TACTIC;
    }

    #endregion

    [SerializeField] private GameMode currentGameMode;
    public delegate void OnGameModeChanged(GameMode newGameMode);
    public static event OnGameModeChanged GameModeChanged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchGameMode();
        }
    }

    public void SwitchGameMode()
    {
        currentGameMode = (currentGameMode == GameMode.COMBAT) ? GameMode.TACTIC : GameMode.COMBAT;
        GameModeChanged?.Invoke(currentGameMode);
    }

}
