using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    Vector2 rawInput;

    Rigidbody2D rb;

    public float moveSpeedHorizontal = 8.0f;
    public float moveSpeedVertical = 6.0f;

    [HideInInspector]public PlayerWeaponBehavior playerWeaponBehavior;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerWeaponBehavior = transform.GetChild(0).GetComponent<PlayerWeaponBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void OnMove(InputValue value){

        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }

    void Movement() {

        rb.velocity = new Vector2(rawInput.x * moveSpeedHorizontal, rawInput.y * moveSpeedVertical);

    }

    void OnFire(InputValue value) {


        if(playerWeaponBehavior != null)
        playerWeaponBehavior.isFiring = value.Get<float>();

    }
}
