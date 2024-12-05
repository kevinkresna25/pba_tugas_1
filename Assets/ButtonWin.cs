using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonWin : MonoBehaviour
{
    public GameObject congratulationsText;  // Reference to the Congratulations Text

    void Start()
    {
        // Ensure the text is hidden at the start
        //congratulationsText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // This is called when the 3D button is clicked
            Debug.Log("Congratulations! YOU WIN.");
            //congratulationsText.SetActive(true);  // Show the Congratulations message

            // Load Scene
            SceneManager.LoadScene("WinScene");
        }
    }
}
