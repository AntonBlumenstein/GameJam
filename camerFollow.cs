using UnityEngine;
using System.Collections;

public class camerFollow : MonoBehaviour
{

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;


    private Transform target;

    private evil evil;
    GameObject evil_;
    GameObject cameraFollow;
     float x ;
     float y ;
     float z;

    void Start()
    {
        evil_ = GameObject.Find("Evil_Spikes");
        evil = evil_.GetComponent<evil>(); 
    }


    // Use this for initialization
    void Update()
    {
        x = transform.position.x;
        if (evil.Hit)
        {
            target = GameObject.Find("Player").transform;
            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
        }
        else
        {
            x -= 0.2f;
            y-= 0.1f;
            transform.position = new Vector3(x, 0, y);
            
            if(x <= -9.3f)
            {
                
               
                evil.Hit = true;
                
            }
        


        }
    }

    
    
}
