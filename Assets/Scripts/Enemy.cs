using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform lastPoint,car;

    NavMeshAgent nav;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }//Start

    private void Update()
    {
        Move();
    }//Update

    void Move()
    {
        nav.SetDestination(lastPoint.position);

        car.transform.position = new Vector3(transform.position.x ,
                                            car.transform.position.y ,
                                            transform.position.z);

        car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x,
                                                transform.eulerAngles.y, 
                                                transform.eulerAngles.z );
    }//Move (Move car and stabalize car rotation)

}//class

