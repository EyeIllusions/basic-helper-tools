using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    public CharInput asset;

    public Vector2 Move;
    public Vector2 Look;
    public float Jump;
    public float Sprint;
    public bool Interact;
    public UnityEvent onInteract;
 
 
    public void Awake()
    {
        asset = new CharInput();
        asset.Enable();

        Move = asset.Player.Move.ReadValue<Vector2>();
        Look = asset.Player.Look.ReadValue<Vector2>();
       
    }

    public void Update()
    {

        Move = asset.Player.Move.ReadValue<Vector2>();
        Look = asset.Player.Look.ReadValue<Vector2>();
        if (asset.Player.Interact.WasPressedThisFrame())
        {
          onInteract.Invoke();
        }
    }

    public void OnJump(InputValue ctx)
    {
        Jump = ctx.Get<float>();
    }

    public void OnSprint(InputValue ctx)
    {
        Sprint = ctx.Get<float>();
    }
    
  
}
  