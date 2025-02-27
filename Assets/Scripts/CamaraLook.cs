using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    float xRotation = 0;
    public Transform playerBody; // Transform del jugador
    public float mouseSensitivity = 80f; // sensibilidad del mouse
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // se bloquea el cursor para que no se salga de la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX= Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime; // aqui se obtiene el movimiento del mouse en x
        float mouseY= Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime; // aqui se obtiene el movimiento del mouse en y

        xRotation -= mouseY; // se le resta el movimiento del mouse en y a la rotacion en x, esto sirve para que no se invierta la camara

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // se limita la rotacion en x para que no se pueda dar vueltas completas
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // se rota la camara en x, esto sirve para que la camara se mueva en y.

        playerBody.Rotate(Vector3.up * mouseX); // se rota el jugador en y, esto sirve para que el jugador se mueva en x.
    }
}
