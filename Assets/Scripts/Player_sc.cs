using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    // Inspector'dan ayarlanabilir hız değişkeni.
    [SerializeField]
    private float speed = 5.0f;

    // Hareket aralığını belirleyen sınır değişkenleri.
    private float minX = -11.3f;
    private float maxX = 11.3f;
    private float minY = -3.8f;
    private float maxY = 0f;

    // Update içinden çağrılacak hareket fonksiyonu
    void Update()
    {
        CalculateMovement();  // Hareket fonksiyonunu çağırıyoruz
    }

    // Oyuncu hareketini hesaplayan fonksiyon
    private void CalculateMovement()
    {
        // Klavyeden alınan yatay ve dikey girişleri alıyoruz
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Girişlere göre hareket yönünü belirliyoruz
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        // Zamanı normalize ederek nesneyi hareket ettiriyoruz
        transform.Translate(direction * speed * Time.deltaTime);

        // Nesnenin hareket sınırlarını kontrol ediyoruz
        CheckBounds();
    }

    // Nesnenin hareket sınırlarını kontrol eden fonksiyon
    private void CheckBounds()
    {
        // Yatay sınır kontrolü: Sağdan çıkarsa soldan, soldan çıkarsa sağdan belirecek
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(minX, transform.position.y, 0);
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector3(maxX, transform.position.y, 0);
        }

        // Dikey sınır kontrolü: Mathf.Clamp ile sınırlar içinde tutuyoruz
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, 0);
    }
}