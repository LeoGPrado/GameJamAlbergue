using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarReiniciar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Reinicar");
        }
    }
}
