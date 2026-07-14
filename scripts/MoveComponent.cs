using Godot;

namespace Armistice.scripts;

public partial class MoveComponent : Node
{
	[Export] public float Speed = 300f;
	private CharacterBody2D _characterBody;

	public override void _Ready()
	{
		
		_characterBody = GetParent<CharacterBody2D>();
		
		if (_characterBody == null)
			GD.PrintErr("MoveComponent: parent must be CharacterBody2D!");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_characterBody == null) return;
		
		var direction = Vector2.Zero;

		if (Input.IsActionPressed("move_right")) direction.X += 1;
		if (Input.IsActionPressed("move_left"))  direction.X -= 1;
		if (Input.IsActionPressed("move_down"))  direction.Y += 1;
		if (Input.IsActionPressed("move_up"))    direction.Y -= 1;
		
		direction = direction.Normalized();
		
		_characterBody.Velocity = direction * Speed;
		_characterBody.MoveAndSlide();
	}
}
