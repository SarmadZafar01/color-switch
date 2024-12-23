using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;


    public Rigidbody2D rb;

    public string currentColor;
    public SpriteRenderer spriteRenderer;

    public Color  ColorLightBlue;
    public Color ColorYellow;
    public Color ColorPink;
    public Color ColorPurple;



    private void Start()
    {
        setRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { 

            rb.velocity = Vector2.up * jumpForce;
        }


}

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ColorChanger")
        {
            setRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag!=currentColor) 
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }


    void setRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "LightBlue";
                spriteRenderer.color = ColorLightBlue;
                break;
                case 1:
                currentColor = "Yellow";
                spriteRenderer.color = ColorYellow;
                break;
                case 2:
                currentColor = "Pink";
                spriteRenderer.color = ColorPink;
                break;
                case 3:
                currentColor = "PurPle";
                spriteRenderer.color = ColorPurple;
                break;
                

        }
    }

}
