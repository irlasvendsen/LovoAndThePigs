using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//Player movement control 
	Rigidbody2D rbody;
	Animator animator;

	public GameObject ammo;
	public GameObject clone;
	public Transform blowMarker;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
	
		if( movement_vector != Vector2.zero)
		{
			animator.SetBool  ("IsWalking",true);
			animator.SetFloat  ("Input_X",movement_vector.x);
			animator.SetFloat ("Input_Y",movement_vector.y);
		}

		else
		{
			animator.SetBool  ("IsWalking", false);
		}

		rbody.MovePosition(rbody.position + movement_vector* Time.deltaTime);

		PlayerBlowing ();

	}


	void PlayerBlowing()
	{
		if (Input.GetKeyDown ("space")&& ammo != null)
		{
			animator.SetBool ("IsBlowing", true);

			clone = Instantiate(ammo,blowMarker.position,Quaternion.identity) as GameObject;
			clone.transform.localScale = transform.localScale;

		} 

		else 
		{
			animator.SetBool  ("IsBlowing",false);
			Destroy (clone,.8f);
	
		}


	}


	

}
