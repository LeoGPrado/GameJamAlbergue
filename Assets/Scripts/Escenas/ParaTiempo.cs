using UnityEngine;
using System.Collections;

public class ParaTiempo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DetenerInicio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DetenerInicio()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
}
