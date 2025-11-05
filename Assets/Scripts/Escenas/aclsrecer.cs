using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class aclsrecer : MonoBehaviour
{
    //public GameObject gameObjectOscurecer;
    public SpriteRenderer Oscurecer;
    public float TOscurecer = 2f;

    private void Start()
    {
        StartCoroutine(oscuro());
    }

    /*public void Jugar()
    {
        //gameObjectOscurecer.SetActive(true);
        StartCoroutine(oscuro());
    }*/

    IEnumerator oscuro()
    {
        float tiempo = 0;
        Color oscurecer = Oscurecer.color;

        // Ir subiendo el alpha de 0 → 1
        while (tiempo < TOscurecer)
        {
            tiempo += Time.unscaledDeltaTime;
            oscurecer.a = Mathf.Lerp(1, 0, tiempo / TOscurecer);
            Oscurecer.color = oscurecer;
            yield return null;
        }

    }
}
