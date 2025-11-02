using UnityEngine;

public class ControladorMascotas : MonoBehaviour
{
    [SerializeField] Rigidbody2D mascota;


    public int velocidadMovimiento = 5;
    public int fuerzaSalto = 8;

    public static ControladorMascotas controlador;

    [SerializeField] GameObject PisoCheckCentro;
    [SerializeField] float DistaciaPiso;
    [SerializeField] LayerMask PisoLayer;

    private void Awake()
    {
        if (controlador == null)
        {
            controlador = this;
        }
    }

    private void Update()
    {
        movimientoGato();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trampolin")
        {
            ActivarSaltoTrampolin();
        }
    }
    void movimientoGato()
    {

        mascota.linearVelocity = new Vector2(1 * velocidadMovimiento, mascota.linearVelocity.y);

    }

    public void ActivarSaltoTrampolin()
    {
        if (pisandoSuelo())
        {
            mascota.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);
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

    public bool ConfimacionSuelo()
    {
        return pisandoSuelo();
    }
}
