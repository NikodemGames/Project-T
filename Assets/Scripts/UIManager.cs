using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _PlayerStats;
    [SerializeField] private float _CombatFog =.01f;
    [SerializeField] private float _TacticFog = 0;
    private void Awake()
    {
        _PlayerStats.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.GameModeChanged += HandleGameModeChanged;
    }
    private void OnDisable()
    {
        GameManager.GameModeChanged -= HandleGameModeChanged;
    }

    private void HandleGameModeChanged(GameMode newGameMode)
    {
        Debug.Log("Current gamemode is: " +  newGameMode);
        if(newGameMode == GameMode.COMBAT)
        {
            _PlayerStats.gameObject.SetActive(true);
        }
        else
        {
            _PlayerStats.gameObject.SetActive(false);
        }
    }
}
