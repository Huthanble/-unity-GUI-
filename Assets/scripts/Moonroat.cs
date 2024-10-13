using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonroat : MonoBehaviour
{
    public Transform earth; // 地球的 Transform
    public float orbitSpeed = 30f; // 公转速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(earth.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
