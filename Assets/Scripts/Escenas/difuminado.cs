using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class difuminado : MonoBehaviour
{
    public GameObject gameObjectOscurecer;
    public RawImage Oscurecer;
    public float TOscurecer = 2f;

    public void OscurecerEscena()
    {
        gameObjectOscurecer.SetActive(true);
        StartCoroutine(oscuro());
    }

    public void oscurecerEscenaSalir()
    {
        gameObjectOscurecer.SetActive(true);
        StartCoroutine(oscuroSalida());
    }

    IEnumerator oscuro()
    {
        float tiempo = 0;
        Color oscurecer = Oscurecer.color;

        // Ir subiendo el alpha de 0 → 1
        while (tiempo < TOscurecer)
        {
            tiempo += Time.deltaTime;
            oscurecer.a = Mathf.Lerp(0, 1, tiempo / TOscurecer);
            Oscurecer.color = oscurecer;
            yield return null;
        }

        Application.Quit();

        SceneManager.LoadScene("Nivel1");
    }

    IEnumerator oscuroSalida()
    {
        float tiempo = 0;
        Color oscurecer = Oscurecer.color;

        // Ir subiendo el alpha de 0 → 1
        while (tiempo < TOscurecer)
        {
            tiempo += Time.deltaTime;
            oscurecer.a = Mathf.Lerp(0, 1, tiempo / TOscurecer);
            Oscurecer.color = oscurecer;
            yield return null;
        }

        Application.Quit();
    }
}
