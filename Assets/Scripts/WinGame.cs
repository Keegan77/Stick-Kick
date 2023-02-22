using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("head"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
