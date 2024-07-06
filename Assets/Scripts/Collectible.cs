using System.Diagnostics;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Metoda wywo³ywana, gdy coœ wchodzi w trigger tego obiektu
    private void OnTriggerStay(Collider other)
    {
        // Sprawdzenie, czy gracz naciska klawisz "E"
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Logika zbierania obiektu, np. dodanie do ekwipunku
            CollectItem();
        }
    }

    // Metoda, która wykonuje logikê zbierania obiektu
    private void CollectItem()
    {
        // Przyk³ad: ukrycie obiektu lub jego dezaktywacja
        gameObject.SetActive(false);
        // Mo¿esz tutaj dodaæ logikê dodawania przedmiotu do ekwipunku gracza
    }
}