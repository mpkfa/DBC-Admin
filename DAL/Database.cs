using System.Reflection;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CanDbcAdmin.BLL;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace CanDbcAdmin.DAL
{
    interface IDatabase
    {
        List<Dbc> GetAll();
        void Delete(string filename);
        void Insert(Dbc dbc);
    }

    public enum DatabaseType { Json, Sqlite }

    class JsonDatabase : IDatabase
    {
        private readonly string jsonPath = $"{Program.StoragePath}/database.json";
        
        private Dictionary<String, Dbc> dbcList = new Dictionary<String, Dbc>();

        private void Save() => File.WriteAllText(jsonPath, JsonSerializer.Serialize(dbcList.Values.ToList()));

        private void Load()
        {
            if (File.Exists(jsonPath))
                dbcList = JsonSerializer
                    .Deserialize<List<Dbc>>(File.ReadAllText(jsonPath))
                    .ToDictionary(dbc => dbc.Filename);
            else
                dbcList = new Dictionary<String,Dbc>();
        }

        public void Delete(string filename)
        {
            dbcList.Remove(filename);
            Save();
        }

        public void Insert(Dbc dbc) {
            dbcList.Add(dbc.Filename, dbc);
            Save();
        }

        public List<Dbc> GetAll()
        {
            Load();
            return dbcList.Values.ToList();
        }
    }

    class SqliteDatabase : IDatabase
    {
        public static void Init()
        {
            var connString = $"URI=file:{Program.RunPath}/candbc.db";

            using (var con = new SqliteConnection(connString))
                {
                    con.Open();

                    using (var cmd = new SqliteCommand())
                    {
                        cmd.CommandText = "...";
                        cmd.ExecuteNonQuery();
                    }
            }
        }

        public void Delete(string filename)
        {
            throw new NotImplementedException();
        }

        public List<Dbc> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Dbc dbc)
        {
            throw new NotImplementedException();
        }
    }
}
