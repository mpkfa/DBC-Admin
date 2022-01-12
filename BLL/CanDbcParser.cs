using CanDbcAdmin.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CanDbcAdmin.BLL {

  public static class CanDbcParser {
    public class ParseException : Exception {
      public ParseException(string line, Exception ex) : base($"Cannot parse line: '${line}'\nError: {ex}") { }
    }

    public class UnexpectedTokenException : Exception {
      public UnexpectedTokenException(string token, string line) : base($"Unexpected token '{token}' on line: ${line}") { }
    }

    public static CanDbc ParseFile(string filename)
      => ParseData(Path.GetFileNameWithoutExtension(filename), File.ReadAllLines(filename));

    public static CanDbc ParseData(string filename, string[] data) {
      var result = new CanDbc();

      result.Filename = Path.GetFileNameWithoutExtension(filename);

      foreach (var line in data) {
        try {
          var parts = Regex.Split(line.Trim(), @"\s{1,}");
          var token = parts[0];
          var values = parts.Skip(1).ToArray();

          if (token == "BU_:") {
            result.NetworkNodes = parts.Skip(1).ToList();
          }
          else if (token == "BO_") {
            var id = Int64.Parse(values[0]);
            var name = values[1].Remove(values[1].Length - 1);

            result.Messagess.Add(new Message { Id = id, Name = name });
          }
          else if (token == "SG_") {
            if (!result.Messagess.Any()) throw new UnexpectedTokenException(token, line);

            var columnIndex = Array.IndexOf(values, ":");
            var name = String.Join(" ", values.Take(columnIndex));
            var bitParts = values.Skip(columnIndex + 1).First().Split(new[] { '|', '@' });
            var bitStart = Byte.Parse(bitParts[0]);
            var length = Byte.Parse(bitParts[1]);

            result.Messagess.Last().Signals.Add(new Signal { Name = name, StartBit = bitStart, Length = length });
          }
        } catch (UnexpectedTokenException) {
          throw;
        } catch (Exception ex) {
          throw new ParseException(line, ex);
        }
      }

      return result;
    }
  }
}
