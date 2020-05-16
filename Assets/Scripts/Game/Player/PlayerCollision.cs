using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != gameObject.tag){
            PlayerController.instance.scoreUP();
            Destroy(other.gameObject);
        }
        else
        {
            PlayerController.instance.reduceLife();
            Destroy(other.gameObject);
        }
    }
}
