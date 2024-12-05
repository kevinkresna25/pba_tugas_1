using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Menandakan bahwa pemain sudah memiliki kunci
            other.GetComponent<PlayerController>().hasKey = true;

            // Hapus kunci dari scene setelah diambil
            Destroy(gameObject);
            Debug.Log("Kunci diambil");
        }
    }
}
