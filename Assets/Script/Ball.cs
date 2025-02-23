using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class Ball : MonoBehaviour
{
    // Movement Speed
    public float speed = 130.0f; // Velocidad inicial de la bola
    public float ballSpeedMultiplier = 1.0f; // Multiplicador de velocidad, se ajustará con el nivel

    private Rigidbody2D rb; // Referencia al Rigidbody2D de la bola

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Inicializa la referencia al Rigidbody2D
        // Inicia el movimiento de la bola hacia arriba con la velocidad inicial
        rb.linearVelocity = Vector2.up * speed;
    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            rb.linearVelocity = dir * speed;
        }




        if (col.gameObject.CompareTag("Block"))
        {
            BlockPool.Instance.ReturnBlock(col.gameObject);
            col.gameObject.SetActive(false);
        }
    }


    // Detecta cuando la bola toca la DeathZone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            if (GameManager.Instance.lives > 0) // Si quedan vidas
            {
                GameManager.Instance.LoseLife();
                ResetBall();
            }
            else // Si las vidas son 0, cambiar a Game Over
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }


    // Método para reiniciar la posición de la bola
    void ResetBall()
    {
        transform.position = new Vector2(0, -85); // Reinicia la posición
        rb.linearVelocity = Vector2.up * speed; // Reinicia el movimiento
    }


    // Método para aumentar la velocidad de la bola con el multiplicador
    public void IncreaseSpeed(float increment)
    {
        speed += increment; // Incrementa la velocidad en lugar de multiplicarla
        rb.linearVelocity = rb.linearVelocity.normalized * speed; // Actualiza la velocidad con la nueva velocidad
    }
}
