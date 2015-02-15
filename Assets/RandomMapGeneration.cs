using UnityEngine;
using System.Collections;

public class RandomMapGeneration : MonoBehaviour {

    /*
    public GameObject ES1;
    public GameObject ESW1;
    public GameObject EW1;
    public GameObject Ex1;
    public GameObject NE1;
    public GameObject NES1;
    public GameObject NESW1;
    public GameObject NEW1;
    public GameObject NS1;
    public GameObject NSW1;
    public GameObject NW1;
    public GameObject Nx1;
    public GameObject SW1;
    public GameObject Sx1; 
    public GameObject Wx1;*/

    public enum wallPiece
    {ES, ESW, EW, Ex, NE,
    NES, NESW, NEW, NS, NSW,
    NW, Nx, SW, Sx, Wx, NONE}
    

    public GameObject prefab;
    public GameObject bottomWall;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    int rand;
    public int gridX = X;
    public int gridY = Y;
    public int spacing = 20;
    public System.Random random = new System.Random();
    public gridSelect randGrid = new gridSelect();

	public static int X = 5;
	public static int Y = 5;

    static gridSelect[,] gridArray1 = new gridSelect[5,5];


    public static GameObject ES = (GameObject)Resources.Load("ES Walls");
    public static GameObject ESW = (GameObject)Resources.Load("ESW Walls");
    public static GameObject EW = (GameObject)Resources.Load("EW Walls");
    public static GameObject Ex = (GameObject)Resources.Load("Ex Walls");
    public static GameObject NE = (GameObject)Resources.Load("NE Walls");
    public static GameObject NES = (GameObject)Resources.Load("NES Walls");
    public static GameObject NESW = (GameObject)Resources.Load("NESW Walls");
    public static GameObject NEW = (GameObject)Resources.Load("NEW Walls");
    public static GameObject NS = (GameObject)Resources.Load("NS Walls");
    public static GameObject NSW = (GameObject)Resources.Load("NSW Walls");
    public static GameObject NW = (GameObject)Resources.Load("NW Walls");
    public static GameObject Nx = (GameObject)Resources.Load("Nx Walls");
    public static GameObject SW = (GameObject)Resources.Load("SW Walls");
    public static GameObject Sx = (GameObject)Resources.Load("Sx Walls");
    public static GameObject Wx = (GameObject)Resources.Load("Wx Walls");

    public class gridSelect
    {
        private int Xpos; //X position in the grid, multiplied by 20 
        private int Ypos; //Y position in the grid, multiplied by 20

        private GameObject wall; //Holds the value of the wall piece
        private wallPiece piece;
        //Constructors

        public gridSelect() //Default Constructor
        {
            piece = wallPiece.NONE;
        }

        public gridSelect(int X, int Y, GameObject wall, wallPiece piece)//Constructor
        {
           this.Xpos = X;
           this.Ypos = Y;
           this.wall = wall;
           this.piece = piece;
        }
        
        //methods

        public bool hasN() //Checks if the piece has a North exit
        {
            if (piece == wallPiece.NE || piece == wallPiece.NES || piece == wallPiece.NESW
                || piece == wallPiece.NEW || piece == wallPiece.NS || piece == wallPiece.NSW
                || piece == wallPiece.NW || piece == wallPiece.Nx)
                return true;
            else
                return false;
        }

        public bool hasE() //Checks if the piece has an East exit
        {
            if (piece == wallPiece.EW || piece == wallPiece.NE || piece == wallPiece.ES ||
                piece == wallPiece.NEW || piece == wallPiece.NES || piece == wallPiece.ESW ||
                piece == wallPiece.NESW || piece == wallPiece.Ex)
                return true;
            else
                return false;
        }

        public bool hasS() //Checks if the piece has a South exit
        {
            if (piece == wallPiece.NS || piece == wallPiece.ES || piece == wallPiece.SW ||
                piece == wallPiece.NES || piece == wallPiece.ESW || piece == wallPiece.NSW ||
                piece == wallPiece.NESW || piece == wallPiece.Sx)
                return true;
            else
                return false;
        }

        public bool hasW() //Checks if the piece has a South exit
        {
            if (piece == wallPiece.EW || piece == wallPiece.NW || piece == wallPiece.SW ||
                piece == wallPiece.NEW || piece == wallPiece.ESW || piece == wallPiece.NSW ||
                piece == wallPiece.NESW || piece == wallPiece.Wx)
                return true;
            else
                return false;
        }

        public void copy(gridSelect destcopy)
        {
            destcopy.setPiece(this.piece);
            destcopy.setWall(this.wall);
            destcopy.setXpos(this.Xpos);
            destcopy.setYpos(this.Ypos);
        }

        public bool viable(gridSelect [,] gridArray)
        {
			try{
            if(this.hasN() && !gridArray[this.Xpos,this.Ypos+1].hasS())
                return false;
            
            else if(this.hasS() && !gridArray[this.Xpos,this.Ypos-1].hasN())
                return false;
            

            else if(this.hasE() && !gridArray[this.Xpos+1,this.Ypos].hasW())
                return false;


            else if(this.hasW() && !gridArray[this.Xpos-1,this.Ypos].hasE())
                return false;
            
            else
                return true;
			}
			catch(System.IndexOutOfRangeException)
			{
					return false;
			}
        }

