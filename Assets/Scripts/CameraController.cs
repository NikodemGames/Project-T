using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _CombatCam;
    [SerializeField] private CinemachineVirtualCamera _TacticCam;
    private void Awake()
    {
        _TacticCam.Priority = 10;
        _CombatCam.Priority = 0;
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
        Debug.Log("Current gamemode is: " + newGameMode);
        if (newGameMode == GameMode.COMBAT)
        {
            _CombatCam.Priority = 10;
            _TacticCam.Priority = 0;
        }
        else
        {
            _TacticCam.Priority = 10;
            _CombatCam.Priority = 0;
        }
    }
}
