using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public float moveSpeed = 10;
	public Animator animator;
	public Direction direction = Direction.Down;
	public bool walking = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = Vector2.zero;

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		walking = false;

		if (Input.GetButton("Horizontal")) {
			movement.x = h;
			walking = true;

			if (h < 0) {
				direction = Direction.Left;
			} else {
				direction = Direction.Right;
			}

		} else if (Input.GetButton("Vertical")) {
			movement.y = v;
			walking = true;

			if (v < 0) {
				direction = Direction.Down;
			} else {
				direction = Direction.Up;
			}
		}

		animator.SetBool("Walking", walking);
		animator.SetInteger("Direction", (int) direction);

		transform.Translate(movement * moveSpeed * Time.deltaTime);
	
	}
}