		public GameObject rescuriveCheckViable(gridSelect[,] gridArray)
        {
            System.Random random = new System.Random();
            int rand;
            rand = random.Next(1, 16);
			do {
				switch (rand) {
				case 1:
					this.piece = wallPiece.ES;
					this.wall = ES;
					break;
				case 2:
					this.piece = wallPiece.ESW;
					this.wall = ESW;
					break;
				case 3:
					this.piece = wallPiece.EW;
					this.wall = EW;
					break;
				case 4:
					this.piece = wallPiece.Ex;
					this.wall = Ex;
					break;
				case 5:
					this.piece = wallPiece.NE;
					this.wall = NE;
					break;
				case 6:
					this.piece = wallPiece.NES;
					this.wall = NES;
					break;
				case 7:
					this.piece = wallPiece.NESW;
					this.wall = NESW;
					break;
				case 8:
					this.piece = wallPiece.NEW;
					this.wall = NEW;
					break;
				case 9:
					this.piece = wallPiece.NS;
					this.wall = NEW;
					break;
				case 10:
					this.piece = wallPiece.NSW;
					this.wall = NSW;
					break;
				case 11:
					this.piece = wallPiece.NW;
					this.wall = NW;
					break;
				case 12:
					this.piece = wallPiece.Nx;
					this.wall = Nx;
					break;
				case 13:
					this.piece = wallPiece.SW;
					this.wall = SW;
					break;
				case 14:
					this.piece = wallPiece.Sx;
					this.wall = Sx;
					break;
				case 15:
					this.piece = wallPiece.Wx;
					this.wall = Wx;
					break;
				}
			} while(this.viable(gridArray) == false);

			return this.wall;
        }
        
        //Getters and Setters

        public int getXpos()
        {
            return this.Xpos;
        }
        public void setXpos(int xpos)
        {
            this.Xpos = xpos;
        }

        public int getYpos()
        {
            return this.Ypos;
        }
        public void setYpos(int ypos)
        {
            this.Ypos = ypos;
        }
        
        public GameObject getWall()
        {
            return this.wall;
        }
        public void setWall(GameObject wall)
        {
            this.wall = wall;
        }

        public wallPiece getPiece()
        {
            return this.piece;
        }
        public void setPiece(wallPiece piece)
        {
            this.piece = piece;
        }



    }


	// Use this for initialization
    void Start(){
		/*for (int y = 0; y < gridY; y++) 
		{
			for (int x = 0; x < gridX; x++) 
			{
				gridArray1[x,y]= new gridSelect();
				gridArray1[x,y].setPiece(wallPiece.NONE);
			}
		}


        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                randGrid.setXpos(x);
                randGrid.setYpos(y);
                prefab = randGrid.rescuriveCheckViable(gridArray1);
                Vector3 pos = new Vector3(x, 0, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
                randGrid.copy(gridArray1[x, y]);
            }
        }*/


        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0 ; x < gridX; x++)
            {
               rand = random.Next(1,16);
               
                switch(rand)
                {
                    case 1:
                        prefab = ES;
                        break;
                    case 2:
                        prefab = ESW;
                        break;
                    case 3:
                        prefab = EW;
                        break;
                    case 4:
                        prefab = Ex;
                        break;
                    case 5:
                        prefab = NE;
                        break;
                    case 6:
                        prefab = NES;
                        break;
                    case 7:
                        prefab = NESW;
                        break;
                    case 8:
                        prefab = NEW;
                        break;
                    case 9:
                        prefab = NS;
                        break;
                    case 10:
                        prefab = NSW;
                        break;
                    case 11:
                        prefab = NW;
                        break;
                    case 12:
                        prefab = Nx;
                        break;
                    case 13:
                        prefab = SW;
                        break;
                    case 14:
                        prefab = Sx;
                        break;
                    case 15:
                        prefab = Wx;
                        break;
                }

                Vector3 pos = new Vector3(x, 0, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
            }

        }
        for(int x = 0; x <gridX; x++) //bottom wall
        {
            Vector3 pos = new Vector3(x * spacing, 5/2, -10);
            Instantiate(bottomWall, pos, Quaternion.identity);
        }
        for (int x = 0; x < gridX; x++)//top wall
        {
            Vector3 pos = new Vector3(x * spacing, 5 / 2, gridY * spacing -10);
            Instantiate(topWall, pos, Quaternion.identity);
        }
        for (int y = 0; y < gridY; y++) //left wall
        {
            Vector3 pos = new Vector3(-10, 5 / 2, y * spacing);
            Instantiate(leftWall, pos, Quaternion.identity);
        }
        for (int y = 0; y < gridY; y++) //right wall
        {
            Vector3 pos = new Vector3(gridX * spacing -10 , 5 / 2, y * spacing);
            Instantiate(rightWall, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
