using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    float horizontalMove;
    float verticalMove;

    // Start is called before the first frame update
    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        characterMovement.Move(horizontalMove, verticalMove, false);
    }
}
