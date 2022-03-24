using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShipSystemController : MonoBehaviour
{
    public float movingSpeed = 1f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,movingSpeed);
    }
}
