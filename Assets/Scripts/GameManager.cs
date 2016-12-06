using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private CanvasGroup m_victoryScreenCanvasGroup;
	private CanvasGroup m_defeatScreenCanvasGroup;
	public bool playerHasKey = false;
	public bool IsGameRunning{ get; private set; }

    //
    void Awake()
    {
        G.Sys.gameManager = this;
    }

	// Use this for initialization
	void Start ()
	{
		m_victoryScreenCanvasGroup = this.transform.FindChild ("Canvas/VictoryScreen").GetComponent<CanvasGroup> ();
		m_defeatScreenCanvasGroup = this.transform.FindChild ("Canvas/DefeatScreen").GetComponent<CanvasGroup> ();

		IsGameRunning = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	public void OnDoorEvent (ImportantDoor.OpenDoorEvent openDoorEvent)
	{
		IsGameRunning = false;

		if (openDoorEvent == ImportantDoor.OpenDoorEvent.Defeat) {
			m_defeatScreenCanvasGroup.alpha = 1f;
		} else if (openDoorEvent == ImportantDoor.OpenDoorEvent.Victory) {
			m_victoryScreenCanvasGroup.alpha = 1f;
		}
	}
}
