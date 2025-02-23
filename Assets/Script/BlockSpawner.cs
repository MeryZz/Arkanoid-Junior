using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public int rows = 5; // Número de filas
    public int columns = 8; // Número de columnas
    public float spacing = 2f; // Espaciado entre bloques

    private void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        if (BlockPool.Instance.blockPrefabs.Length == 0)
        {
            Debug.LogError("No hay prefabs de bloques asignados.");
            return;
        }

        Debug.Log("Generando bloques...");
        // Obtiene el tamaño de un bloque (usamos el primer prefab)
        float blockWidth = BlockPool.Instance.blockPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;
        float blockHeight = BlockPool.Instance.blockPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y;

        // Define los límites de la pantalla
        float minX = -90f;
        float maxX = 90f;

        // Calcula el ancho total de la fila con espaciado incluido
        float totalRowWidth = (columns * blockWidth) + ((columns - 1) * spacing);

        // Ajustamos la posición inicial para que los bloques queden centrados
        float startX = minX + (maxX - minX - totalRowWidth) / 2 + blockWidth / 2;
        float startY = 70f; // Posición inicial en Y (ajustable según lo necesites)

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calcula la posición de cada bloque
                float posX = startX + col * (blockWidth + spacing);
                float posY = startY - row * (blockHeight + spacing);

                Vector3 spawnPosition = new Vector3(posX, posY, 0);

                // Elige un bloque aleatorio del pool
                int randomIndex = Random.Range(0, BlockPool.Instance.blockPrefabs.Length);

                // Pide un bloque del pool y lo posiciona
                BlockPool.Instance.GetBlock(spawnPosition, randomIndex);
            }
        }
    }
}
