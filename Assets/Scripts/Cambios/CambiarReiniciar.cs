using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambiarReiniciar : MonoBehaviour
{
    public GameObject gameObjectOscurecer;
    public RawImage Oscurecer;
    public float TOscurecer = 2f;


    public void OscurecerEscena(int indiceEscena)
    {
        gameObjectOscurecer.SetActive(true);
        StartCoroutine(oscuro(indiceEscena));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OscurecerEscena(0);
        }
    }

    IEnumerator oscuro(int Indice)
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

        //Application.Quit();

        SceneManager.LoadScene(Indice);
    }
}
