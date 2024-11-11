using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject disparo; 
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float vidas;
    [SerializeField] private Animator anim;
    [SerializeField] private TMP_Text textoVidas;

    Player1 player;
    void Start() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(h, v, 0).normalized * velocidad * Time.deltaTime);

        Disparar();
    }

    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        anim.SetTrigger("Hit");
        textoVidas.SetText(vidas.ToString());
        if (vidas <= 0)
        {
            Destroy(gameObject);

        }


    }

    private void LimitarMovimiento() 
    {
        float yClamped = Mathf.Clamp(transform.position.y, -40f, 41.3f);
        float xClamped = Mathf.Clamp(transform.position.x, -70f, 50f);

        transform.position = new Vector3(yClamped,xClamped, 0);
    }

    private void Disparar() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(disparo, spawnPoint.transform.position, Quaternion.identity);
        } 
    }
}
