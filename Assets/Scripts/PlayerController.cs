using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;

    //matvei
    private Vector2 pos;
    [SerializeField] private Interaction inter;
    //matvei

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
        pos = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        
    }

    //matvei
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        inter.Interact(pos + direction * 1.16f, false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inter.Interact(pos + direction * 1.16f, true);
    }
    //matvei
}
