using Mono.Data.SqliteClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreInsertManager : MonoBehaviour {

    private string connectionString, currentName;
    private string query;

    private List<string> names;

    private int id;

    public Text nameText;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        connectionString = "URI=File:" + Application.dataPath + "/Databases/database.sqlite";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onButtonPress()
    {
        checkForPlayer();
    }

    void checkForPlayer()
    {
        currentName = nameText.text;
        names = new List<string>();
        
        using (IDbConnection dbCon = new SqliteConnection(connectionString))
        {
            dbCon.Open();
            using (IDbCommand dbCmd = dbCon.CreateCommand())
            {
                query = "SELECT name FROM user;";
                dbCmd.CommandText = query;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(0));
                    }

                    reader.Close();
                }
            }
            dbCon.Close();
        }
        if (names.Contains(currentName))
        {
            id = names.IndexOf(currentName);
        }
        else
        {
            insertNewName();
        }
    }

    void insertNewName()
    {
        using (IDbConnection dbCon = new SqliteConnection(connectionString))
        {
            dbCon.Open();
            using (IDbCommand dbCmd = dbCon.CreateCommand())
            {
                query = "INSERT INTO user (id, username, hash) VALUES (" + names.Count + ", " + currentName + ", " + hashName() + ");";
                dbCmd.CommandText = query;
                dbCmd.ExecuteScalar();
            }
            dbCon.Close();
        }
    }

    string hashName()
    {
        using (MD5 hash = MD5.Create())
        {
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(currentName));
            StringBuilder sb = new StringBuilder();
            foreach (byte datapiece in data)
            {
                sb.Append(datapiece.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
