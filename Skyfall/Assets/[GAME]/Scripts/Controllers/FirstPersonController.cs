using UnityEngine;
using UnityEngine.AI;

public class FirstPersonController : MonoBehaviour
{
    // Oyuncunun hareketini kontrol eden NavMeshAgent bile�eni
    private NavMeshAgent _agent;

    // Oyuncunun hareket h�z� 
    public float moveSpeed = 5f;
    // Kamera d�n�� h�z� 
    public float lookSpeed = 2f;

    // Oyuncu kameras�
    private Camera _playerCamera;
    // Kamera d�n�� a��s� 
    private float _rotationX = 0f;

    void Start()
    {
        // GameObject'den NavMeshAgent bile�enini al
        _agent = GetComponent<NavMeshAgent>();
        // Sahnedeki ana kameray� bul
        _playerCamera = Camera.main;
    }

    void Update()
    {
        // Yatay (sola-sa�a) hareket miktar�
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // Dikey (ileri-geri) hareket miktar�
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Hareket vekt�r� olu�tur (sa�/ileri hareket i�in)
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        // NavMeshAgent'a hareket emri ver
        _agent.Move(move);

        // Fare yatay hareket miktar� (kamera d�n��� i�in)
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        // Fare dikey hareket miktar� (kamera d�n��� i�in)
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
        // Kamera d�n�� a��s�n� hesapla
        _rotationX -= mouseY;
        // Kamera d�n�� a��s�n� s�n�rla (-90 ile 90 derece aras�)
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        // Kamera d�n���n� uygula
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        // Karakterin yatay d�n���n� uygula (fare ile)
        transform.Rotate(Vector3.up * mouseX);
    }
}

