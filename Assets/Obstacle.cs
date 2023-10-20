using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private Transform returnPoint;

    private bool hitted = false;
    private void Update()
    {
        transform.position = transform.position + (new Vector3(-1, 0f, 0f) * speed * Time.deltaTime);
    }
    public void SetSpeed(float value)
    {
        speed = value;
    }
    public void SetHitted(bool value)
    {
        hitted = value;
    }
    public bool GetHitted()
    {
        return hitted;
    }
    private void FixedUpdate()
    {
       if(transform.position.x <= returnPoint.position.x)
        {
            transform.position = spawnPoint.position + (Vector3.up * (Random.Range(-1.7f,1.7f)));
            hitted = false;
        }
    }
}
