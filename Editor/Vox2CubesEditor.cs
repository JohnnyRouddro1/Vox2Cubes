using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using VoxReader;
using VoxReader.Interfaces;

public class Vox2CubesEditor : EditorWindow
{
	private GameObject customVoxelObject;

	private static IVoxFile GetVoxFileFromSelection()
    {
		var SelectedAsset = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
		if (SelectedAsset.Length == 0)
		{
			EditorUtility.DisplayDialog("No Object Selected", "Please select any .vox file to create to GameObject", "Ok");
			return null;
		}

		var path = AssetDatabase.GetAssetPath(SelectedAsset[0]);
		IVoxFile voxFile = null;

		if (Path.GetExtension(path) != ".vox")
		{
			EditorUtility.DisplayDialog("Invalid File", "The end of the path wasn't \".vox\"", "Ok");
			return null;
		}

		if (path.Remove(0, path.LastIndexOf('.')) == ".vox")
		{
			voxFile =  VoxReader.VoxReader.Read(path);
		}

		return voxFile;
	}


    [MenuItem("Tools/Vox 2 Cubes")]
	public static void ShowWindow()
	{
		Vox2CubesEditor.CreateInstance<Vox2CubesEditor>().Show();
	}

    public void OnGUI()
	{
		GUILayout.Space(15);
		GUILayout.Label("Vox 2 Cubes", EditorStyles.boldLabel);
		GUILayout.Space(15);
		GUILayout.Label("Select none to create voxels out of default cube meshes", EditorStyles.helpBox);
		customVoxelObject = (GameObject)EditorGUILayout.ObjectField("Custom Voxel Object", customVoxelObject, typeof(GameObject), true);
		GUILayout.Space(15);
        if (GUILayout.Button("Create Cubes from selected .vox file"))
		{
			CreateVoxelCubesFromSelection();
        }
	}


	private void CreateVoxelCubesFromSelection()
    {
		IVoxFile voxFile = GetVoxFileFromSelection();

        if (voxFile == null)
        {
			return;
        }

		Dictionary<VoxColor, Material> colorList = new Dictionary<VoxColor, Material>();

		Shader shader = Shader.Find("Universal Render Pipeline/Simple Lit");
		Material mat;

		GameObject cubeGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Mesh mesh = cubeGameObject.GetComponent<MeshFilter>().sharedMesh;
		GameObject.DestroyImmediate(cubeGameObject);

		foreach (var model in voxFile.Models)
		{
			var voxelModel = new GameObject("Voxel Model");

			foreach (var voxel in model.Voxels)
			{
				GameObject cube;
				MeshFilter cubeMesh;
				MeshRenderer cubeMeshRenderer;
				Texture tex = null;

				if (customVoxelObject != null)
                {
					cube = Instantiate(customVoxelObject);
					cubeMesh = cube.GetComponent<MeshFilter>();
					cubeMeshRenderer = cube.GetComponent<MeshRenderer>();
					tex = cubeMeshRenderer.sharedMaterial.mainTexture;
				}
                else
                {
					cube = new GameObject();
					cubeMesh = cube.AddComponent<MeshFilter>();
					cubeMesh.mesh = mesh;
					cubeMeshRenderer = cube.AddComponent<MeshRenderer>();
                }

                if (cubeMesh == null)
                {
					EditorUtility.DisplayDialog("Mesh Filter Not Found", "Need Mesh Filter on custom voxel object!", "Ok");
					GameObject.DestroyImmediate(voxelModel);
					return;
				}

				if (cubeMeshRenderer == null)
				{
					EditorUtility.DisplayDialog("Mesh Renderer Not Found", "Need Mesh Renderer on custom voxel object!", "Ok");
					GameObject.DestroyImmediate(voxelModel);
					return;
				}


				cube.name = "voxel";
				cube.transform.SetParent(voxelModel.transform);
				cube.transform.position = new Vector3(voxel.Position.X, voxel.Position.Z, voxel.Position.Y);


				if (!colorList.ContainsKey(voxel.Color))
				{
					mat = new Material(shader);
					mat.color = new Color(voxel.Color.R, voxel.Color.G, voxel.Color.B, voxel.Color.A) / 255f;
					colorList.Add(voxel.Color, mat);
					mat.mainTexture = tex;
				}
				else
				{
					mat = colorList[voxel.Color];
				}

				cubeMeshRenderer.sharedMaterial = mat;
			}
		}
	}
}
