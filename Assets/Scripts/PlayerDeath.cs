using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Vector3 respawnPoint = new Vector3(0, 1, 0);

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Respawn the player at the specified point
            transform.position = respawnPoint;

            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}