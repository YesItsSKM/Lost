using UnityEngine;

public class FollowPlayerParticle : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(0f, 10f, 0f);
        
    }
}
