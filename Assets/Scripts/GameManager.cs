using PlasticBand.Devices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver,
        LevelUp
    }
    public GameState currentState;

    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject levelUpScreen;
    public GameObject gameHUD;

    bool choosingUpgrade = false;
    AudioSource levelUpSound;
    public GameObject player;

    Turntable turntable;

    private void Awake()
    {//using a singleton means any script can access it
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("gamemanager singleton error");
        }
        levelUpSound = GetComponent<AudioSource>();
        DisableScreens();
        turntable = Turntable.current;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;
            case GameState.Paused:
                CheckForPauseAndResume();
                break;
            case GameState.GameOver:
                break;
            case GameState.LevelUp:
                if (!choosingUpgrade)
                {
                    choosingUpgrade = true;
                    Time.timeScale = 0f;
                    gameHUD.SetActive(false);
                    levelUpScreen.SetActive(true);
                }
                break;
            default:
                Debug.LogWarning("invalid state");
                break;
        }
    }
    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }
    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            gameHUD.SetActive(false);
            turntable.PauseHaptics();
            Debug.Log("game paused");
        }
    }
    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            gameHUD.SetActive(true);
            turntable.ResumeHaptics();
            Debug.Log("game resumed");
        }
    }
    public void CheckForPauseAndResume()
    {
        if (turntable.buttonNorth.wasReleasedThisFrame)
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void StartLevelUp()
    {
        levelUpSound.Play();
        ChangeState(GameState.LevelUp);
    }
    public void EndLevelUp()
    {
        choosingUpgrade = false;
        Time.timeScale = 1f;
        levelUpScreen.SetActive(false);
        gameHUD.SetActive(true);
        ChangeState(GameState.Gameplay);
    }

    private void DisableScreens()
    {
        pauseScreen.SetActive(false);
        levelUpScreen.SetActive(false);
    }



}
