using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject dialogueBox; // Панель диалога
    public string npcTag = "NPC";  // Тег NPC, чтобы отличать его от других объектов
    public string dialogueText = "Привет! Как я могу помочь?"; // Текст диалога

    private bool isDialogueActive = false; // Флаг для отслеживания состояния диалога

    void Update()
    {
        // Проверка на клик мышью (левая кнопка)
        if (Input.GetMouseButtonDown(0)) // 0 = левая кнопка мыши
        {
            // Получаем позицию мыши на экране
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Проверяем, на что мы кликнули (Raycast)
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Если попали в объект с тегом NPC
            if (hit.collider != null && hit.collider.CompareTag(npcTag))
            {
                // Открыть или закрыть диалог
                if (!isDialogueActive)
                {
                    ShowDialogue(); // Открываем диалог
                }
                else
                {
                    EndDialogue(); // Закрываем диалог
                }
            }
        }
    }

    // Метод для отображения диалогового окна
    void ShowDialogue()
    {
        isDialogueActive = true;
        dialogueBox.SetActive(true); // Показываем диалоговое окно
        dialogueBox.GetComponentInChildren<UnityEngine.UI.Text>().text = dialogueText; // Устанавливаем текст
    }

    // Метод для завершения диалога
    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueBox.SetActive(false); // Скрываем диалоговое окно
    }
}