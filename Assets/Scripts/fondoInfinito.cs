using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondoInfinito : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Vector3 posicionInicial;
    [SerializeField] private float anchoImagen;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float espacioRecorrido = velocidad * Time.time;
        float resto = espacioRecorrido % anchoImagen;
        transform.position = posicionInicial + new Vector3(-1, 0, 0) * resto;
    }
}
