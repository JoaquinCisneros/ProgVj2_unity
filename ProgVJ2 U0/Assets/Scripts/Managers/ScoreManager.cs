using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int currentScore;
    private int highScore;

    private void Awake()
    {
        // Patron singleton de instanciar una sola vez
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore(); // Cargar el puntaje m�s alto al iniciar
    }

    // Incrementar el puntaje actual
    public void AddPoints(int points)
    {
        currentScore += points;
        Debug.Log("Score: " + currentScore);

        // Actualizar el puntaje m�s alto si corresponde
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    // Guardar el puntaje m�s alto en PlayerPrefs
    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        Debug.Log("HighScore: " + highScore);
    }

    // Cargar el puntaje m�s alto desde PlayerPrefs
    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("Puntaje m�s alto cargado: " + highScore);
    }

    // Reiniciar el puntaje
    public void ResetCurrentScore()
    {
        currentScore = 0;
    }
}

