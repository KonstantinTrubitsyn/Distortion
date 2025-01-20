using UnityEngine;

public class InstrumentManager : MonoBehaviour
{
    public GameObject[] instruments; // Массив инструментов
    public AudioSource[] audioSources; // Массив источников звука
    public Color highlightColor = Color.yellow; // Цвет подсветки
    public Color defaultColor = Color.white; // Цвет по умолчанию

    private int currentStep = 0; // Текущий шаг в последовательности
    private bool isPlayingSequence = false; // Флаг для отслеживания состояния

    void Start()
    {
        // Убедиться, что все источники звука изначально не играют
        foreach (var source in audioSources)
        {
            source.Stop();
        }

        // Сброс цвета всех инструментов
        foreach (var instrument in instruments)
        {
            var renderer = instrument.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.color = defaultColor;
        }
    }

    public void OnInstrumentClicked(GameObject instrument)
    {
        if (isPlayingSequence)
            return;

        // Проверяем, правильный ли инструмент нажат
        if (instrument == instruments[currentStep])
        {
            // Подсветить инструмент
            var renderer = instrument.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.color = highlightColor;

            // Воспроизвести соответствующую аудиодорожку
            audioSources[currentStep].Play();

            // Переходим к следующему шагу
            currentStep++;

            // Если последовательность завершена
            if (currentStep >= instruments.Length)
            {
                Debug.Log("Уровень пройден!");
                // Добавьте логику завершения уровня здесь
            }
        }
        else
        {
            Debug.Log("Неправильный инструмент, сброс.");
            ResetSequence();
        }
    }

    public void ResetSequence()
    {
        // Сбрасываем шаги
        currentStep = 0;

        // Останавливаем всю музыку
        foreach (var source in audioSources)
        {
            source.Stop();
        }

        // Отключаем подсветку всех инструментов
        foreach (var instrument in instruments)
        {
            var renderer = instrument.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.color = defaultColor;
        }
    }
}
