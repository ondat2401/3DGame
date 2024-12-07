using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float currentEnergy;

    [Header("Saveable Item")]
    public int allCoin;
    public float bestScore;

    [Header("Game Stats")]
    public int currentCoin;
    public float currentScore;

    private void OnEnable()
    {
        allCoin = DataManager.LoadInt("AllCoin", 0);
        bestScore = DataManager.LoadFloat("BestScore", 0f);
    }
    private void InitializePlayer()
    {
        currentEnergy = 0;
        currentCoin = 0;
        currentScore = 0;
        allCoin = DataManager.LoadInt("AllCoin", 0);
        bestScore = DataManager.LoadFloat("BestScore", 0f); 
    }
    private void Start()
    {
        InitializePlayer();
    }
    private void Update()
    {
        ScoreManager();
        UpdateGUI();
    }
    private void UpdateGUI()
    {
        GUIManager gui = GameManager.instance.guiManager;
        if (gui != null)
        {
            gui.currentScore.text = currentScore.ToString();
            gui.currentCoin.text = currentCoin.ToString();
        }
    }

    private void ScoreManager()
    {
        if (GameManager.instance.gameState == GameState.Playing)
        {
            currentScore += (int)(GameManager.instance.roadManager.currentSpeed * .2f);
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                DataManager.SaveFloat("BestScore", bestScore);
            }
        }
    }
    public void SaveAllCoin()
    {
        allCoin += currentCoin;
        DataManager.SaveInt("AllCoin", allCoin);
    }
    public void CollectCoin()
    {
        currentCoin += 1;
    }
}

