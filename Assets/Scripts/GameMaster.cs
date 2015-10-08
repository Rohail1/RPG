using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public GameObject playerCharacter;
    public Camera mainCamera;
     private GameObject _pc;
    public GameObject gameSettingsPrefab; 
    private PlayerCharacter _pcScript;

    public float zOffset = -2.5f;
    public float yOffset = 2.5f;
    public float xRotOffset = 22.5f;

	// Use this for initialization
	void Start () {
        _pc = Instantiate(playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;
        _pc.name = "pc";
        _pcScript = _pc.GetComponent<PlayerCharacter>();
        mainCamera.transform.position = new Vector3(_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
        mainCamera.transform.Rotate(xRotOffset, 0, 0);
        LoadCharacter();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadCharacter()
    {
        GameObject gs = GameObject.Find("GameSettings");
        if (gs == null)
        {
            gs =Instantiate(gameSettingsPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            gs.name = "GameSettings";
        }
        GameSettings gsScript = gs.GetComponent<GameSettings>();
        gsScript.LoadCharacterData();
    }
}
