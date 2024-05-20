using UnityEngine;

public class Meteor : MonoBehaviour
{
    
    public float fallSpeed = 50f; // Meteorun d��me h�z� 
    private bool _isGrounded; // Meteor yere �arp�p durmu� mu?

    void Update()
    {
        // E�er yere �arpmad�ysa a�a�� do�ru hareket ettir
        if (!_isGrounded)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        // Y eksenindeki konumu 0'dan k���k veya e�itse yok et
        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �arp��t��� obje "Ground" etiketliyse yere �arp�p durmu� olarak i�aretle ve yok et
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Destroy(gameObject);
        }
        // �arp��t��� obje "Player" etiketliyse yok et
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
