﻿using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.Data
{
    public interface IBaseEntity<TKey> : IBaseEntity
    {
        TKey Id { get; set; }
        DateTime? Created_On{ get; set; }
        DateTime? LastUpdatedDate { get; set; }
    }
    public interface IBaseEntity
    {
    }
}
