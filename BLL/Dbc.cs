using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static CanDbcAdmin.BLL.Dbc.Message;

namespace CanDbcAdmin.BLL
{
    public class Dbc
    {
        public class ParseException : Exception
        {
            public ParseException(string line, Exception ex) : base($"Cannot parse line: '${line}'\nError: {ex}") {}
        }

        public class UnexpectedTokenException : Exception
        {
            public UnexpectedTokenException(string line) : base($"Unexpected token on line: ${line}") { }
        }

        public class Message
        {
            public class Signal
            {
                public string Name { get; private set; }
                public byte StartBit { get; private set; }
                public byte Length { get; private set; }

                public Signal(string name, byte startBit, byte length)
                {
                    Name = name;
                    StartBit = startBit;
                    Length = length;
                }

                public override string ToString() => $"Signal = {Name}, {StartBit}|{Length}";
            }

            public long Id { get; private set; }
            public string Name { get; private set; }
            public List<Signal> Signals { get; private set; } = new List<Signal>();

            public Message(long id, string name)
            {
                Id = id;
                Name = name;
            }

            public void AddSignal(Signal signal) => Signals.Add(signal);

            public override string ToString() => $"Message = {Id}, {Name}";
        }

        public string Filename { get; private set; }
        public List<String> NetworkNodes { get; private set; } = new List<String>();
        public List<Message> Messagess { get; private set; } = new List<Message>();

        public List<String> ToStringItems()
        {
            var result = new List<String>();

            if (NetworkNodes.Any())
                result.Add($"Network nodes = {String.Join(", ", NetworkNodes)}");

            foreach(var message in Messagess)
            {
                result.Add(message.ToString());
                message.Signals.ForEach(signal => result.Add($"  {signal}"));
            }

            return result;
        }

        public Dbc(string filename)
        {
            Filename = filename;

            foreach(var line in File.ReadAllLines(filename))
            {
                try
                {
                    var parts = Regex.Split(line.Trim(), @"\s{1,}");
                    var token = parts[0];
                    var values = parts.Skip(1).ToArray();

                    if (token == "BU_:")
                    {
                        NetworkNodes = parts.Skip(1).ToList();
                    }
                    else if (token == "BO_")
                    {
                        var id = Int64.Parse(values[0]);
                        var name = values[1].Remove(values[1].Length - 1);

                        Messagess.Add(new Message(id, name));
                    }
                    else if (token == "SG_")
                    {
                        if (!Messagess.Any()) throw new UnexpectedTokenException(line);

                        var columnIndex = Array.IndexOf(values, ":");
                        var name = String.Join(" ", values.Take(columnIndex));
                        var bitParts = values.Skip(columnIndex + 1).First().Split(new[] { '|', '@' });
                        var bitStart = Byte.Parse(bitParts[0]);
                        var length = Byte.Parse(bitParts[1]);

                        Messagess.Last().AddSignal(new Signal(name, bitStart, length));
                    }
                }
                catch (UnexpectedTokenException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new ParseException(line, ex);
                }
            }
        }
    }
}