using UnityEngine;
using UnityEngine.UI;
public class NoranonControlador : MonoBehaviour
{

    [SerializeField] Rigidbody2D Noranon;
    [SerializeField] BoxCollider2D NoranonCollider;
    [SerializeField] Animator NoranonAnimaciones;

    //salto
    bool tocandoSuelo=true;
    public int FuerzaDeSalto = 3;
    [SerializeField] GameObject PisoCheckCentro;
    [SerializeField] float DistaciaPiso;
    [SerializeField] LayerMask PisoLayer;

    //movimiento
    public int velocidadMovimiento=5;

    //movimientoDeFondo
    public RawImage Fondo;
    //public float VelocidadParallax;
 
    void Start()
    {
        Noranon = GetComponent<Rigidbody2D>();
        NoranonAnimaciones = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Movimiento();
        
        bool PisandoSuelo = pisandoSuelo();
        salto();

        escalar();
    }

    void Movimiento()
    {

        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)||Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D)) 
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            Noranon.linearVelocity = new Vector2(horizontal * velocidadMovimiento, Noranon.linearVelocity.y);

            if (horizontal == 0)
            {
                NoranonAnimaciones.SetBool("MovimientoP", false);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
                NoranonAnimaciones.SetBool("MovimientoP", true);

            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
                NoranonAnimaciones.SetBool("MovimientoP", true);
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            Fondo.uvRect = new Rect(Fondo.uvRect.x - 0.01f * Time.deltaTime, 0f, 0.5f, 1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Fondo.uvRect = new Rect(Fondo.uvRect.x + 1f * Time.deltaTime, 0f, 0.5f, 1f);
        }
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
        NoranonAnimaciones.SetBool("SaltoP", true);
        Noranon.AddForce(Vector2.up * FuerzaDeSalto * Time.timeScale, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            NoranonAnimaciones.SetBool("SaltoP", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            NoranonAnimaciones.SetBool("SaltoP", true);
        }
    }

    public bool pisandoSuelo()
    {
        RaycastHit2D hitCentro = Physics2D.Raycast(PisoCheckCentro.transform.position, Vector2.down, DistaciaPiso, PisoLayer);
       
        return hitCentro.collider;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(PisoCheckCentro.transform.position, Vector2.down * DistaciaPiso, Color.red);
    }

    void escalar()
    {
        if (NoranonCollider.IsTouchingLayers(LayerMask.GetMask("Escalera"))){


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                NoranonAnimaciones.SetBool("EscaladoP", true);
                float vertical = Input.GetAxisRaw("Vertical");
                Noranon.linearVelocity = new Vector2(Noranon.linearVelocity.x, vertical * velocidadMovimiento);

            }
            if(Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S))
            {
                NoranonAnimaciones.SetBool("EscaladoP", true);
                Noranon.linearVelocity = new Vector2(Noranon.linearVelocity.x, 0);
                Noranon.gravityScale = 0;
            }
        }
        else
        {
            NoranonAnimaciones.SetBool("EscaladoP", false);
            Noranon.gravityScale = 1;
        }
    }

}
