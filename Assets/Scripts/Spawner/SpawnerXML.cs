using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[RequireComponent(typeof(Spawner))]
public class SpawnerXML : MonoBehaviour {

    // Contains data for each object spawned
    public class SpawnerData
    {
        public Vector3 position;
        public Quaternion rotation;
    }
    [XmlRoot]
    public class XMLContainer
    {
        [XmlArray]
        public Spawner[] data;
    }

    public string fileName;
    private Spawner spawner;
    private string fullPath;

    // Create XMLContainer
    private XMLContainer xmlContainer;

    // Saves XMLContainer instance to a file as XML format
    void SaveToPath(string path)
    {
        // Create a serializer of type XMLContainer
        XmlSerializer serializer = new XmlSerializer(typeof(XMLContainer));
        // Open a file stream at path using Create file mode
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            // Serial stream to xmlContainer
            serializer.Serialize(stream, xmlContainer);
        }
    }

    // Loads XMLContainer from path(NOTE: only run if tha file definately exists)
    XMLContainer Load(string path)
    {
        // Create a serializer of type XMLContainer
        XmlSerializer serializer = new XmlSerializer(typeof(XMLContainer));
        // Open a file stream at path using Open file mode
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            // RETURN the deserialized stream as XML container
            return serializer.Deserialize(stream) as XMLContainer;
        }
    }

    public void Save()
    {
        // SET objects to spawner.objects
        // SET xmlContainer to new XMLContainer
        // SET xmlContainer.data to new SpawnerData[objects.Count]
        // FOR i = 0 to objects.Count
          // SET data to new SpawerData
          // SET item to object[i]
          // SET data's position to item's position
          // SET data's rotaition to items's rotation
          // SET xmlContainer.data[i] to data
       // CALL SaveToPath(fullPath)         
    }

    // Applies the saved data to the scene
    void Apply()
    {
        // SET data to xmlContainer.data
        // FOR i = 0 to data.Length
          // SET d to data[i]
          // CALL spawner.Spawn() and pass d.position, d.rotation
    }

	// Use this for initialization
	void Start () {
		// SET spawner to Spawner Component
        // SET fullPath to Application.dataPath + "/" + fileName + ".xml"
        // IF file exists at fullPath
          // SET xmlContainer to Load(fullPath)
          // CALL Apply()
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
