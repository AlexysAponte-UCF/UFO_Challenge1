using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text countDrop;
    public Text winText;
    public Text winDrop;
    public GameObject player;
    private GameObject[] pu;
    private GameObject[] enm;
    private Rigidbody2D rb2d;
    private int count;
    private int level;
    Vector2 originalPos;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        winDrop.text = "";
        SetCountText();
        pu = GameObject.FindGameObjectsWithTag("Pickup");
        enm = GameObject.FindGameObjectsWithTag("Enemy");
        level = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            player.gameObject.SetActive(false);
            Invoke("Reset",2f);
        }
    }
    private void Reset()
    {
        count = 0;
        SetCountText();
        player.gameObject.SetActive(true);
        transform.position = originalPos;
        foreach (GameObject go in pu)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in enm)
        {
            go.SetActive(true);
        }
    }
    void SetCountText()
    {
        countText.text = "Count = " + count.ToString();
        countDrop.text = "Count = " + count.ToString();
        if (count >= 12) 
        {
            SceneManager.LoadScene(level);
            winText.text = "You Win! Game created by Alexys Aponte";
            winDrop.text = "You Win! Game created by Alexys Aponte";

        }
    }
}
