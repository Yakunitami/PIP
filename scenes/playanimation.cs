using Godot;
using System;

public partial class playanimation : AnimationPlayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		this.Play("idle");
	}

}
