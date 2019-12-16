using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Like
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
        public int Value { get; set; }
    }
}
