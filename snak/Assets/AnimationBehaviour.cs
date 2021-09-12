using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
	public Transform target;
	Animator anim;
	// Use this for initialization
	void Start()
	{
	 anim = gameObject.GetComponent<Animator>();
		anim.Play("tae", 1, float.PositiveInfinity);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.D))
		{
			 anim = gameObject.GetComponent<Animator>();
			// Reverse animation play
			anim.SetFloat("Direction", -1);
			anim.Play("tae");
		}
		else if (Input.GetKey(KeyCode.A))
		{
			 anim = gameObject.GetComponent<Animator>();
			// Reverse animation play
			anim.SetFloat("Direction", 1);
			anim.Play("tae");
		}
		transform.localPosition = target.localPosition;
	}
}
