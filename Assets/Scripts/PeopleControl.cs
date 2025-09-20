using UnityEngine;

public class PeopleControl : MonoBehaviour
{
    public float moveSpeed;
    bool movingLeft=true;
    bool fistInput=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
        Move();
        CheckInput();
        }
        if(transform.position.y<=-2)
        {
            GameManager.instance.gameOver();
        }    
        
    }
    void Move()
    { transform.position += transform.forward * moveSpeed * Time.deltaTime; }    
    void CheckInput()
    { 
        if (fistInput)
        { fistInput = false;
            return;
        }    
        if (Input.GetMouseButtonDown(0))
        { ChangeDirection(); }    }
    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
