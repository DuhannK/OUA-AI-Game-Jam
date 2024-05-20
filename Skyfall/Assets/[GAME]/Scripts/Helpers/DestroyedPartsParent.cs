using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPartsParent : MonoBehaviour
{
    // Yok edilmeden �nce ge�ecek s�re 
    public float timeToDestroyAfterSingleCall = 5f;

    void Start()
    {
        // "DestroyParentO" fonksiyonunu belirli bir gecikmeyle �a��r
        Invoke("DestroyParentO", timeToDestroyAfterSingleCall);
    }

    // Par�a halindeki ev klonlar�n� yok etmek i�in kullan�lan metot.
    void DestroyParentO()
    {
        // Bu GameObject'u yok et
        Destroy(gameObject);
    }
}

