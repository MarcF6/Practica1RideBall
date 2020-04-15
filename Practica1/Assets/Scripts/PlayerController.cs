using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public GameObject sonido;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCount();
        winText.text = "";
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moviment = new Vector3(moveHorizontal, 0.0f, moveVertical);


        rb.AddForce(moviment*8);

     
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 4, 0),ForceMode.VelocityChange);
        }


    }




    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
            {

               
                other.gameObject.SetActive(false);
            count = count + 1;
            SetCount();


        Instantiate(sonido);
            
        }
        
    }
    void SetCount()
    {
        countText.text = "Count: " + count.ToString();
        if (count > 4){
            winText.text = "¡Final del Juego!";
        }
    }
}

