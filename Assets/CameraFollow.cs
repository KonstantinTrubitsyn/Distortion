using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на объект персонажа
    public float smoothSpeed = 0.125f; // Скорость сглаживания
    public Vector3 offset; // Смещение камеры относительно персонажа

    void LateUpdate()
    {
        // Целевая позиция камеры
        Vector3 desiredPosition = target.position + offset;

        // Сглаженное движение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Обновляем позицию камеры
        transform.position = smoothedPosition;
    }
}