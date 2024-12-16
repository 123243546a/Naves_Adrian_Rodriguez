using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float vidas;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject DisparoEnemigos;
    [SerializeField] private GameObject SpawnDisparo;
    [SerializeField] private GameObject humo;
    [SerializeField] private GameObject nave;
    [SerializeField] private float tiempoHumo;
    [SerializeField] private bool muerto = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDisparos());
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas > 0) 
        {
            transform.Translate(new Vector3(-1, 0, 0).normalized * 5 * velocidad * Time.deltaTime);
           
        }
        if (muerto)
        {
            if (tiempoHumo > 0)
            {
                tiempoHumo -= Time.deltaTime;
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }

    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        anim.SetTrigger("Enemigo");
        if (vidas <= 0)
        {
            humo.SetActive(true);
            nave.SetActive(false);
            muerto = true;
        }


    }

    private IEnumerator SpawnDisparos()
    {
        while (true)
        {
            
            Instantiate(DisparoEnemigos, SpawnDisparo.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }


     
}   
