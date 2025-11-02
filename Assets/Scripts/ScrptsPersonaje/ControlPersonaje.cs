using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlPersonaje : MonoBehaviour
{
    [SerializeField] Rigidbody2D Gato;
    public int velocidadMovimiento = 5;

    //salto
    public int fuerzaSalto=3;

    [SerializeField] GameObject PisoCheckCentro;
    [SerializeField] float DistaciaPiso;
    [SerializeField] LayerMask PisoLayer;

    public Animator PersonajeAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool PisandoSuelo = pisandoSuelo();

        if (pisandoSuelo() == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                salto();
            }
        }

        movimientoGato();
    }

    void movimientoGato()
    {

        Gato.linearVelocity = new Vector2(1 * velocidadMovimiento, Gato.linearVelocity.y);

    }

    void salto()
    {

        if (pisandoSuelo())
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                saltar();
            }
        }

    }

    void saltar()
    {
        //SaltoAutomatico.SaltoAuto.ActivarSaltoBarraEspaciadora();
        PersonajeAnimator.SetBool("SaltoP", true);
        Gato.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);
    }

    public bool pisandoSuelo()
    {
        RaycastHit2D hitCentro = Physics2D.Raycast(PisoCheckCentro.transform.position, Vector2.down, DistaciaPiso, PisoLayer);
        PersonajeAnimator.SetBool("SaltoP", false);

        return hitCentro.collider;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(PisoCheckCentro.transform.position, Vector2.down * DistaciaPiso, Color.red);
    }
}
