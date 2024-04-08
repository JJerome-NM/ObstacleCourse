using System.Collections;
using Level1;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	public float fallTime = 0.5f;

	private void Start()
	{
		Level1EventManager.OnPlayerSpawnedOnCheckPoint.AddListener((_, _) =>
		{
			gameObject.SetActive(true);
		});
	}


	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (collision.gameObject.tag == "Player")
			{
				StartCoroutine(Fall(fallTime));
			}
		}
	}

	IEnumerator Fall(float time)
	{
		yield return new WaitForSeconds(time);
		gameObject.SetActive(false);
	}
}
