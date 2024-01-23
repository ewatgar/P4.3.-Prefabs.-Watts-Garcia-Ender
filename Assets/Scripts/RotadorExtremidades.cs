using UnityEngine;

public class RotadorExtremidades : MonoBehaviour
{
    [SerializeField] public float angMinimo = -30;
    [SerializeField] public float angMaximo = 30;
    [SerializeField] public float vAngular = 150;
    [SerializeField] public float direccion = 1;

    private float anguloTotal = 0;

    void Start()
    {
        
    }


    void Update()
    {
        if (anguloTotal >= angMaximo || anguloTotal <= angMinimo){
            direccion *= -1;
            anguloTotal = Mathf.Clamp(anguloTotal,angMinimo,angMaximo);
        }

        float angulo = vAngular * Time.deltaTime;
        anguloTotal += direccion*angulo;
        
        transform.localEulerAngles = new Vector3(anguloTotal,0,0);
    }
}
