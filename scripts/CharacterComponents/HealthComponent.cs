using Godot;

namespace Armistice.scripts.CharacterComponents;

public partial class HealthComponent : Node
{
    [Export] public float MaxHealth;
    private float _health;

    public override void _Ready()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f) QueueFree();
    }
}