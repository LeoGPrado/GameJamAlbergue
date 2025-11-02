using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicar : MonoBehaviour
{
    public void CargarSiguienteEscena(int Cambio)
    {
        // SceneManager.LoadScene() puede tomar un índice entero
        SceneManager.LoadScene(Cambio);

    }
}
