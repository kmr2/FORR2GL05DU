using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    public Text coinText;

    public int CoinCounter = 0;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);


    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] howManyLeft;
        howManyLeft = GameObject.FindGameObjectsWithTag("Coin");
        if(howManyLeft.Length == 0){
            coinText.text = "Game Over";
        }
        else{
            coinText.text = "Coins : " + CoinCounter.ToString();
        }


        coinText.text = "Coins: " + CoinCounter.ToString();

        transform.Translate(Input.GetAxis("Horizontal") / 100, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;

        }
        if (Input.GetKeyDown(KeyCode.R) && isGrounded) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}
    
    }

void onCollisionStay()
{
    isGrounded = true;
}

void OnTriggerEnter(Collider other){

    if(other.CompareTag("Coin")){
        CoinCounter++;
        Object.Destroy(other.gameObject);
    }

}

}