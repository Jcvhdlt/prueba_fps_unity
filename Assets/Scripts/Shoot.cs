using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet; // GameObject de la bala
    public Transform spawnPoint; // Transform del punto de spawn de la bala
    public float shootForce = 2500f; // Fuerza del disparo
    public AudioSource audioSource; // AudioSource para el sonido de disparo
    public AudioClip shootSound; // Sonido de disparo

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Si se presiona el botón de disparo
        {
            ShootBullet(); // Llama al método para disparar
        }
    }

    void ShootBullet()
    {
        // Instancia la bala en el punto de spawn
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        // Aplica fuerza al Rigidbody de la bala
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

        // Reproduce el sonido de disparo
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // Reproduce el sonido
        }

        // Destruye la bala después de 2 segundos
        Destroy(newBullet, 2f);
    }
}