using StarterAssets;
using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    Animator playerAnimator;
    ThirdPersonController thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        //playerRb = GetComponentInChildren<Rigidbody>();

        thirdPersonController = GetComponentInChildren<ThirdPersonController>();

        print(playerAnimator.name);
        print(thirdPersonController.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && thirdPersonController.Grounded)
        {
            playerAnimator.SetTrigger("Punch");
            StopMovement();

            StartCoroutine(SET_SPEED());
        }
    }

    private void StopMovement()
    {
        thirdPersonController.MoveSpeed = 0f;
        thirdPersonController.SprintSpeed = 0f;
    }

    IEnumerator SET_SPEED()
    {
        yield return new WaitForSeconds(2.2f);
        thirdPersonController.MoveSpeed = 2f;
        thirdPersonController.SprintSpeed = 5.335f;
    }
}
