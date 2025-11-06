using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Entregable : MonoBehaviour
{
    public GameObject PersonaEntregable1;
    public GameObject gato1;
    public GameObject EntregaCompleta1;

    public GameObject PersonaEntregable2;
    public GameObject gato2;
    public GameObject EntregaCompleta2;

    public GameObject PersonaEntregable3;
    public GameObject gato3;
    public GameObject EntregaCompleta3;

    public GameObject PersonaEntregable4;
    public GameObject gato4;
    public GameObject EntregaCompleta4;

    public GameObject PersonaEntregable5;
    public GameObject gato5;
    public GameObject EntregaCompleta5;


    private int contador=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((collision.gameObject.tag == "Persona")|| (collision.gameObject.tag == "Upersona")) && (contador==1))
        {
            gato1.SetActive(false);
            PersonaEntregable1.SetActive(false);
            EntregaCompleta1.SetActive(true);
            contador++;
        }
        else if (((collision.gameObject.tag == "Persona") || (collision.gameObject.tag == "Upersona")) && (contador == 2))
        {
            gato2.SetActive(false);
            PersonaEntregable2.SetActive(false);
            EntregaCompleta2.SetActive(true);
            contador++;
        }
        else if (((collision.gameObject.tag == "Persona") || (collision.gameObject.tag == "Upersona")) && (contador == 3))
        {
            gato3.SetActive(false);
            PersonaEntregable3.SetActive(false);
            EntregaCompleta3.SetActive(true);
            contador++;
        }
        else if (((collision.gameObject.tag == "Persona") || (collision.gameObject.tag == "Upersona")) && (contador == 4))
        {
            gato4.SetActive(false);
            PersonaEntregable4.SetActive(false);
            EntregaCompleta4.SetActive(true);
            contador++;
        }
        else if (((collision.gameObject.tag == "Persona") || (collision.gameObject.tag == "Upersona")) && (contador == 5))
        {
            gato5.SetActive(false);
            PersonaEntregable5.SetActive(false);
            EntregaCompleta5.SetActive(true);
            contador++;
            //StartCoroutine(verificar());
            SceneManager.LoadScene("Ganaste");
        }
    }

    /*IEnumerator verificar()
    {

        yield return new WaitForSecondsRealtime(1f);

    }*/
}
