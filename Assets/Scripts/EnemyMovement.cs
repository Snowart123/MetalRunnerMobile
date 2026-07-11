using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float range;
    
    private  Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.Sin(Time.time * speed) * range);
    }
}