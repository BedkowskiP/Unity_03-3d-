using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator _anim;

	//Movement w,s,a,d
	public void isForward(bool x)
	{
		_anim.SetBool("Forward", x);
	}
	public void isBackward(bool x)
	{
		_anim.SetBool("Backward", x);
	}
	public void isLeft(bool x)
	{
		_anim.SetBool("MoveLeft", x);
	}
	public void isRight(bool x)
	{
		_anim.SetBool("MoveRight", x);
	}


	//Movement sprint, walk
	public void isSprint(bool x)
	{
		_anim.SetBool("isSprint", x);
	}
	public void isWalk(bool x)
	{
		_anim.SetBool("isWalk", x);
	}
	public bool isWalking()
	{
		return _anim.GetBool("isWalk");
	}

}
