﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthHelperMobileApp.Models
{
    class CActivityLevel
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Description { get; set; }


    }
}
