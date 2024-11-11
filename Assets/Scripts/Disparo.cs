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
            Destroy(gameObject);
            other.gameObject.GetComponent<Enemigo>().RecibirDanho(DanhoDisparo);

        }

        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player1>().RecibirDanho(DanhoDisparo);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        
    }
}
