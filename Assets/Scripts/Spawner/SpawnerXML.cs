﻿using System.Collections;
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
        public SpawnerData[] data;
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
        var objects = spawner.objects;
        // SET xmlContainer to new XMLContainer
        xmlContainer = new XMLContainer();
        // SET xmlContainer.data to new SpawnerData[objects.Count]
        xmlContainer.data = new SpawnerData[objects.Count];
        // FOR i = 0 to objects.Count
        for(int i = 0; i < objects.Count; i++)
           {
            // SET data to new SpawerData
            var data = new SpawnerData();
            // SET item to objects[i]
            var item = objects[i];
            // SET data's position to item's position
            data.position = item.transform.position;
            // SET data's rotation to items's rotation
            data.rotation = item.transform.rotation;
            // SET xmlContainer.data[i] to data
            xmlContainer.data[i] = data;
           }
       // CALL SaveToPath(fullPath)
      SaveToPath(fullPath);
    }
    
    // Applies the saved data to the scene
    void Apply()
    {
        // SET data to xmlContainer.data
        var data = xmlContainer.data;
        // FOR i = 0 to data.Length
        for (int i = 0; i < data.Length; i++)
        {
            // SET d to data[i]
            var d = data[i];
            // CALL spawner.Spawn() and pass d.position, d.rotation
            spawner.Spawn(d.position, d.rotation);
        }
    }
    // Use this for initialization
    void Start()
    {
        // SET spawner to Spawner Component
        var spawner = GetComponent<Spawner>();
        // SET fullPath to Application.dataPath + "/" + fileName + ".xml"
        fullPath = Application.dataPath + "/" + fileName + ".xml";
        // IF file exists at fullPath
        if (File.Exists(fullPath))
        {
            // SET xmlContainer to Load(fullPath)
            xmlContainer = Load(fullPath);
            // CALL Apply()
            Apply();
        }
    }
}
