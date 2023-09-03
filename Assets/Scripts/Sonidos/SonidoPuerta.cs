using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPuerta : MonoBehaviour
{
  
    // Start is called before the first frame update
  
  
    public AudioClip[] sonidos;  // Lista de sonidos que deseas reproducir.

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (sonidos.Length > 0)
        {
            // Elegir un sonido al azar de la lista.
            int indiceSonidoAleatorio = Random.Range(0, sonidos.Length);
            AudioClip sonidoAleatorio = sonidos[indiceSonidoAleatorio];

            // Reproducir el sonido seleccionado.
            audioSource.clip = sonidoAleatorio;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se han asignado sonidos en el Inspector.");
        }
    }
}
