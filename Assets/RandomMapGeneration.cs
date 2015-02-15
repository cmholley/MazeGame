using UnityEngine;
using System.Collections;

public class RandomMapGeneration : MonoBehaviour {

    
    public GameObject ES;
    public GameObject ESW;
    public GameObject EW;
    public GameObject Ex;
    public GameObject NE;
    public GameObject NES;
    public GameObject NESW;
    public GameObject NEW;
    public GameObject NS;
    public GameObject NSW;
    public GameObject NW;
    public GameObject Nx;
    public GameObject SW;
    public GameObject Sx; 
    public GameObject Wx;

   /* ES;
    ESW;
    EW;
    Ex;
    NE;
    NES;
    NESW;
    NEW;
    NS;
    NSW;
    NW;
    Nx;
    SW;
    Sx;
    Wx;
    */
    public GameObject prefab;
    public GameObject bottomWall;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    int rand;
    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 20f;
    public System.Random random = new System.Random();

	// Use this for initialization
    void Start(){
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0 ; x < gridX; x++)
            {
               rand = random.Next(1,16);
               
                switch(rand) //
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
            Vector3 pos = new Vector3(gridY * spacing - 10, 5 / 2, y * spacing);
            Instantiate(leftWall, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
