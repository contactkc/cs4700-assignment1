using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 thirdPersonOffset = new Vector3(0, 5, -7);
    private Vector3 firstPersonOffset = new Vector3(0, 3, 0);
    private bool isFirstPerson = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            isFirstPerson = !isFirstPerson;
        }   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // offset camera first person
        if (isFirstPerson) {
            transform.position = player.transform.position + player.transform.TransformDirection(firstPersonOffset);
            transform.rotation = player.transform.rotation;
        }
        else {
            // offset camera behind player
            transform.position = player.transform.position + player.transform.TransformDirection(thirdPersonOffset);
            float playerYaw = player.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(15.12f, playerYaw, 0.121f);
        }
    }
}
