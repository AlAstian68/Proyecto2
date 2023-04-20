using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class guardar : MonoBehaviour
{
    private string path;
    private string fileInfo;
    public static XmlDocument xmlDoc;
    private TextAsset textXml;
    private List<data> datos;
    public static string fileName;

    struct data{
        public string nombre;
        public string scoreXml;
    }
    
    void Awake()
    {
        fileName = "data";
        datos = new List<data>();
    }

    void Start(){
        LoadXMLFromAssets();
        mostrar();
    }
    void Update()
    {
        //modificaXml("player One", scoreXml.puntaje.ToString());
    }

    private void LoadXMLFromAssets(){
        xmlDoc = new XmlDocument();
        if(System.IO.File.Exists(getPath())){
            xmlDoc.LoadXml(System.IO.File.ReadAllText(getPath()));
        }else{
            textXml = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
            xmlDoc.LoadXml(textXml.text);
        }
    }

    public static void mostrar(){
        XmlNode rootNode = xmlDoc.SelectSingleNode("data");
        XmlNode scoreXml = rootNode.SelectSingleNode("scoreXml");
        if(scoreXml.InnerText == ""){
            Debug.Log("no tiene score registrado");
        }else{
            Debug.Log(scoreXml.InnerText);
            score.puntaje = int.Parse(scoreXml.InnerText) ;
        }
    }

    //Add data to data.xml file
    public static void modificaXml(string nombre, string score){
        XmlNode rootNode = xmlDoc.SelectSingleNode("data");

        data tempData = new data();
        
        tempData.nombre = nombre;
        tempData.scoreXml = score;

        rootNode.SelectSingleNode("nombre").InnerText = tempData.nombre;
        rootNode.SelectSingleNode("scoreXml").InnerText = tempData.scoreXml;

        xmlDoc.Save(getPath()+".xml");
    }

    public static string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath + "/Resources/"+fileName;
        #elif UNITY_ANDROID
        return Application.persistentDataPath+fileName;
        #else
        return Application.dataPath + "/"+fileName;
        #endif
    }
}
