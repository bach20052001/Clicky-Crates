using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameBaseState GameState;
    [SerializeField] private SpawnManager sm;

    public void TransitionState(GameBaseState newGameState)
    {
        switch (newGameState)
        {
            case GameBaseState.PREPLAY:
                PrePlay();
                break;
            case GameBaseState.PLAY:
                PlayGame();
                break;
            case GameBaseState.PAUSE:
                PauseGame();
                break;
            case GameBaseState.GAMEOVER:
                break;
        }
        GameState = newGameState;
    }

    private void PrePlay()
    {
        StartCoroutine(preplayHandler());
    }

    private IEnumerator preplayHandler()
    {
        yield return new WaitForSeconds(3);
        TransitionState(GameBaseState.PLAY);
    }

    private void PlayGame()
    {
        Time.timeScale = 1;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        if (this != instance)
        {
            Destroy(gameObject);
        }

        TransitionState(GameBaseState.PREPLAY);
    }

    private void Start()
    {
        this.RegisterListener(GameEvent.OnClickLevelButton, (param) => OnClickLevelButtonHandler());
        this.RegisterListener(GameEvent.OnHitBomb, (param) => OnHitBombHandler());

    }

    private void OnHitBombHandler()
    {
        TransitionState(GameBaseState.GAMEOVER);
    }

    private void OnClickLevelButtonHandler()
    {
        TransitionState(GameBaseState.PLAY);
        Instantiate(sm.gameObject, Vector3.zero, Quaternion.identity);
    }

    //Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
}
