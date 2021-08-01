﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MySkills
    {
        [Key]
        public int SkillID { get; set; }

        [StringLength(50)]
        public string SkillName { get; set; }

        [Range(0,100)]
        public int SkillPoint { get; set; }
    }
}