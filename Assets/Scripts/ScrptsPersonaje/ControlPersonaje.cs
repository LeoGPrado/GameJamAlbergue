using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class ControlPersonaje : MonoBehaviour
{
    [SerializeField] Rigidbody2D Gato;
    public int velocidadMovimiento;

    //salto
    public int fuerzaSalto;

    [SerializeField] GameObject PisoCheckCentro;
    [SerializeField] float DistaciaPiso;
    [SerializeField] LayerMask PisoLayer;
    private bool canJump;

    public Animator PersonajeAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //bool PisandoSuelo = pisandoSuelo();
        var ts = Touchscreen.current;
        if (ts != null)
        {
            var touch = ts.primaryTouch;

            // Si el jugador toca la pantalla (sin importar swipe)
            if (touch.press.wasPressedThisFrame)
            {
                canJump = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    saltar();
        //}

        //if (pisandoSuelo() == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {

        //        salto();
        //    }
        //}

        //movimientoGato();
    }
    private void FixedUpdate()
    {
        movimientoGato();
        salto();
    }
    void movimientoGato()
    {

        Gato.linearVelocity = new Vector2(1 * velocidadMovimiento, Gato.linearVelocity.y);

    }

    void salto()
    {

        if (pisandoSuelo())
        {

            if (canJump)
            {
                saltar();
                canJump = false;
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
