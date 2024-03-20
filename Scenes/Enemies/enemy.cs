using System;
using System.Runtime.CompilerServices;
using Godot;

public partial class enemy : CharacterBody2D
{
   
    private int speed = 100;
    private Node player = null;
    private bool playerChase = true;

    private Vector2 velocity = Vector2.Zero;

    private AnimatedSprite2D enemySprite;

    

    public enemy()
    {
        
    }

    public override void _Ready()
    {
        enemySprite=GetNode<Godot.AnimatedSprite2D>("enemySprite");
         enemySprite.Play("idle");
       
        

    }
    public override void _Process(double delta)
	{
        
	}

    

    
   
       public override void _PhysicsProcess(double delta){
    
        
             if (playerChase && player != null) {
        
        
            
            if (player is Area2D kinematicPlayer)
            {
              

                 Vector2 direction = (kinematicPlayer.GlobalPosition -GlobalPosition).Normalized();
                GlobalPosition += direction * speed * (float)delta;
               
            
                
            }
             
        }
    
    

    }

    private void _on_detection_area_area_entered(Node body){
        


        player=body;
        playerChase=true;
        enemySprite.Stop();
        
        

    }

    private void _on_detection_area_area_exited(Node body){
       

        player=null;
        playerChase=false;
        enemySprite.Play("idle");
        

    }

}
