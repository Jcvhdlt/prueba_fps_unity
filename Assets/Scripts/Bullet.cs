using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 10; // daño de la bala

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>(); // se obtiene el componente EnemyHealth del enemigo
        if (enemy != null) // si el enemigo no es nulo
        {
            enemy.TakeDamage(damage); // se le aplica el daño al enemigo
            
        }   

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }   
        
             
    }
}
