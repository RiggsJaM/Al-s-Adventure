using Godot;
using System;

public partial class Movement : CharacterBody2D
{
    private AnimatedSprite2D _animatedSprite;
    
    [Export] public int Speed { get; set; } = 400;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }
    
    public void GetInput()
    {
        // Get direction you are moving
        Vector2 inputDirection = Input.GetVector("Left", "Right", "Up", "Down");
        
        var velocity = Vector2.Zero; // The player's movement vector.

        // Add to velocity based on direction
        if (Input.IsActionPressed("Right"))
        {
            velocity.X += 1;
        }
        if (Input.IsActionPressed("Left"))
        {
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("Down"))
        {
            velocity.Y += 1;
        }
        if (Input.IsActionPressed("Up"))
        {
            velocity.Y -= 1;
        }
        
        // Play the walking or idle animation
        if (velocity.Length() > 0)
        {
            _animatedSprite.Play("Walk");
        }
        else
        {
            _animatedSprite.Play("Idle");
        }
        
        // Flip the direction the character is facing
        if (velocity.X < 0)
        {
            _animatedSprite.FlipH = true;
        }
        else if (velocity.X > 0)
        {
            _animatedSprite.FlipH = false;
        }
        
        // Move the character
        Velocity = inputDirection * Speed;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }
}
