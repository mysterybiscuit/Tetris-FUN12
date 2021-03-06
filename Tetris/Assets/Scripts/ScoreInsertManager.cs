﻿using Mono.Data.SqliteClient;
using System;
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

    private int id = -1, scoreId;

    public Text nameText;
    public Text scoreText;
    public Text levelText;
    public Text movesText;

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
        SceneManager.LoadScene(2);
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
                query = "SELECT id FROM user WHERE name = \"" + currentName + "\";";
                dbCmd.CommandText = query;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0).ToString().Length > 0) //Check if value is not null
                        {
                            id = reader.GetInt32(0);
                        }
                    }

                    reader.Close();
                }
            }
            dbCon.Close();
        }
        if (names.Contains(currentName))
        {
            id = names.IndexOf(currentName);
            insertScore();
        }
        else
        {
            insertNewName();
            insertScore();
        }
    }

    void insertNewName()
    {
        using (IDbConnection dbCon = new SqliteConnection(connectionString))
        {
            dbCon.Open();
            using (IDbCommand dbCmd = dbCon.CreateCommand())
            {
                query = "INSERT INTO user (name, hash) VALUES (\"" + currentName + "\", \"" + hashName() + "\");";
                dbCmd.CommandText = query;
                dbCmd.ExecuteScalar();
            }
            dbCon.Close();
        }
        using (IDbConnection dbCon = new SqliteConnection(connectionString))
        {
            dbCon.Open();
            using (IDbCommand dbCmd = dbCon.CreateCommand())
            {
                query = "SELECT MAX(id) FROM user;";
                dbCmd.CommandText = query;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                dbCon.Close();
            }
        }
    }

    void insertScore()
    {
        using (IDbConnection dbCon = new SqliteConnection(connectionString))
        {

            dbCon.Open();
            using (IDbCommand dbCmd = dbCon.CreateCommand())
            {
                query = "SELECT MAX(id) FROM highscore;";
                dbCmd.CommandText = query;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scoreId = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }
            dbCon.Close();
        }
        using (IDbConnection dbCon = new SqliteConnection(connectionString))
        {
            dbCon.Open();
            using (IDbCommand dbCmd = dbCon.CreateCommand())
            {
                int score = Convert.ToInt32(scoreText.text);
                int level = Convert.ToInt32(levelText.text);
                int moves = Convert.ToInt32(movesText.text);
                double efficiency = score / moves;
                query = "INSERT INTO highscore (userid, score, level, moves, efficiency) VALUES (" +
                        id + ", " +
                        score + ", " +
                        level + ", " +
                        moves + ", " +
                        efficiency + ");";
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

    void checkForUser()
    {

    }
}
