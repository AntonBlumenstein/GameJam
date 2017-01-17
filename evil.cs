using UnityEngine;
using System.Collections;

public class evil : MonoBehaviour
{

    private BoxCollider2D playerCollider;
    private GameObject player;
    private GameObject life;
    private GameObject cam;
    private int i = 0;
    private string test = "life";
    private Rigidbody2D myRigid;
    public bool hit=true;
 
    // private bool movement;



    // Use this for initialization
    void Start()
    {   
    }

    void FixedUpdate()
    {
        player = GameObject.Find("Player");
        life = GameObject.Find("life" + i);
       // cam = GameObject.Find("Cam");
        HandleInput();
    }


    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.name = "pPlatform";
            player.transform.localScale += new Vector3(2f, -.2f, 0);
            duplicate();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            hit = false;
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.gameObject.name == "Player")
        {
            other.name = "pPlatform";
            other.transform.localScale += new Vector3(2.0f, -.2f, 0);
            duplicate();   
        }
    }


    private void duplicate()
    {
        string change = test + i;
        life = GameObject.Find(change);
        life.transform.localScale = new Vector3(0.8f, 1.0f, 1.0f);
        life.name = "Player";
        i++;
       // cam.transform.localPosition = new Vector3(0f, 1.5f, 0f);
    }



    public bool Hit
    {
        get {return hit; }
        set {hit = value; }
    }

}

