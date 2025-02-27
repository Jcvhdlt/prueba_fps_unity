using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance; // Singleton para acceder fácilmente al contador
    public TextMeshProUGUI enemyCountText; // Texto de la UI que muestra el número de enemigos
    private int enemyCount; // Número de enemigos restantes

    public GameObject winTextObject;

    void Awake()
    {
        // Configura el Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Inicializa el contador con el número de enemigos en la escena
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        UpdateEnemyCountText();
        this.winTextObject.SetActive(false); // Se desactiva el mensaje de victoria
    }

    // Método para reducir el contador de enemigos
    public void EnemyDefeated()
    {
        enemyCount--;
        UpdateEnemyCountText();

        // Verifica si no quedan enemigos
        if (enemyCount <= 0)
        {
            YouWin();
        }
    }

    // Actualiza el texto de la UI
    void UpdateEnemyCountText()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = "Enemies Remaining: " + enemyCount;
        }
    }

    // Muestra el mensaje de victoria
    void YouWin()
    {
        Debug.Log("You Win!!!");
        if (enemyCountText != null)
        {
           this.winTextObject.SetActive(true);
        }
    }
}