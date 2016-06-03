using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;
using UnityEngine.UI;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

public class Randomr : MonoBehaviour {

    public InputField Moves;
    public InputField Pokemon;
    public InputField Items;
    public Toggle debug;
    public int[] RandomedArrayNumber = new int[600];
    public int FileCounter = 0;


    public void RandomNize () {
        

        int range = 0;
        int range2 = 150;
        bool numberjuan = true;
        int randomman = 0;

        
        string[] guids2;
       
        String[] info = Directory.GetFiles(Moves.text, "*.xml");
        guids2 = new String[info.Length];
        //Debug.Log(info.Length);
        for (int i = 0; i < info.Length; i++)
        {
            //Debug.Log(info[i].ToString());
            guids2[i] = info[i].ToString();

        }


        foreach (string guid in guids2)
        {
           // Debug.Log(guid);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(guid);
           // Debug.Log(xmldoc.InnerText);

            XmlNode root = xmldoc.DocumentElement;
            XmlNodeList nodeList; // who knows what this does
            nodeList = root.SelectNodes("Data");

            for (int i = 0; i < nodeList.Count; i++)
            {
                var node = nodeList[i];


               // Debug.Log(node.SelectSingleNode("BasePP").InnerText);
              //  Debug.Log(node.SelectSingleNode("Accuracy").InnerText);
               // Debug.Log(node.SelectSingleNode("BasePower").InnerText);



                if (numberjuan == true)
                {
                    randomman = UnityEngine.Random.Range(range, range2);
                    node.SelectSingleNode("BasePP").InnerText = "0";
                    numberjuan = false;
                }
                else
                {
                    numberjuan = true;
                    node.SelectSingleNode("BasePP").InnerText = "0";

                }


                
                xmldoc.Save(guid);
            }


        }


        print("end of random1");
    }

    public void RandomNizePok()
    {
        int AttackRange = 0;
        int range2 = 150;
        bool whichElementInXML = true;// true = first element it finds it will edit, false means next element it finds it will edit.
        int RNFR = 0;// Random Number From Ranges
        int[] RandomFileHelper;

        string[] FileNameOrdered; // XML file names ordered
        string[] FileNameRandomed; // XML file names in randomnized order determined by randomArrayNumber
        string RetreivedFile1;
        string RetreivedFile2;

        String[] files1 = Directory.GetFiles(Pokemon.text, "*.xml");
        String[] files2 = Directory.GetFiles(Pokemon.text+"c", "*.xml");
        FileNameOrdered = new String[files1.Length];
        FileNameRandomed = new String[files1.Length];
        RandomFileHelper = new int[files1.Length];
       // Debug.Log(files1.Length);
        for (int i = 0; i < files1.Length; i++)
        {
           // Debug.Log(files1[i].ToString());
            FileNameOrdered[i] = files1[i].ToString();
            FileNameRandomed[i] = files2[i].ToString();
            RandomFileHelper[i] = i;

        }


        foreach (string File in FileNameOrdered)
        {
            
            XmlDocument xmldoc = new XmlDocument();
            XmlDocument OldPok = new XmlDocument();
            xmldoc.Load(File);
            OldPok.Load(FileNameRandomed[RandomedArrayNumber[RandomFileHelper[FileCounter]]]);

            RetreivedFile1 = FileNameRandomed[RandomedArrayNumber[RandomFileHelper[FileCounter]]];
            RetreivedFile2 = FileNameOrdered[RandomedArrayNumber[RandomFileHelper[FileCounter]]];
            //guidmen2 is bulb

            if (RandomedArrayNumber[FileCounter] != 0)
            {
                System.IO.File.Delete(FileNameRandomed[RandomedArrayNumber[RandomFileHelper[FileCounter]]]);
                System.IO.File.Copy(FileNameOrdered[RandomFileHelper[FileCounter]], RetreivedFile1);//copy shinx.xml data to riolu.xml data to pokc from pok, Also floatzel is guid and bulb is RetreivedFile1
                System.IO.File.Delete(FileNameRandomed[RandomFileHelper[FileCounter]]);   
                System.IO.File.Copy(RetreivedFile2, FileNameRandomed[RandomFileHelper[FileCounter]]);

                RandomFileHelper[FileCounter] = 0;
                RandomedArrayNumber[FileCounter] = 0;

            }
            else {
           //     Debug.Log("itwas");
            }
            // Debug.Log(File);//=guids2[FileCounter]
            // Debug.Log(FileNameOrdered[FileCounter]);
            // Debug.Log(RetreivedFile1);//=RetreivedFile2 but RetreivedFile2 is pok not pokc
            // Debug.Log(RetreivedFile2);
            //texts[FileCounter] = 1;

            FileCounter++;
            

            XmlNode root = xmldoc.DocumentElement;
            XmlNodeList nodeList; // who knows what this does
            XmlNode Broot = OldPok.DocumentElement;
            XmlNodeList BnodeList; // who knows what this does
            nodeList = root.SelectNodes("GenderedEntity");
            BnodeList = Broot.SelectNodes("GenderedEntity");

            for (int i = 0; i < nodeList.Count; i++)
            {
                var node = nodeList[i];
                var Bnode = BnodeList[i];

                if (whichElementInXML == true)
                {
                    RNFR = UnityEngine.Random.Range(AttackRange, range2);

                    whichElementInXML = false;
                }
                else
                {
                    whichElementInXML = true;
                }
                xmldoc.Save(File);
            }
        }
        print("end of randomnize pok");
    }
 
    public void reshuffle()
    {
        for (int i = 0; i < 534; i++)
        {
            RandomedArrayNumber[i] = 1 + i;
        }
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        Shuffle<int>(RandomedArrayNumber);

        //Debug.Log(RandomedArrayNumber[50]);
        for (int t = 0; t < RandomedArrayNumber.Length; t++)
        {
         //   Debug.Log(RandomedArrayNumber[t]);
        }
        print("shuffled");

        


    }

    public static void Shuffle<T>(T[] Array)
    {
        int count = Array.Length, i, randIndex;
        for (i = count - 1; i > 0; --i)
        {
            randIndex = UnityEngine.Random.Range(0, i);  // note: shifts random elements to the foward going end so the order is determined in opposite direction, the elements choosen first are the last ones in the resulting list
            T temp = Array[i];
            Array[i] = Array[randIndex];
            Array[randIndex] = temp;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void RandomItems()
    {
        String[] files1 = Directory.GetFiles(Pokemon.text, "*.xml");
        Stack stack = new Stack();
       // Debug.Log(files1.Length);
        for (int i = 0; i < files1.Length; i++)
        {
            stack.Push(files1[i].ToString());

        }
        for (int i = 0; i < files1.Length; i++)
        {
            stack.Pop();

        }
        print("end");

    }

    public void Functions()
    {
        if (debug.isOn)
        {
            
            RandomNize();
        }
        RandomItems();

    }

}
