using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BlockPool : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Prefabs de bloques
    private List<GameObject> blockPool = new List<GameObject>(); // Pool de bloques

    public static BlockPool Instance; // Instancia estática para acceder al pool

    private int activeBlocks = 0; // Contador de bloques activos

    // Prefabs de explosiones
    public ParticleSystem redExplosionPrefab;
    public ParticleSystem blueExplosionPrefab;
    public ParticleSystem greenExplosionPrefab;
    public ParticleSystem pinkExplosionPrefab;
    public ParticleSystem yellowExplosionPrefab;

    void Awake()
    {
        Instance = this; // Asignamos la instancia estática
    }

    // Obtiene un bloque del pool y lo activa en la posición indicada
    public GameObject GetBlock(Vector2 position, int blockIndex)
    {
        foreach (GameObject block in blockPool)
        {
            // Verifica si el bloque está inactivo y tiene el tag correcto
            if (!block.activeInHierarchy && block.CompareTag(blockPrefabs[blockIndex].tag))
            {
                block.transform.position = position; // Asigna la nueva posición
                block.SetActive(true); // Activa el bloque
                activeBlocks++; // Incrementa el contador de bloques activos
                Debug.Log($"Reutilizando bloque de {blockPrefabs[blockIndex].tag} en posición {position}");
                return block;
            }
        }

        // Si no se encontró un bloque, creamos uno nuevo
        GameObject newBlock = Instantiate(blockPrefabs[blockIndex]);
        newBlock.transform.position = position;
        newBlock.SetActive(true);
        blockPool.Add(newBlock); // Añadimos el nuevo bloque al pool
        activeBlocks++; // Incrementa el contador de bloques activos
        Debug.Log($"Creando nuevo bloque de {blockPrefabs[blockIndex].tag} en posición {position}");
        return newBlock;
    }

    // Devuelve un bloque al pool y lo desactiva
    public void ReturnBlock(GameObject block)
    {
        // Verifica si el bloque ya está desactivado para evitar decrementos innecesarios
        if (block.activeInHierarchy)
        {
            block.SetActive(false); // Desactiva el bloque
            activeBlocks--; // Decrementa el contador solo si el bloque estaba activo
            Debug.Log($"Bloque {block.name} devuelto al pool. Bloques activos: {activeBlocks}");

            // Verifica si los bloques activos han llegado a 0
            if (activeBlocks == 0)
            {
                string currentScene = SceneManager.GetActiveScene().name; // Obtén el nombre de la escena actual

                if (currentScene == "GameScene")
                {
                    // Cambia a la nueva escena "GameScene2" si estamos en "GameScene"
                    PlayerPrefs.SetInt("Score", GameManager.Instance.score); // Guarda el puntaje actual
                    PlayerPrefs.SetInt("Level", 2);  // Guarda el nivel 2 en PlayerPrefs
                    SceneManager.LoadScene("GameScene2");
                }
                else if (currentScene == "GameScene2")
                {
                    // Cambia a la escena "GameOverScene" si estamos en "GameScene2"
                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }
    }

    // Método para obtener el número de bloques activos
    public int GetActiveBlockCount()
    {
        return activeBlocks;
    }
}
