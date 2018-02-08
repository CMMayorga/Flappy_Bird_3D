using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour
{
    public float Speed;

    Bird bird;

    void Start()
    {
        bird = FindObjectOfType<Bird>();
        StartCoroutine(DeletePipe());
    }

    void Update()
    {
        if (bird._bIsAlive)
        {
            transform.position = transform.position + transform.forward * Speed * Time.deltaTime;
        }
    }

    IEnumerator DeletePipe()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

}
