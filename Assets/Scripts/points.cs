using UnityEngine;

public class points : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePoint();
    }

    void RotatePoint()
    {
        transform.Rotate(new Vector3(15, 45, 30) * Time.deltaTime);
    }
}
