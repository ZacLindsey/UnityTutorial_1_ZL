using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;

    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Pick Up 1"))
        {
            other.gameObject.SetActive(false);
            count+=100;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 100)
        {
            winText.text = "You Win!";
        }
    }
}
