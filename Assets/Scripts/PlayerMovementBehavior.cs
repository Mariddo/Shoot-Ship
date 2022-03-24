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

    public GameShipSystemController gameSystemController;

    public Rigidbody2D gameSystemRB;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerWeaponBehavior = transform.GetChild(0).GetComponent<PlayerWeaponBehavior>();

        if(gameSystemController != null)
        {
            gameSystemRB = gameSystemController.GetComponent<Rigidbody2D>();
        }
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

        float speedMod;

        if(gameSystemController != null && gameSystemRB != null) {
            speedMod = gameSystemRB.velocity.y;
        }
        else{
            speedMod = 0;
        }

        float verticalSpeed = rawInput.y * moveSpeedVertical;

        rb.velocity = new Vector2(rawInput.x * moveSpeedHorizontal, rawInput.y * moveSpeedVertical + speedMod * 0.8f);

    }

    void OnFire(InputValue value) {


        if(playerWeaponBehavior != null)
        playerWeaponBehavior.isFiring = value.Get<float>();

    }
}
