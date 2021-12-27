using StarterAssets;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public bool isFlying;

    Animator playerAnimator;

    ThirdPersonController playerController;

    FlyCameraControls flyCamera;

    // Start is called before the first frame update
    void Start()
    {
        flyCamera = GetComponentInChildren<FlyCameraControls>();
        flyCamera.enabled = false;

        playerAnimator = GetComponentInChildren<Animator>();
        playerController = GetComponentInChildren<ThirdPersonController>();

        print("Animator: " + playerAnimator.name);

        isFlying = false;
        playerAnimator.SetBool("Fly", isFlying);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("Fly");

            isFlying = true;

            playerAnimator.SetBool("Fly", isFlying);

            //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, 20f, 0f), 2f);

            playerController.enabled = false;
            flyCamera.enabled = true;

            /*
            playerController.JumpTimeout = 10f;
            playerController.Gravity = 0.7f;

            playerController.MoveSpeed = 10f;
            playerController.SprintSpeed = 20f;
            */
            
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            isFlying = false;
            playerController.enabled = true;
            flyCamera.enabled = false;

            playerAnimator.SetBool("Fly", isFlying);

            /*
            playerController.FallTimeout = 0.15f;
            playerController.Gravity = -15.0f;

            playerController.MoveSpeed = 2f;
            playerController.SprintSpeed = 5.335f;
            */
        }
    }
}
