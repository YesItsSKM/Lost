using StarterAssets;
using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    Animator playerAnimator;
    ThirdPersonController thirdPersonController;
    GameObject spawnedBeam;

    public GameObject beam;
    public Transform beamTransform;

    public ChangePost post;

    public AudioClip beamSound;
    AudioSource beamAudioSource;

    float lerpChroma;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        //playerRb = GetComponentInChildren<Rigidbody>();

        thirdPersonController = GetComponentInChildren<ThirdPersonController>();

        print(playerAnimator.name);
        print(thirdPersonController.name);

        beamAudioSource = GetComponent<AudioSource>();
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
            spawnedBeam.transform.localRotation = beamTransform.transform.rotation;
            spawnedBeam.transform.position = beamTransform.transform.position;

            lerpChroma = Mathf.Lerp(0.2f, 4f, 0.2f);

            post.chromaticAberration.intensity.value = lerpChroma;
        }
    }

    private void Attack()
    {
        playerAnimator.SetTrigger("Punch");

        beamAudioSource.clip = beamSound;
        beamAudioSource.Play();

        //Instantiate(beam, transform.position + transform.forward + new Vector3(0f, 0.5f, 0f), Quaternion.identity);

        //post.chromaticAberration.intensity.value = 1f;

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

        spawnedBeam = Instantiate(beam, beamTransform.transform.position, beamTransform.transform.rotation);

        Destroy(spawnedBeam, 1.5f);

        StartCoroutine(CHROMATIC_SHIFT());
    }

    IEnumerator CHROMATIC_SHIFT()
    {
        yield return new WaitForSeconds(1.5f);

        post.chromaticAberration.intensity.value = 0.2f;
    }
}
