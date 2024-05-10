using Godot;
using System;

public partial class enemyManager: Node
{
    public int numEntities=0;

    public void enemySpawned(){
        numEntities++;

    }
    public void enemyKilled(){
        numEntities--;

    }

    public int getNumEnemies(){
        return numEntities;
    }

     public void resetEnemyCount(){
        numEntities = 0;
    }

}