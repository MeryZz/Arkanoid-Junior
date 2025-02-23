using UnityEngine;
using TMPro;
using System.Collections; // Añadido para IEnumerator

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text levelText;

    [Header("Game Settings")]
    public int score = 0;
    public int lives = 3;
    public int level = 1;
    public float ballSpeedMultiplier = 1.0f; // Aumenta con el nivel

    private Ball ballScript; // Referencia al script de la bola

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Recuperar el nivel desde PlayerPrefs
        level = PlayerPrefs.GetInt("Level", 1); // Si no existe el valor, por defecto es 1

        // Si el nivel no es 1 o 2, reiniciamos a 1 (en caso de errores o valores extraños)
        if (level != 1 && level != 2)
        {
            level = 1;
        }

        // Recuperar el puntaje desde PlayerPrefs
        score = PlayerPrefs.GetInt("Score", 0); // Si no existe, por defecto es 0
        
        // Reinicia las vidas cuando se entra al Level 2
        if (level == 2)
        {
            lives = 3;
            livesText.text = "Lives: " + lives;
        }

        UpdateUI();
    }

    private void Start()
    {
        // Obtener el componente Ball para poder modificar su velocidad
        ballScript = Object.FindFirstObjectByType<Ball>();

        StartCoroutine(IncreaseBallSpeed()); // Iniciar la corrutina para aumentar la velocidad
    }

    IEnumerator IncreaseBallSpeed()
    {
        while (true)
        {
            if (level == 1)
                yield return new WaitForSeconds(10f); // Aumenta cada 8 segundos en el Level 1
            else if (level == 2)
                yield return new WaitForSeconds(8f); // Aumenta cada 8 segundos en el Level 2

            // Aumenta la velocidad de la bola en el Level 1
            if (level == 1)
            {
                ballSpeedMultiplier += 6f; // Aumenta 6 por cada 10 segundos
            }
            // Aumenta la velocidad de la bola en el Level 2
            else if (level == 2)
            {
                ballSpeedMultiplier += 6f; // Aumenta 6 por cada 8 segundos
            }

            ballScript.IncreaseSpeed(ballSpeedMultiplier); // Llama al método IncreaseSpeed
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void NextLevel()
    {
        level++;
        levelText.text = "Level: " + level;
    
        if (level == 1)
        {
            ballSpeedMultiplier = 1.0f; // Empieza con velocidad normal
        }
        else if (level == 2)
        {
            ballSpeedMultiplier = 2.0f; // Se incrementa más rápido en el Level 2
        }
    
        if (level == 2) // Si llegas al nivel 2, reinicia las vidas
        {
            lives = 3;
            livesText.text = "Lives: " + lives;
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        levelText.text = "Level: " + level;
    }
}
