using Godot;

namespace Armistice.scripts.CharacterComponents;

public partial class AimComponent : Node
{
	[Export] public float TurnSpeed = 6.5f;
	/// If enabled, player will look at cursor only while right mouse button clicked
	[Export] public bool UseExperimentalAim = true;
	private CharacterBody2D _characterBody;
	private Node2D _node;
	
	public override void _Ready()
	{
		_characterBody = GetParent<CharacterBody2D>();
		_node = GetParent<Node2D>();
		
		if (_characterBody == null)
			GD.PrintErr("AimComponent: parent must be CharacterBody2D!");
	}
	
	public override void _Process(double delta)
	{
		if (_characterBody == null) return;
		
		if (UseExperimentalAim && !Input.IsActionPressed("aim_at_cursor")) return;
		
		var mousePos = _node.GetGlobalMousePosition();
		var difference = mousePos - _characterBody.Position;

		var direction = difference.Angle();

		_characterBody.Rotation = Mathf.LerpAngle(_characterBody.Rotation, direction, TurnSpeed * (float)delta);
	}
}