using UnityEngine;

public class Audio : MonoBehaviour
{
    // Arka plan m�zi�i i�in ses kayna��
    private AudioSource _background;

    // Audio s�n�f�n�n tek bir �rne�ini tutar (singleton)
    public static Audio Instance { get; private set; }
    // Audio s�n�f�n�n bir �rne�ini tutar 
    public static Audio audioObject = null;

    void Awake()
    {
        // GameObject'den AudioSource bile�enini al
        _background = gameObject.GetComponent<AudioSource>();

        // Audio s�n�f�n�n �rne�i yoksa (ilk olu�turulma)
        if (audioObject == null)
        {
            // Bu nesneyi Instance olarak ata
            audioObject = this;
            // Sahneler aras�nda yok edilmemesini sa�la
            DontDestroyOnLoad(this);
        }
        // E�er ba�ka bir Audio nesnesi zaten varsa (sahne ge�i�i)
        else if (this != audioObject)
        {
            // Bu GameObject'u yok et (gereksiz kopyay� �nle)
            Destroy(gameObject);
        }
    }
}

