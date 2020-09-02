using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody rb; //breytir nafn svo léttara að skrifa

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Update is called once per frame
    void FixedUpdate() // FixedUpdate vegna unity höndlar physics betra með það
    {
        rb.AddForce(0,0,forwardForce * Time.deltaTime); // Time.deltaTime notað til að laga fps vandamál milli tölvur

        if ( Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if ( Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
