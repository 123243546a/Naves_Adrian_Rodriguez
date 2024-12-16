using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField]private float velocidadDisparo;
    [SerializeField] private float DanhoDisparo;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        
    }
    private void Movimiento()
    {
        transform.Translate(new Vector3(1, 0, 0).normalized * Time.deltaTime * velocidadDisparo);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            other.gameObject.GetComponent<Enemigo>().RecibirDanho(DanhoDisparo);
            Destroy(gameObject);
            print("He colisionado con el enemigo");
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player1>().RecibirDanho(DanhoDisparo);
            Destroy(gameObject);
            print("He colisionado con el jugador");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        
    }
}
