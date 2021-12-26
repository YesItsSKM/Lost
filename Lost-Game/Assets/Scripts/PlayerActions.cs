using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    Animator playerAnimator;
    ThirdPersonController thirdPersonController;
    GameObject spawnedBeam;

    public GameObject beam;
    public Transform beamLocation;

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
            Attack();

            StopMovement();

            StartCoroutine(SET_SPEED());
        }

        if (spawnedBeam)
        {
            //print(spawnedBeam.transform.name);
            spawnedBeam.transform.localRotation = beamLocation.transform.rotation;
        }
    }

    private void Attack()
    {
        playerAnimator.SetTrigger("Punch");

        //Instantiate(beam, transform.position + transform.forward + new Vector3(0f, 0.5f, 0f), Quaternion.identity);

        StartCoroutine(SPAWN_BEAM());
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

    IEnumerator SPAWN_BEAM()
    {
        yield return new WaitForSeconds(0.7f);

        spawnedBeam = Instantiate(beam, beamLocation.transform.position, beamLocation.transform.rotation);

        Destroy(spawnedBeam, 1.5f);
    }
}
