using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace CanDbcAdmin.BLL {

  public class Signal {
    public string Name { get; set; }
    public byte StartBit { get; set; }
    public byte Length { get; set; }
    public override string ToString() => $"Signal = {Name}, {StartBit}|{Length}";
  }

  public class Message {
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Signal> Signals { get; set; } = new List<Signal>();
    public override string ToString() => $"Message = {Id}, {Name}";
  }


  public class CanDbc {
    public string Filename { get; set; }
    public List<String> NetworkNodes { get; set; } = new List<String>();
    public List<Message> Messagess { get; set; } = new List<Message>();

    public List<String> ToStringItems() {
      var result = new List<String>();

      if (NetworkNodes.Any())
        result.Add($"Network nodes = {String.Join(", ", NetworkNodes)}");

      foreach (var message in Messagess) {
        result.Add(message.ToString());
        message.Signals.ForEach(signal => result.Add($"  {signal}"));
      }

      return result;
    }
  }
}