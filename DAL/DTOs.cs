using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC_Admin.DAL
{
    struct CanDbcDTO
    {
        public int CanDbcId { get; set; }
        public string Name { get; set; }
    }

    struct NetworkNodeDTO
    {
        public int CanDbcId { get; set; }
        public string Name { get; set; }
    }

    struct MessageDTO
    {
        public long MessageId { get; private set; }
        public int CanDbcId { get; set; }
        public string Name { get; private set; }
    }

    struct SignalDTO
    {
        public long MessageId { get; private set; }
        public string Name { get; private set; }
        public byte StartBit { get; private set; }
        public byte Length { get; private set; }
    }
}
