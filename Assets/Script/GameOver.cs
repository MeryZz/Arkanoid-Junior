using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
     public void RestartGame()
    {
        // Restablecer el nivel a 1 al reiniciar el juego
        PlayerPrefs.SetInt("Level", 1);

        // Restablecer el puntaje a 0 al reiniciar el juego
        PlayerPrefs.SetInt("Score", 0);
        
        // Cargar la escena de "GameScene" después de reiniciar el nivel
        SceneManager.LoadScene("GameScene"); 
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra la aplicación
    }

}
