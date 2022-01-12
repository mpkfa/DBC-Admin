using System.Reflection;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CanDbcAdmin.BLL;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Data.Linq;

namespace CanDbcAdmin.DAL {

  public interface IDatabase {
    List<string> List();
    CanDbc Get(string filename);
    void Insert(CanDbc dbc);
    void Delete(string filename);
    void Clear();
  }

  public class JsonDatabase : IDatabase {
    private readonly string filename;

    private Dictionary<string, CanDbc> items;

    public JsonDatabase(string filename) {
      this.filename = filename;

      items = File.Exists(this.filename)
        ? JsonSerializer
            .Deserialize<List<CanDbc>>(File.ReadAllText(this.filename))
            .ToDictionary(dbc => dbc.Filename)
        : new Dictionary<string, CanDbc>();

      Console.WriteLine(items.Count);
    }

    private void Save() => File.WriteAllText(filename, JsonSerializer.Serialize(items.Values));

    public List<string> List() => items.Keys.ToList();

    public CanDbc Get(string filename) => items[filename];

    public void Delete(string filename) {
      if (!items.ContainsKey(filename)) throw new KeyNotFoundException(filename);
      items.Remove(filename);
      Save();
    }

    public void Insert(CanDbc dbc) {
      if (items.ContainsKey(dbc.Filename)) throw new DuplicateKeyException(dbc.Filename);
      items.Add(dbc.Filename, dbc);
      Save();
    }

    public void Clear() {
      items.Clear();
      Save();
    }
  }

  class SqliteDatabase : IDatabase {
    public static void Init() {
      var connString = $"URI=file:{Program.RunPath}/candbc.db";

      using (var con = new SqliteConnection(connString)) {
        con.Open();

        using (var cmd = new SqliteCommand()) {
          cmd.CommandText = "...";
          cmd.ExecuteNonQuery();
        }
      }
    }

    public void Clear() => throw new NotImplementedException();

    public void Delete(string filename) => throw new NotImplementedException();

    public CanDbc Get(string filename) => throw new NotImplementedException();

    public void Insert(CanDbc dbc) => throw new NotImplementedException();

    public List<string> List() => throw new NotImplementedException();
  }
}
