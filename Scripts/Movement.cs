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
        Vector2 inputDirection = Input.GetVector("Left", "Right", "Up", "Down");
        
        var velocity = Vector2.Zero; // The player's movement vector.

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

        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
            animatedSprite2D.Play("Walk");
        }
        else
        {
            animatedSprite2D.Play("Idle");
        }
        
        
        if (velocity.X < 0)
        {
            animatedSprite2D.FlipH = true;
        }
        else if (velocity.X > 0)
        {
            animatedSprite2D.FlipH = false;
        }
        
        Velocity = inputDirection * Speed;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }
}
