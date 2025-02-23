using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class MenuController : MonoBehaviour
{
    // Función para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    // Función para salir del juego
    public void ExitGame()
    {
        Application.Quit();  
    }
}
