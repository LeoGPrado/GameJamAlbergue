using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Dañojugador : MonoBehaviour
{
    public GameObject gameObjectOscurecer;
    public RawImage Oscurecer;
    public float TOscurecer = 2f;

    public Rigidbody2D robotez;
    public Rigidbody2D gato1;
    public Rigidbody2D gato2;
    public Rigidbody2D perro1;
    public Rigidbody2D perro2;
    public Rigidbody2D perro3;

    private void Start()
    {
        //gameObjectOscurecer= GameObject.Find("Oscurecer");
        //Oscurecer = gameObjectOscurecer.GetComponent<RawImage>();

        /*robotez = GameObject.Find("Robotez").GetComponent<Rigidbody2D>();
        gato1 = GameObject.Find("Gato1").GetComponent<Rigidbody2D>();
        gato2 = GameObject.Find("Gato2").GetComponent<Rigidbody2D>();
        perro1 = GameObject.Find("perro1").GetComponent<Rigidbody2D>();
        perro2 = GameObject.Find("perro2").GetComponent<Rigidbody2D>();
        perro3 = GameObject.Find("perro3").GetComponent<Rigidbody2D>();*/
    }




    public void OscurecerEscena(int indiceEscena)
    {
        gameObjectOscurecer.SetActive(true);
        StartCoroutine(oscuro(indiceEscena));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            robotez.constraints = RigidbodyConstraints2D.FreezeAll; 
            gato1.constraints = RigidbodyConstraints2D.FreezeAll;
            gato2.constraints = RigidbodyConstraints2D.FreezeAll;
            perro1.constraints = RigidbodyConstraints2D.FreezeAll;
            perro2.constraints = RigidbodyConstraints2D.FreezeAll;
            perro3.constraints = RigidbodyConstraints2D.FreezeAll;

            OscurecerEscena(2);
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
