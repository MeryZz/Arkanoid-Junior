using UnityEngine;


public class Block : MonoBehaviour
{
    public int scoreValue = 1; // Valor de puntos del bloque, editable desde el Inspector
    public GameObject explosionPrefab; // Prefab de la explosión


    // Colisión con la pelota
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            if (gameObject.activeInHierarchy) // Verifica si el bloque ya está activo
            {
                Debug.Log($"Bloque {gameObject.name} colisionó con la bola. Enviándolo al pool...");
               
                // Usar el valor asignado directamente
                GameManager.Instance.AddScore(scoreValue);


                // Instanciar la explosión en la posición del bloque
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);


                // Devolver el bloque al pool
                BlockPool blockPool = Object.FindFirstObjectByType<BlockPool>(); // Usando la nueva función recomendada


                if (blockPool != null)
                {
                    blockPool.ReturnBlock(gameObject); // Retorna el bloque al pool
                }
                else
                {
                    Debug.LogError("BlockPool no encontrado.");
                }
            }
        }
    }
}
