using UnityEngine;

public class cambiarArevision : MonoBehaviour
{
    public GameObject pamtallaDeVerificar;

    public Rigidbody2D robotez;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pamtallaDeVerificar.SetActive(true);
            robotez.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
