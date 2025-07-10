using UnityEngine;

public class BlockPusher : MonoBehaviour
{
    public float Speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        //capture user input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        //create a new vector of player movement
        Vector3 move = new Vector3(horizontal, 0, vertical) * Time.deltaTime * Speed;

        //move to the new position
        transform.position = transform.position + move;
    }
}
