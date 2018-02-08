using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bird : MonoBehaviour
{
    public float JumpForce;
    public bool _bIsAlive;

    Rigidbody _rb;

    [SerializeField]
    GameController GC;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _bIsAlive = true;
    }

    void FixedUpdate()
    {
        if (_bIsAlive && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        _bIsAlive = false;

        GC.StopPipe();

        GetComponent<BoxCollider>().enabled = false;

        _rb.AddForce(Vector3.up * (10), ForceMode.Impulse);
        _rb.AddTorque(new Vector3(700, 0, 0), ForceMode.Impulse);

        StartCoroutine(DeathCountdown());
    }

    void OnTriggerEnter(Collider hit)
    {
        GC.SetScore(1);
    }

    IEnumerator DeathCountdown()
    {
        yield return new WaitForSeconds(5);
        GC.RestartGame();
    }
}
