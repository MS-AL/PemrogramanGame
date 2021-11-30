using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour 
{
	public GameObject player;
	public float jarak;

	void Update () 
	{
		Vector3 posisi = new Vector3 (0, player.transform.localPosition.y + (player.transform.localScale.y * jarak), -10f);
		transform.localPosition = Vector3.Lerp(transform.localPosition, posisi, 0.1f);
    }
}