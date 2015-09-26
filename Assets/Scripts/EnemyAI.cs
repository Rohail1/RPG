using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform target;
    public int moveSpeed = 1;
    public int rotationSpeed= 1;
    public int maxDistance = 2;

    private Transform mytransform;

    void Awake()
    {
        mytransform = transform;
    }
    // Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(target.position, mytransform.position);

        // Look At Target

          mytransform.rotation = Quaternion.Slerp(mytransform.rotation, Quaternion.LookRotation(target.position - mytransform.position), rotationSpeed * Time.deltaTime);
        //  mytransform.LookAt(target)

        //Move Forward

        if (Vector3.Distance(target.position, transform.position) > maxDistance) 
        {
     
            mytransform.position += mytransform.forward * Time.deltaTime * moveSpeed;
        }
        
    }

}
