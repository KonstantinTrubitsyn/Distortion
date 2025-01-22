using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;        // Скорость движения персонажа
    public AudioClip walkSound;     // Аудиофайл для звука ходьбы
    private AudioSource audioSource; // Компонент AudioSource для воспроизведения звука

    private Rigidbody2D rb;         // Rigidbody2D для движения персонажа

    void Start()
    {
        // Получаем ссылку на Rigidbody2D и AudioSource компоненты
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // Получаем AudioSource компонента
    }

    void Update()
    {
        // Получаем значения для горизонтального и вертикального движения
        float moveX = Input.GetAxis("Horizontal"); // Горизонтальное движение (влево/вправо)
        float moveY = Input.GetAxis("Vertical");   // Вертикальное движение (вверх/вниз)

        // Устанавливаем скорость движения
        rb.linearVelocity = new Vector2(moveX * speed, moveY * speed);

        // Если персонаж двигается и звук не воспроизводится, воспроизводим звук
        if ((moveX != 0 || moveY != 0) && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(walkSound);  // Воспроизводим звук
        }
    }
}

