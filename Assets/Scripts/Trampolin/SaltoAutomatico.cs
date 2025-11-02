using UnityEngine;

public class SaltoAutomatico : MonoBehaviour
{
    [SerializeField] Rigidbody2D gato1;
    [SerializeField] Rigidbody2D gato2;
    [SerializeField] Rigidbody2D gato3;
    [SerializeField] Rigidbody2D perro1;
    [SerializeField] Rigidbody2D perro2;

    [SerializeField] Transform gato1Transform;
    [SerializeField] Transform gato2Transform;
    [SerializeField] Transform gato3Transform;
    [SerializeField] Transform perro1Transform;
    [SerializeField] Transform perro2Transform;

    //[SerializeField] Transform GatoPrinciapal;

    public static SaltoAutomatico SaltoAuto;

    public int fuerzaSalto = 8;

    private void Awake()
    {
        if (SaltoAuto == null)
        {
            SaltoAuto = this;
        }
    }




    public void ActivarSaltoBarraEspaciadora()
    {
        if ((ControladorMascotas.controlador.ConfimacionSuelo() == true) &&(gato1Transform.localPosition.y<=0.1f))
        {

            gato1.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);
            

        }
        if ((ControladorMascotas.controlador.ConfimacionSuelo() == true)&& (gato2Transform.localPosition.y <= 0.1f))
        {

            gato2.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);

        }
        if ((ControladorMascotas.controlador.ConfimacionSuelo() == true)&& (gato3Transform.localPosition.y <= 0.1f))
        {

            gato3.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);

        }
        if ((ControladorMascotas.controlador.ConfimacionSuelo() == true) && (perro1Transform.localPosition.y <= 0.1f))
        {

            perro1.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);

        }
        if ((ControladorMascotas.controlador.ConfimacionSuelo() == true)&& (perro2Transform.localPosition.y <= 0.1f))
        {

            perro2.AddForce(Vector2.up * fuerzaSalto * Time.timeScale, ForceMode2D.Impulse);
        }

    }
}
