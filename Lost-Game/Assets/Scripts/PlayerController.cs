using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public LayerMask layerMask;

    private Rigidbody rigidbody;
    public bool grounded;

    public Transform target;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !this.grounded)
        {
            Jump();
        }

        //float mouseX = Input.GetAxis("MouseX")

        //this.transform.LookAt(target);
    }

    private void FixedUpdate()
    {
        isGrounded();
        //Jump();
        Move();
    }

    void isGrounded()
    {
        if(Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;
            //animator.SetBool("jump", false);
        }
        else
        {
            this.grounded = false;
        }

        //print(grounded);

        this.animator.SetBool("jump", this.grounded);
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * vertical + this.transform.right * horizontal;
        movement.Normalize();

        this.transform.position += movement * 0.02f;

        //this.transform.eulerAngles = Quaternion.EulerAngles(target.localEulerAngles);

        this.animator.SetFloat("vertical", vertical);
        this.animator.SetFloat("horizontal", horizontal);


    }

    void Jump()
    {
        this.animator.SetBool("jump", true);
        this.rigidbody.AddForce(Vector3.up * 4, ForceMode.Impulse);

        //animator.SetBool("jump", true);
    }
}
