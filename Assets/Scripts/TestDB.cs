using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;
using System;

public class TestDB : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _Text;
    void Start()
    {
        _Text = GetComponent<Text>();
        TestConnectDB();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private const string fileName = "test.db";
    private static string DBPath = Path.Combine(Application.streamingAssetsPath + "/DataBases/" + fileName);
    private void TestConnectDB()
    {
        var connection = new SqliteConnection("Data Source=" + DBPath);
        var command = new SqliteCommand(connection);
        connection.Open();
        command.CommandText = "SELECT Name FROM TestTable WHERE id = 1";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            _Text.text = reader.GetFieldValue<string>(0);
        }
        reader.Close();
        connection.Close();
        command.Dispose();
    }
}
