using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Countr.Core.Models
{
    public class Counter
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
