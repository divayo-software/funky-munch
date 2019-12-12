using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Data.Entities
{
    public interface IBaseEntity
    {
        long Id { get; set; }

        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }
    }
}
