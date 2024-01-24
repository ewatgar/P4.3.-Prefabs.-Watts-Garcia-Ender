using UnityEngine;

public class PositionController : MonoBehaviour
{
    [Range(1, 20)] public float speed = 8;
    [SerializeField] public float velocidadArriba = 3;
    [SerializeField] public float velocidadMin = -10;
    [SerializeField] public float gravedad = 50;
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

        if (Input.GetKey(KeyCode.Space)){
            incPosicionY = velocidadArriba;
        } else if (incPosicionY > velocidadMin){
            incPosicionY += gravedad*Time.deltaTime;
            if (incPosicionY < velocidadMin){
                incPosicionY = velocidadMin;
            }
        }

        //transform.Translate(new Vector3(incPosicionX,0,incPosicionZ),Space.Self);
        //transform.Translate(new Vector3(0,incPosicionY,0),Space.World);
        characterController.Move(transform.TransformDirection(new Vector3(incPosicionX,0,incPosicionZ)));
        characterController.Move(new Vector3(0,incPosicionY/10,0));
    }
}
