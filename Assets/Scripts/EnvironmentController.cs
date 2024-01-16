using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private float _CombatFog = .01f;
    [SerializeField] private float _TacticFog = 0;
    private void Awake()
    {
        RenderSettings.fogDensity = _TacticFog;
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
        if (newGameMode == GameMode.COMBAT)
        {
            RenderSettings.fogDensity = _CombatFog;
        }
        else
        {
            RenderSettings.fogDensity = _TacticFog;
        }
    }
}

