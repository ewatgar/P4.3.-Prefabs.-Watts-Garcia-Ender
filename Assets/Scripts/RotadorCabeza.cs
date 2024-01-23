using UnityEngine;

public class RotadorCabeza : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(target.transform);
    }
}
