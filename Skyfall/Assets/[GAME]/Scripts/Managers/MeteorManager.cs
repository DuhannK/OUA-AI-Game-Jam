using UnityEngine;
using UnityEngine.Events;

public class MeteorManager : MonoBehaviour
{
    // Meteor yok edildi�inde tetiklenen bir UnityEvent 
    [HideInInspector] public static UnityEvent OnMeteorDestroy = new UnityEvent();

    // Spawn edilebilecek meteor prefablar� 
    public GameObject[] meteorPrefabs;
    // Meteor spawn etme aral��� 
    public float spawnInterval = 2.0f;
    // Meteorlar�n spawn y�ksekli�i 
    public float spawnHeight = 80f;
    // Meteorlar�n spawn olabilece�i alan�n boyutlar� 
    public Vector3 spawnAreaSize = new Vector3(100f, 0, 100f);
    private float timer; // Spawn zamanlay�c�s�
    private int _meteorIndex; // Se�ilecek meteor prefab�n�n index'i

    private void Start()
    {
        // 10 saniyede bir "DecreaseSpawnInterval" metodu �a�r�lacak �ekilde ayarlan�r
        InvokeRepeating("DecreaseSpawnInterval", 10f, 10f);
    }

    void Update()
    {
        // Zamanlay�c�y� oyunun ge�en s�resiyle g�ncelle
        timer += Time.deltaTime;

        // Zamanlay�c� spawn aral���na e�it veya ge�tiyse meteor spawn et
        if (timer >= spawnInterval)
        {
            SpawnMeteor();
            timer = 0; // Zamanlay�c�y� s�f�rla
        }
    }

    void SpawnMeteor()
    {
        // Rastgele bir spawn pozisyonu hesapla
        Vector3 spawnPosition = new Vector3(
          Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
          spawnHeight,
          Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Spawn edilecek meteor prefab�n�n index'ini rastgele se�
        _meteorIndex = Random.Range(0, meteorPrefabs.Length);
        // Se�ilen meteor prefab�ndan bir �rnek olu�tur ve spawn pozisyonuna yerle�tir
        Instantiate(meteorPrefabs[_meteorIndex], spawnPosition, Quaternion.identity);
    }

    void DecreaseSpawnInterval()
    {
        // Spawn aral���n� zamanla azalt (zorla�t�r)

        // Spawn aral��� 0'dan b�y�kse devam et
        if (spawnInterval > 0)
        {
            if (spawnInterval > 0.5f)
            {
                spawnInterval -= 0.5f;
            }
            else if (spawnInterval == 0.5f)
            {
                spawnInterval = 0.5f;
            }
        }
        else
        {
            spawnInterval = 0.5f;
        }
    }
}
