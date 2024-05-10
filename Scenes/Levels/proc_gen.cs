using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
public partial class proc_gen : Node2D
{ 
    [Export]
    protected NoiseTexture2D noiseHeightText;
    protected FastNoiseLite noise;
    private float[] noiseValArr;
    private TileMap tileMap;
    private int sourceId=0;
    private Vector2I tile1;
    private Vector2I tile2;
    private Vector2I tile3;
    protected Vector2I borderAtlas=new Vector2I(8,5);
    Random rand = new Random();
    int ground=0;
    int ground1=1;
    int ground2=2;
    int ground3=3;
    int ground4=4;
    PackedScene Border;
    private int width;
    private int height;
    private enemyManager enemyManager;

    public TileMap TileMapInstance
    {
        get { return tileMap; }
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }
    public Vector2I Tile1
    {
        get { return tile1; }
        set { tile1 = value; }
    }
    public Vector2I Tile2
    {
        get { return tile2; }
        set { tile2 = value; }
    }
    public Vector2I Tile3
    {
        get { return tile3; }
        set { tile3 = value; }
    }
    public override void _Ready()
    {
        PackedScene tileMapScene = ResourceLoader.Load<PackedScene>("res://Scenes/Map/tile_map.tscn");
        TileMap tileMapInstance = (TileMap)tileMapScene.Instantiate();
        tileMap = tileMapInstance;
        AddChild(tileMap);
        noise = new FastNoiseLite(); 
        noise.SetSeed((int)DateTime.Now.Ticks);
        noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        noise.SetFrequency((float)0.04);
        enemyManager=GetNode<enemyManager>("/root/EnemyManager");
        enemyManager.resetEnemyCount();
    }
    public void GenerateLevel(int width, int height,Vector2I tile1,Vector2I tile2,Vector2I tile3)
    {
        noiseValArr = new float[(width) * (height)];
        for (int X = 0; X < width; X++)
    {
        for (int Y = 0; Y < height; Y++)
        {
            if (X == 0 || X == width - 1 || Y == 0 || Y == height - 1)
            {
                tileMap.SetCell(ground3, new Vector2I(X, Y), 0, borderAtlas, 0);
            }
        }
    }
     
        for (int X = 1; X < width-1; X++)
        {
            for (int Y = 1; Y < height-1; Y++)
            {
                float noiseVal = noise.GetNoise(X, Y);
                noiseValArr[X + Y * width] = noiseVal;
                if(noiseVal >= 0.0){
                    tileMap.SetCell(ground,new Vector2I(X,Y),0,tile1,0);
                    if (rand.Next(3) == 0){
                    tileMap.SetCell(ground1, new Vector2I(X, Y), 0, tile2, 0);
                    }
                }
                 else if(noiseVal >= -0.5){
                    tileMap.SetCell(ground1,new Vector2I(X,Y),0,tile3,0);
                    if (rand.Next(3) == 0){
                    tileMap.SetCell(ground1, new Vector2I(X, Y), 0, tile1, 0);
                    }
                }
                else {
                    tileMap.SetCell(ground2,new Vector2I(X,Y),0,tile1,0);
                    if (rand.Next(9) == 0){
                    tileMap.SetCell(ground2, new Vector2I(X, Y), 0, tile3, 0);
                    } 
                }
            
            }
        }
        
    }
   
}