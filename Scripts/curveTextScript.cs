using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class curveTextScript : MonoBehaviour
{
    public TMP_Text textmesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    Mesh mesh;
    Vector3[] vertices;
    // Update is called once per frame
    void Update()
    {
        //per character:

        textmesh.ForceMeshUpdate();
        mesh = textmesh.mesh;
        vertices = mesh.vertices;
        for (int i = 0; i < textmesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textmesh.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int index = c.vertexIndex;

            Vector3 offset = Wobble(Time.time + i);
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }

        mesh.vertices = vertices;
        textmesh.canvasRenderer.SetMesh(mesh);

        /*
        textmesh.ForceMeshUpdate();
        mesh = textmesh.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);
            vertices[i] = vertices[i] + offset;
        }

        mesh.vertices = vertices;
        textmesh.canvasRenderer.SetMesh(mesh);*/
    }

    Vector2 Wobble (float time)
    {
        return new Vector2(Mathf.Sin(time * 33.3f), Mathf.Cos(time * 22.8f));
    }
}
