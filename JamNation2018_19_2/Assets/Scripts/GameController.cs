using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private List<ITick> tickedObjects;
    public float TickTime = 0.5f;
	private bool tickSwitch = false;

	public float sequenceTimer = 9999f;
	private int sequenceTrigger = 0;

    public static GameController instance;

    private float nextTick = 0;

	private List<BlobCharacter> activeBlob;
	private List<BlobCharacter> blobToAdd;
	private List<BlobCharacter> blobToRemove;

	private Player player;

	public Transform cameraTracker;

	public List<GameSequence> sequences;
	private int sequenceIterator = 0;



	public CanvasGroup whiteScreen;
	private bool endGameInProgress = false;

    private void Awake()
	{
        if (instance != null)
		{
            Destroy(gameObject);
            return;
        }
        instance = this;
		tickedObjects = new List<ITick>();
		activeBlob = new List<BlobCharacter>();
		blobToAdd = new List<BlobCharacter>();
		blobToRemove = new List<BlobCharacter>();

		whiteScreen.alpha = 1f;
    }

	private void Start()
	{
		player = ReInput.players.GetPlayer("Player");
	}

	public void AddTickObject(ITick toAdd)
	{
		tickedObjects.Add(toAdd);
    }

	public void AddBlob(BlobCharacter toAdd)
	{
		blobToAdd.Add(toAdd);
	}

	public void RemoveBlob(BlobCharacter toRemove)
	{
		blobToRemove.Add(toRemove);
	}
	
	public void AddToSequenceTrigger(int amount)
	{
		sequenceTrigger += amount;
		if (sequenceTrigger >= sequences[sequenceIterator].triggerLimit)
		{
			AdvanceSequence();
		}
	}

	[ContextMenu("Advance Sequence")]
	public void AdvanceSequence()
	{
		sequenceIterator++;
		if (sequenceIterator >= sequences.Count - 1)
		{
			EndGame();
		}
		else
		{
			sequenceTrigger = 0;
			sequenceTimer = sequences[sequenceIterator].timeLimit;
			sequences[sequenceIterator].TriggerSpawn();
		}
	}

	[ContextMenu("End Game")]
	public void EndGame()
	{
		endGameInProgress = true;
	}


	private void Update ()
	{
        float dt = Time.deltaTime;

		if (player.GetButtonDown("UICancel"))
		{ EndGame(); }

		whiteScreen.alpha += endGameInProgress ? dt : -dt;

		if (endGameInProgress && whiteScreen.alpha >= 1f)
		{
			if (whiteScreen.alpha >= 1f)
			{
				SceneManager.LoadScene("MenuScene");
			}
		}
		else
		{
			sequenceTimer -= dt;
			if (sequenceTimer <= 0f)
			{
				AdvanceSequence();
			}
		}

        nextTick += dt;

        if (nextTick >= TickTime) {
			if (tickSwitch)
			{
				Debug.Log("Tick for blobs");
				if (!player.GetButton("UISubmit"))
				{
					foreach (BlobCharacter blob in activeBlob)
					{
						blob.AdvanceOnPath();
					}
				}
			}
			else
			{
				Debug.Log("Tick for level");
				foreach (BlobCharacter blob in activeBlob)
				{
					blob.TestCurrentPoint();
				}

				foreach (ITick br in tickedObjects)
				{ br.Tick(); }

				foreach (BlobCharacter addBlob in blobToAdd)
				{ activeBlob.Add(addBlob); }
				foreach (BlobCharacter removeBlob in blobToRemove)
				{ activeBlob.Remove(removeBlob); }
				blobToAdd.Clear();
				blobToRemove.Clear();
			}
            nextTick = 0;
			tickSwitch = !tickSwitch;
        }

		if (activeBlob.Count > 0)
		{
			Vector3 newCameraPosition = Vector3.zero;
			foreach (BlobCharacter blob in activeBlob)
			{
				newCameraPosition += blob.transform.position;
			}
			newCameraPosition /= activeBlob.Count;
			cameraTracker.position = newCameraPosition;
		}

		
	}
}

[System.Serializable]
public class GameSequence
{
	public float timeLimit = 9999f;

	public int triggerLimit = 1;

	public List<PathPoint_Spawn> sequenceSpawns;

	public void TriggerSpawn()
	{
		foreach (PathPoint_Spawn sP in sequenceSpawns)
		{
			sP.SpawnBlob();
		}
	}
}