using UnityEngine;
using System.Collections;

public class Love_Collide : MonoBehaviour {
    [SerializeField]
    private CircleCollider2D female;
    private GameObject Win;

    // Use this for initialization
    void Start () {
        Win = GameObject.Find("Win");
        Win.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
    
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name.Equals("Player"))
        {
            Physics2D.IgnoreCollision(other, female, false);
            Win.SetActive(true);
          
        }

    }
   
}
