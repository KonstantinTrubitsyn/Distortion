using UnityEngine;
using TMPro;  // Подключаем TextMeshPro

public class DialogSystem : MonoBehaviour
{
    // Ссылка на панель с диалогом
    public GameObject dialogueWindow;
    // Ссылка на компонент TextMeshProUGUI, который будет менять текст
    public TextMeshProUGUI dialogueText;

    // Массив текстов для отображения
    private string[] dialogues = {
        "Милый Франк, при первом",
        "Что ты тут делаешь?",
    };

    private int currentDialogIndex = 0;  // Индекс текущего диалога

    void Start()
    {
        // Убедитесь, что окно скрыто в начале
        dialogueWindow.SetActive(false);
    }

    // Этот метод будет вызываться при клике на персонажа
    void OnMouseDown()
    {
        // Если диалоговое окно не активно, показываем его
        if (!dialogueWindow.activeSelf)
        {
            dialogueWindow.SetActive(true);
            UpdateDialogue();
        }
        else
        {
            // Переходим к следующему тексту
            currentDialogIndex++;

            // Если достигли конца, скрываем диалог
            if (currentDialogIndex >= dialogues.Length)
            {
                dialogueWindow.SetActive(false);
                currentDialogIndex = 0; // Сброс индекса для следующего клика
            }
            else
            {
                UpdateDialogue();
            }
        }
    }

    // Обновляем текст диалога
    void UpdateDialogue()
    {
        if (currentDialogIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogIndex];
        }
    }
}
