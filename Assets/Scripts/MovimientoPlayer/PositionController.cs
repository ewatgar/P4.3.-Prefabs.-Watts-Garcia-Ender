using UnityEngine;

public class PositionController : MonoBehaviour
{
    [Range(1, 20)] public float speed = 8;
    public float jumpInitialSpeed = 3.5f;
    public float fallSpeedLimit = -20;
    public float gravity = -10;
    float currentSpeed = -10;
    private bool isGrounded = false;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float incPosicionX = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float incPosicionZ = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        float incPosicionY = 0;

        /*
        if (Input.GetKey(KeyCode.Space)){
            incPosicionY = speed*Time.deltaTime;
        } else if (Input.GetKey(KeyCode.LeftShift)){
            incPosicionY = -speed*Time.deltaTime;
        }*/

        /*
        if (Input.GetKey(KeyCode.Space) ){
            incPosicionY = velocidadArriba;
        } else if (incPosicionY > velocidadMin){
            incPosicionY += gravedad*Time.deltaTime;
            if (incPosicionY < velocidadMin){
                incPosicionY = velocidadMin;
            }
        }*/
        float currentSpeed = -10;

        if (Input.GetKey(KeyCode.Space) && isGrounded){
            currentSpeed = jumpInitialSpeed * Time.deltaTime;
        }else if (incPosicionY > fallSpeedLimit){
            currentSpeed += gravity*Time.deltaTime;
            if (currentSpeed < fallSpeedLimit){
                currentSpeed = fallSpeedLimit;
            }
        }

        incPosicionY = currentSpeed * Time.deltaTime;

        characterController.Move(transform.TransformDirection(new Vector3(incPosicionX,0,incPosicionZ)));
        characterController.Move(new Vector3(0,incPosicionY,0));

        isGrounded = characterController.isGrounded;
    }
}
