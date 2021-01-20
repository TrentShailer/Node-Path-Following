using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Path : MonoBehaviour
{
	public static Path instance;

	private void Awake()
	{
		instance = this;
	}

	public List<GameObject> path = new List<GameObject>();

	private void OnDrawGizmos()
	{
		for (int i = 0; i < path.Count; i++)
		{
			if (i != 0)
			{
				Gizmos.DrawLine(path[i - 1].transform.position, path[i].transform.position);
			}

		}

		Handles.Label(path[0].transform.position, "Start");
		Handles.Label(path[path.Count - 1].transform.position, "Finish");
	}
}

// Custom inspector
[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();

		Path pathScript = (Path)target;

		GUILayout.BeginHorizontal();



		if (GUILayout.Button("Add Node"))
		{
			GameObject node = new GameObject("Node");
			node.transform.position = pathScript.path[pathScript.path.Count - 1].transform.position;
			node.AddComponent<Node>();
			node.transform.SetParent(pathScript.transform);
			pathScript.path.Add(node);
		}

		if (pathScript.path.Count > 0)
		{
			if (GUILayout.Button("Remove Node"))
			{
				DestroyImmediate(pathScript.path[pathScript.path.Count - 1]);
				pathScript.path.RemoveAt(pathScript.path.Count - 1);
			}
		}

		GUILayout.EndHorizontal();
	}
}