using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthroat : MonoBehaviour
{
    public Transform sun; // 太阳的 Transform
    public float orbitSpeed = 10f; // 公转速度

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
