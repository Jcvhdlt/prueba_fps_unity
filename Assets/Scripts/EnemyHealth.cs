using UnityEngine;

public class EnemyHealth : MonoBehaviour

{

    public int maxHealth = 100; // vida del enemigo
    private int currentHealth; // vida actual del enemigo



    public void TakeDamage(int damage) // metodo para recibir daño
    {
        currentHealth -= damage; // se le resta el daño a la vida actual
        if (currentHealth <= 0) // si la vida actual es menor o igual a 0
        {
            Die(); // se llama al metodo Die
        }
    }

    void Die()
    {
        Debug.Log("Enemigo derrotado!");
        EnemyCounter.Instance.EnemyDefeated(); // Notifica al contador que un enemigo fue eliminado
        Destroy(gameObject); // Destruye el objeto del enemigo
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      currentHealth = maxHealth; // se le asigna la vida maxima a la vida actual  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
