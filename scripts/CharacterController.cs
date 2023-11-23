using System.Runtime.CompilerServices;
using Godot;

public partial class CharacterController : CharacterBody2D
{	
	[Export]
	public NodePath LabelPath = new NodePath();
	[Export]
	public NodePath PlayerAnimationPlayerPath = new NodePath();
	[Export]
	public NodePath AnimationPlayerPath = new NodePath();
	[Export]
	public NodePath TextureRectPath = new NodePath();
	private Label _label;
	private TextureRect _textureRect;
	private AnimationPlayer _playerAnimationPlayer;
	private AnimationPlayer _animationPlayer;
	public const float Speed = 450.0f;
	
	public override void _Ready()
	{
		_label = GetNode<Label>(LabelPath);
		_animationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);
		_playerAnimationPlayer = GetNode<AnimationPlayer>(PlayerAnimationPlayerPath);
		_textureRect = GetNode<TextureRect>(TextureRectPath);
		_textureRect.Visible = false;
		
	}

	private void OnFirstRoomEntered(Node2D collider, ModuleTexts.ModuleVariant id)
	{
			_label.Text = ModuleTexts.GetModuleTextFromId(id);
			_animationPlayer.Stop();
        	_animationPlayer.Play("showtext_2");
			_textureRect.Visible = true;
    }
	

	public override void _PhysicsProcess(double delta)
	{	
		Vector2 _velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			_velocity.X = direction.X * Speed;
			_playerAnimationPlayer.Play("move");
		}
		else
		{
			_velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			_playerAnimationPlayer.Play("idle");
		}

		Velocity = _velocity;
		MoveAndSlide();
	}

	private void GoBack()
	{
		GetTree().ChangeSceneToFile(ScenesPath.GetPathFromId(ScenesPath.NodePathVariants.MainMenu));
	}
}
