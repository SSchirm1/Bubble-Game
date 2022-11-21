using UnityEngine;

public class Follow_player : MonoBehaviour {

    public Transform player;
    public float offsetX = -2;
    public float offsetY = 2;
    public float offsetZ = -3;
    public GameObject gb;

    // Update is called once per frame
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.T)) {
            offsetX = -offsetX;
            offsetZ = -offsetZ;
            playerController.keydir *= -1;

        }
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);
        gb.transform.LookAt(player);
    }
}