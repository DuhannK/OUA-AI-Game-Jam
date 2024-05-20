using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Oyuncu kameras�
    private Camera _playerCamera;
    // At�� menzili 
    public float shootingRange = 200f;
    // Zombi kontrol script'i 
    private ZombieController _zombieController;
    // Meteor patlama efekti 
    public GameObject meteorExplode;

    void Start()
    {
        // Oyuncu kameras�n� bul
        _playerCamera = Camera.main;

        // Fare imlecini gizle ve sabitle
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Sol fare tu�una bas�ld���nda ate� et
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Kamera merkezinden ��kan ���n
        Ray ray = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // I��n �arp��mas� bilgisi
        RaycastHit hit;

        // I��n at��� ve �arp��ma kontrol� (menzil dahilinde)
        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            // �arp��an bir obje varsa
            if (hit.collider != null)
            {
                // �arp��an obje "Meteor" etiketliyse
                if (hit.collider.CompareTag("Meteor"))
                {
                    // Patlama efektini olu�tur ve �al��t�r
                    GameObject _meteorExplode = Instantiate(meteorExplode, hit.collider.gameObject.transform.position, Quaternion.identity);
                    _meteorExplode.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                    StartCoroutine(DestroyParticleObject(_meteorExplode));

                    // �arp��an meteoru yok et
                    Destroy(hit.collider.gameObject);
                    // Meteor yok edilme olay�n� tetikle (e�er varsa)
                    MeteorManager.OnMeteorDestroy.Invoke();
                }
                // �arp��an obje "Enemy" (d��man) etiketliyse
                else if (hit.collider.CompareTag("Enemy"))
                {
                    // D��man kontrol script'ini al
                    _zombieController = hit.collider.gameObject.GetComponent<ZombieController>();
                    // D��man� �ld�r fonksiyonunu �a��r
                    _zombieController.KillZombie();
                }
            }
        }
    }

    IEnumerator DestroyParticleObject(GameObject meteorObject)
    {
        // 1 saniye bekle sonra patlama efektini yok et
        yield return new WaitForSeconds(1);
        Destroy(meteorObject);
    }
}
