using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    public PlayerMovement movement; //tengir við okkar hreyfi skriftu

    // þessi skrifa keyrir þegar við snertum annan hlut og nær í info um það sem við snertum
    void OnCollisionEnter(Collision collisionInfo)
    {
        // checka hvort við höfum snert hluti með tag obstacle
        if (collisionInfo.collider.tag == "Obstacle")
        {
         movement.enabled = false; //stopa spillara hreyfingar
         FindObjectOfType<GameManager>().EndGame();
        }
    }

}
