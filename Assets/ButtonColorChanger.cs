using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    public PlayerController player;         // Referensi ke pemain untuk memeriksa apakah pemain memiliki kunci
    public Color defaultColor = Color.red;    // Warna default teks tombol
    public Color keyColor = Color.blue;        // Warna teks tombol saat pemain memiliki kunci

    private Text buttonText;  // Referensi ke komponen Text di dalam Button

    void Start()
    {
        // Ambil komponen Text dari objek yang sama
        buttonText = GetComponentInChildren<Text>();
        // Setel warna teks ke warna default saat memulai
        SetButtonTextColor(defaultColor);
    }

    void Update()
    {
        // Periksa apakah pemain memiliki kunci
        if (player != null && player.hasKey)
        {
            SetButtonTextColor(keyColor);  // Ubah warna teks tombol jika pemain memiliki kunci
        }
        else
        {
            SetButtonTextColor(defaultColor);  // Kembalikan ke warna teks default jika pemain tidak memiliki kunci
        }
    }
    void SetButtonTextColor(Color color)
    {
        // Ubah warna teks di dalam tombol
        buttonText.color = color;
    }
}
