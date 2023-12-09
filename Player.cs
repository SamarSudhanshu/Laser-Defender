using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float paddingLeft, paddingRight, paddingBottom, paddingTop;
    private Vector2 rawInput;
    private Vector2 minBound;
    private Vector2 maxBound;
    private Shooter shooter;

    private void Awake() {
        shooter = GetComponent<Shooter>();
    }
    private void Start() {
        InitializeBound();
    }

    private void Update() {
        Move();
    }

    private void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value) {
        if (shooter != null)
            shooter.isFiring = value.isPressed;

    }

    private void Move() {
        Vector2 delta = (rawInput * moveSpeed * Time.deltaTime);
        Vector2 newPos = new Vector2();
        // Mathf.Clamp(original value, minimum value, maximum value);
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);
        transform.position = newPos;
    }

    private void InitializeBound() {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2 (1,1));
    }
}