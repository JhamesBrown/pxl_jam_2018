using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_logic : MonoBehaviour
{

    public float directionHoldTime = 1.0f;
    public Sprite[] sprites = new Sprite[3];
    public SpriteRenderer spriteRender;
    public GameObject dogBody;
    public float leapForce = 100.0f;
    
    public float detectDistance = 2.0f;

    private Rigidbody2D rb;
    private Vector2 direction;
    private SpriteRenderer dogBodySprite;

    enum idlestates
    {
        left,
        right,
        down,
    }


	void Start ()
    {
       dogBodySprite = dogBody.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {


        switch (timeToState())
        {
            case 0:
                spriteRender.sprite = sprites[1];
                spriteRender.flipX = false;
                direction = Vector2.left;
                break;
            case 1:
                spriteRender.sprite = sprites[0];
                spriteRender.flipX = false;
                direction = Vector2.down;
                break;
            case 2:
                spriteRender.sprite = sprites[1];
                spriteRender.flipX = true;
                direction = Vector2.right;
                isCatInDirectionCheck(direction);
                break;
            default:
                break;
        }

        if (isCatInDirectionCheck(direction))
        {
            dogLeap(direction);
        }
        

    }

    bool isCatInDirectionCheck(Vector2 _direction)
    {
        bool _isCatThere = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction);
        if (hit.collider != null)
            _isCatThere = (hit.collider.gameObject.tag == "Cat")? true: false;
        return _isCatThere;
    }

    int timeToState()
    {
        int _n = Mathf.FloorToInt(Time.time / directionHoldTime) % 3;
        return _n;
    }


    void dogLeap(Vector2 _direction)
    {

        dogBodySprite.sprite = sprites[2];
        rb.AddRelativeForce(_direction * leapForce);
        dogBody.transform.eulerAngles = new Vector3(0.0f,0.0f,90.0f);
    }
}

