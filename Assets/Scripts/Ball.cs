using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    public float throwForce;
    public float gravityMultiplier;
    public float zDistance;
    public int attempts;
    public Rigidbody rb;
    public bool onCup;
    public bool isShoot;
    Vector3 o;
    [SerializeField] GameObject dustParticle;
    Transform tf;
    [SerializeField] float rHeigth;

    public Transform hitPoint;
    public int woodsHit;
    
    public Queue<Vector3> velocities = new Queue<Vector3>();

    [SerializeField] TrailRenderer trail;
    public Vector3 forceMultiplier;
    
    // Update is called once per frame
 public void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        attempts = PlayerPrefs.GetInt("attempts");
        rb.useGravity = false;
        o = transform.position;
        tf = transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10) 
        {
            Destroy(Instantiate(dustParticle, transform.position, Quaternion.identity), 3f);
        }
        else if(collision.gameObject.layer == 4)
        {
            LevelLoader.instance.ReloadScene();
        }
    }
    
    public void DrawProjection(Vector3 dir)
    {
       // dir.Scale(InputController.instance.forceMultiplier);
        Projection.instance.UpdateLine(dir, rb, rb.position);
    }
    void FixedUpdate()
    {
       
        velocities.Enqueue(rb.velocity);
        if (velocities.Count > 2) velocities.Dequeue();
        
        if (isShoot) rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration); 
    }
    public  void Shoot(Vector3 dir)
    {
        if (isShoot) return;
        rb.AddForce(dir,ForceMode.VelocityChange);
        rb.AddTorque(10 * Vector3.right);
        attempts++;
        PlayerPrefs.SetInt("attempts", attempts);
        isShoot = true;
        Projection.instance.HideLine();
        UIController.instance.Retry();
        CameraController.instance.AdjustOffset();
    }
    public void ResetShoot() => isShoot = false;
    
    public void Reflect(Vector3 velocity)
    {
        StartCoroutine(ReflectRoutine(velocity));   
    }

    private IEnumerator ReflectRoutine(Vector3 velocity)
    {
        yield return new WaitForFixedUpdate();
        rb.velocity = velocity;
    }
    private void Update()
    {
        if (tf.position.y <= -rHeigth) LevelLoader.instance.ReloadScene();    
    }
}
