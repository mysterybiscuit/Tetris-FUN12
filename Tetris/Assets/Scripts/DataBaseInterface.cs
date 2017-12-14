using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;


public class DataBaseInterface : MonoBehaviour {

    private string connectionString;

    public Text text;

    void Start()
    {
        connectionString = "URI=File:" + Application.dataPath + "/Databases/database.sqlite";
        getScores();
    }

    void getScores()
    {
        List<string> names = new List<string>();
        string query;
        using (IDbConnection dbCon = new SqliteConnection(connectionString)) //Sets up the DB connection
        {
            dbCon.Open(); //Opens the DB connection
            using (IDbCommand dbCmd = dbCon.CreateCommand()) //Sets up the DB command
            {
                query = "SELECT user.name, highscore.efficiency FROM user INNER JOIN highscore ON user.id = highscore.userid ORDER BY highscore.efficiency DESC;";
                dbCmd.CommandText = query;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        text.text += reader.GetString(0) + ": " + reader.GetDouble(1) + "\n";
                    }

                    reader.Close();
                }

                //query = "SELECT userid, efficiency FROM highscore ORDER BY efficiency DESC";
                //dbCmd.CommandText = query; //Stores the command

                //using (IDataReader reader = dbCmd.ExecuteReader()) //Sets up the reader for the data.
                //{
                //    int i = 0;
                //    while (reader.Read()) //If there is data to read
                //    {
                //        text.text += names[i].Substring(1) /*reader.GetInt32(0)*/ + ": " + reader.GetDouble(1) + "\n";
                //        i++;
                //    }
                //    reader.Close(); //Closes the reader
                //}
            }
            dbCon.Close(); //Closes the database connection
        }
    }

    void insertScore(string name, int moves, int score, float efficiency)
    {

    }

    //string connectionString;
    //// Use this for initialization
    //void Start () {
    //    connectionString = "Server=studmysql01.fhict.local;Uid=dbi386588;Database=dbi386588;Pwd=Aic1W4IUiK;";

    //    MySqlConnection mysqlconnection = new MySqlConnection(connectionString);
    //    try
    //    {
    //        Debug.Log("Connecting to Database.");
    //        mysqlconnection.Open();
    //        Debug.Log("Connection opened.");
    //    }
    //    catch (Exception e)
    //    {
    //        Debug.Log("Couldn't connect to database: " + e);
    //    }
    //    //SqlConnection connection = new SqlConnection(connectionString);
    //    //try
    //    //{
    //    //    Debug.Log("Connecting to Database.");
    //    //    connection.Open();
    //    //    Debug.Log("Connection opened");
    //    //}
    //    //catch (Exception e)
    //    //{
    //    //    Debug.Log("Couldn't connect to database: " + e);
    //    //}
    //    //connection.Close();
    //}
	
	// Update is called once per frame
	void Update () {
		
	}
}
