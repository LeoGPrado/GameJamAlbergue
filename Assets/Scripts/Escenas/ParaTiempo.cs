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
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2.5f);
        Time.timeScale = 1f;
    }
}
