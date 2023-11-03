using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class charactercontroller : MonoBehaviour
{
    [Header("SPEED VALUES")]
    public float WalkSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float sprintSpeed;
    [Header("PHYSICS VALUES")]
    public float gravity = 20.0F;
     float gravityMultiplyer = 3;

     Vector3 PlayerDirection;
    Vector3 PlayerMovement;
    float _OnSprint;
    public CharacterController characterController;
    int jumpcount;
    int maxjumpcount = 2;
    Camera MainCam;
     CharInput playerinput;
    float velocity;
   // public Animator animator;
    public float smoothTime;
    public Vector2 smoothInputVelocity = Vector2.zero;
    public bool isThirdPerson = true;
    public float lookSpeed=20;
    //LOCKMOUSE
    //ROTATEUPDATE
    //MOVEUPDATE


    private void Start()
{
     playerinput = new CharInput();
    playerinput.Enable();
    Cursor.lockState = CursorLockMode.Locked;
    characterController=   gameObject.GetComponent<CharacterController>();
    MainCam = Camera.main;

}
private void Update() 
{

    GravityTick();
    RotateTick();
    MoveTick();    
    //animator.SetFloat("BlendX",PlayerDirection.x);
   // animator.SetFloat("BlendY",PlayerDirection.y);
    characterController.Move(PlayerMovement);

}
void RotateTick()
{
        if (isThirdPerson)
        {
            float distToCam = Vector3.Distance(MainCam.transform.position, transform.position);
            gameObject.transform.LookAt(MainCam.transform.position - new Vector3(0, (MainCam.transform.position.y - transform.position.y), 0));
            transform.Rotate(0, 180, 0);
        }
        else
        {
            transform.Rotate(0, -playerinput.Player.Look.ReadValue<Vector2>().x * Time.deltaTime * lookSpeed, 0);
        }
}
void MoveTick()
{
   
  
        if (_OnSprint > 0)
        {
            PlayerDirection = Vector2.SmoothDamp(PlayerDirection, playerinput.Player.Move.ReadValue<Vector2>() * sprintSpeed, ref smoothInputVelocity, smoothTime);
            PlayerMovement = ((transform.right * PlayerDirection.x) + (transform.forward * PlayerDirection.y) + (transform.up * PlayerMovement.y) )  * Time.deltaTime;
        }
        else
        {
            PlayerDirection = Vector2.SmoothDamp(PlayerDirection, playerinput.Player.Move.ReadValue<Vector2>() * WalkSpeed, ref smoothInputVelocity, smoothTime);
            PlayerMovement = ((transform.right * PlayerDirection.x) * WalkSpeed + (transform.forward * PlayerDirection.y) * WalkSpeed + (transform.up * PlayerMovement.y)) * Time.deltaTime;
        }
       
    }
void GravityTick()
        {
           if(characterController.isGrounded){
                velocity = 0.1f;
                jumpcount = 0;
        }
           else{
            velocity +=  gravity * gravityMultiplyer * Time.deltaTime;
            PlayerMovement.y += velocity;
            }
        }

public void OnJumpPressed(InputAction.CallbackContext ctx)
{

    if(jumpcount >= maxjumpcount) return;  
        velocity += jumpSpeed;
        jumpcount++;
}

    public void OnJumpReleased(InputAction.CallbackContext ctx){ }
 
public void OnSprint(InputValue ctx)
    {
        _OnSprint = ctx.Get<float>();
    }

private void OnEnable() {
      //  playerinput.FindAction("Jump").started += ctx=>OnJumpPressed(ctx);
      //  playerinput.FindAction("Jump").canceled += ctx =>OnJumpReleased(ctx);

}
private void OnDisable() {
       // playerinput.FindAction("Jump").started -= ctx=>OnJumpPressed(ctx);
       // playerinput.FindAction("Jump").canceled -= ctx =>OnJumpReleased(ctx);
}




}
